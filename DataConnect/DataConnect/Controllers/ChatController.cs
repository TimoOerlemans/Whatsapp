using DataConnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataConnect.Data;

namespace DataConnect.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index(int ChannelId)
        {
            try
            {              
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                AccountDAL accountDAL = new AccountDAL();
                string username = accountDAL.GetDisplayname(user.AccountID);    
                ChannelDAL channelDAL = new ChannelDAL();
                Channel channelname = channelDAL.GetChannelById(ChannelId);
                ViewBag.channelname = channelname;

                try
                {
                    if (user.Role != Business.Roles.User)
                    {
                        return RedirectToAction("Index", "Channel");
                    }
                }
                catch
                {
                    return RedirectToAction("Account", "Login");
                }

                return View("Index", new ChannelDTO{                     
                    UserName = username,
                });
            }
            catch(Exception a)
            {
                Console.WriteLine(a);
                return this.BadRequest();
            }
        }
        
    }
    public class ChannelDTO { 
        public string ChannelName {get; set; }
        public string UserName {get; set; }
    }
} 
