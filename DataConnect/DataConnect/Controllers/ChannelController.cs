using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataConnect.Models;
using DataConnect.Business;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace DataConnect.Controllers
{
    public class ChannelController : Controller
    {
        private string Dbconn;
        private ChannelDAL db = new ChannelDAL();

        public ChannelController(IConfiguration configuration)
        {
            Dbconn = configuration.GetSection("Connectionstrings").GetSection("MyDb1").Value;
        }

        public IActionResult Index()
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            }
            catch
            {
                return Redirect("/Account/Login");
            }

            List<ChannelViewModel> Channels = new List<ChannelViewModel>();
            foreach (Channel channel in db.Allchannel(Dbconn))
            {
                Channels.Add(new ChannelViewModel(channel));
            }
            AccountViewModel User = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

            Channels_AccountViewModel model = new Channels_AccountViewModel(Channels, User);

            return View(model);
        }

        public IActionResult LoginTest()
        {
            // Collection Model
            CollectionViewModel model = new CollectionViewModel();

            // Get session info
            AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));

            // Get all channels
            List<ChannelViewModel> channels = new List<ChannelViewModel>();
            foreach (Channel channel in db.Allchannel(Dbconn))
            {
                channels.Add(new ChannelViewModel(channel));
            }

            model.channelvms = channels;
            model.uservm = user;

            return View(model);
        }

        [HttpGet]
        public IActionResult AddChannel()
        {
            try
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                if (user.Role != Roles.Moderator)
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
        public IActionResult AddChannel(ChannelViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                if (user.Role != Roles.Moderator)
                {
                    return RedirectToAction("Index", "Channel");
                }
                Channel channel = new Channel(model.Id, model.Name, model.Description);
                db.AddChannel(Dbconn, channel);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult RemoveChannel(int id)
        {
            AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
            if (user.Role != Roles.Moderator)
            {
                return RedirectToAction("Index", "Channel");
            }
            db.DeleteChannel(Dbconn, id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditChannel(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AccountViewModel user = JsonConvert.DeserializeObject<AccountViewModel>(HttpContext.Session.GetString("UserSession"));
                    if (user.Role != Roles.Moderator)
                    {
                        return RedirectToAction("Index", "Channel");
                    }
                }
                catch
                {
                    return RedirectToAction("Account", "Login");
                }

                //Channel channel = new Channel(id);
                ChannelDAL channelDAL = new ChannelDAL();
                Channel channel = channelDAL.GetChannelById(id);
                ViewBag.Channel = channel;
                ChannelViewModel channelView = new ChannelViewModel(channel);
                return View(channelView);
            }
            else return View();
        }

        public IActionResult EditChannel(Channel model)
        {
            Channel channel = new Channel(model.Id, model.Name, model.Description);
            db.EditChannel(Dbconn, channel);
            return RedirectToAction("Index");
        }
    }
}
