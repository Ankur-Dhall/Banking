using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using banking.Models;
using banking.ViewModels;

namespace banking.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Details()
        {
            if(User.IsInRole(Roles.Customer))
            {
                var userId = User.Identity.GetUserId();
                var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
                var AccountNumber = user.AccountNumber;
                return View(AccountNumber);
            }
            return View("ManageCustomers");
        }
        [Authorize(Roles = Roles.Customer)]
        public ActionResult Withdraw()
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            var AccountNumber = user.AccountNumber;
            return View(AccountNumber);
        }

        [Authorize(Roles = Roles.Customer)]
        public ActionResult Deposit()
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            var AccountNumber = user.AccountNumber;
            return View(AccountNumber);
        }

        [Authorize(Roles = Roles.Customer)]
        public ActionResult Change()
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            var AccountNumber = user.AccountNumber;
            return View(AccountNumber);
        }

        [Authorize(Roles = Roles.Customer)]
        public ActionResult ChangeSuccessful()
        {
            return View();
        }

        [Authorize(Roles = Roles.Customer)]
        public ActionResult Transactions()
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            var AccountNumber = user.AccountNumber;
            return View(AccountNumber);
        }

        [Authorize(Roles = Roles.Customer)]
        public ActionResult Payees()
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            var AccountNumber = user.AccountNumber;
            return View(AccountNumber);
        }
        [Authorize(Roles = Roles.Customer)]
        public ActionResult Transfer(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(userId);
            PayeeViewModel payeeViewModel = new PayeeViewModel()
            {
                PayeeAccountNumber=id,
                SenderAccountNumber=user.AccountNumber
            };
            return View(payeeViewModel);
        }

    }
}