using DataConnect.Data;
using DataConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using DataConnect.Business;
using System.IO;
using System.Drawing;

namespace DataConnect.Controllers
{
    public class AccountController : Controller
    {
        private string Dbconn;
        [HttpGet]
        public IActionResult AllAccounts()
        {
            AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            if (user.Role != Roles.Administrator)
            {
                return RedirectToAction("Index", "Channel");
            }
            AccountDAL accountdal = new AccountDAL();
            List<AccountViewModel> model = new List<AccountViewModel>();
            foreach (Account account in accountdal.AllAccounts(Dbconn))
            {
                model.Add(new AccountViewModel(account));
            }
            return View(model);
        }

        [HttpGet]

        public IActionResult Login()
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                return RedirectToAction("Index", "Channel");
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AccountDAL accountDAL = new AccountDAL();
                vm.AccountID = accountDAL.GetAccount(vm.Email, vm.Password);
                if (ModelState.IsValid)
                {
                    if (vm.AccountID != 0)
                    {
                        vm.Role = accountDAL.GetRole(vm.AccountID);
                        // Set the value into a session key
                        HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(vm));
                        HttpContext.Session.SetInt32("UserID", vm.AccountID);
                        if (vm.Role == Roles.Administrator)
                        {
                            return Redirect("AllAccounts");
                        }
                        else
                        {
                            return Redirect("/Channel/Index");
                        }
                    }
                    ViewData["Error"] = "username/password is not correct";
                }
                return View();
            }
            else 
            {              
                return View();        
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserSession");
            return Redirect("/Account/Login");
        } 

        [HttpGet]
        public IActionResult Register(int? alert)
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                return RedirectToAction("Index", "Channel");
            }
            catch
            {
                ViewBag.Alert = alert;
                return View();
            }
        }
        [HttpPost]
        public IActionResult Register(AccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                AccountDAL accountDAL = new AccountDAL();
                Account account = new Account(vm.AccountID, vm.FirstName, vm.LastName, vm.Password, vm.Role, vm.DisplayName, vm.Email);
                bool werkt = accountDAL.CreateAccount(account);
                if (werkt)
                {
                    return Redirect("/Channel/Index");
                }
                else
                {
                    return RedirectToAction("Register", new { alert = 0 });
                }
            }
            else { return View(); }
        }

        [HttpGet]
        public IActionResult EditAccount(int id)
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                if (user.Role != Roles.Administrator)
                {
                    return RedirectToAction("Index", "Channel");
                }
            }
            catch
            {
                return RedirectToAction("Account", "Login");
            }

            AccountDAL accountDAL = new AccountDAL();
            Account account = new Account();
            account.Role = accountDAL.GetRole(id);
            AccountViewModel vm = new AccountViewModel(account);

            return View(vm);
        }
        [HttpGet]
        public IActionResult EditPassword()
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                if (user.Role != Roles.User)
                {
                    return RedirectToAction("Index", "Channel");
                }
            }
            catch
            {
                return RedirectToAction("Account", "Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditPassword(ChangePasswordViewModel cpvm)
        {
            if (ModelState.IsValid)
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                if (user.Password != cpvm.OldPassword)
                {
                    ViewData["Error2"] = "Old password is wrong!";
                    return View();
                }
                if (cpvm.NewPassword1 != cpvm.NewPassword2)
                {
                    ViewData["Error"] = "new passwords don't match!";
                    return View();
                }

                if (user.Role != Roles.User)
                {
                    return RedirectToAction("Index", "Channel");
                }
                int Id = HttpContext.Session.GetInt32("UserID").Value;
                AccountDAL accountDAL = new AccountDAL();
                accountDAL.EditPassword(Id, cpvm.NewPassword1);
                return RedirectToAction("Logout", "Account");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult EditAccount(AccountViewModel vm)
        {
            AccountDAL accountDAL = new AccountDAL();
            Account account = new Account(vm.AccountID, vm.Role);
            accountDAL.EditAccount(account);

            return RedirectToAction("AllAccounts");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                if (user.Role != Roles.Administrator)
                {
                    return RedirectToAction("Index", "Channel");
                }
            }
            catch
            {
                return RedirectToAction("Account", "Login");
            }
            AccountDAL accountDAL = new AccountDAL();
            accountDAL.Delete(Dbconn, id);
            return RedirectToAction("AllAccounts");
        }
        [HttpGet]
        public IActionResult UpdateAccount()
        {
            AccountDAL accountDAL = new AccountDAL();
            int id = HttpContext.Session.GetInt32("UserID").Value;
            Account account = accountDAL.GetAccount(id);
            ViewBag.Account = account;
            AccountViewModel vm = new AccountViewModel(account);
            return View(vm);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAccount(AccountViewModel viewModel)
        {
            if (viewModel.Image != null)
            {

                using (var fs = new FileStream($"./wwwroot/PFPFolder/{JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession")).AccountID}.jpg", FileMode.Create))
                {

                    using (var memoryStream = new MemoryStream())
                    {
                        if (OperatingSystem.IsWindows())
                        {
                        await viewModel.Image.CopyToAsync(memoryStream);
                            using (var img = Image.FromStream(memoryStream))
                            {
                                int iWidth = img.Width;
                                int iHeight = img.Height;
                                if (iWidth > 200 && iWidth < 2000 && iHeight > 200 && iHeight < 2000)
                                {
                                    viewModel.Image.CopyTo(fs);
                                }
                                else
                                {
                                    ViewData["Error"] = "the file dimensions are not in the 200*200 - 2000*2000 range";
                                    return View(viewModel);
                                }
                            }
                        }
                    }

                }
            }

            AccountViewModel vm = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            vm.FirstName = viewModel.FirstName;
            vm.LastName = viewModel.LastName;
            vm.Description = viewModel.Description;
            vm.DisplayName = viewModel.DisplayName;


            AccountDAL accountDAL = new AccountDAL();
            //Dit moet verandered worden met een functie die werkt :)
            // je kan alleen de roleid aanpassen dit is niet H A N D I G

            accountDAL.UpdateAccount(new Account(vm.AccountID, vm.FirstName, vm.LastName, vm.Description, vm.DisplayName));
            HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(vm));

            return RedirectToAction("ViewProfile");
        }
        public IActionResult ViewProfile()
        {
            AccountDAL accountDAL = new AccountDAL();
            int ID = HttpContext.Session.GetInt32("UserID").Value;
            Account account = accountDAL.GetAccount(ID);
            AccountViewModel vm = new AccountViewModel(account);
            return View(vm);

        }

    }
}
