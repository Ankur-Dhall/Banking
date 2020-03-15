using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using banking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace banking.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.IsInRole(Roles.Customer))
            {
                var userId = User.Identity.GetUserId();
                var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
                var AccountNumber = user.AccountNumber;
                return View();
            }
            else if(User.IsInRole(Roles.CustomerManager))
            {
                return View("IndexManager");
            }
            return View("IndexLogin");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}