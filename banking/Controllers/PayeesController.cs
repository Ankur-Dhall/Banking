using banking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace banking.Controllers
{
    public class PayeesController : Controller
    {
        [Authorize(Roles = Roles.Customer)]
        public ActionResult New()
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            var AccountNumber = user.AccountNumber;
            return View(AccountNumber);
        }
    }
}