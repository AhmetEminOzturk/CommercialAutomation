using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineCommercialAutomation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(CurrentAccount p)
        {
            c.CurrentAccounts.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CurrentAccountLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentAccountLogin(CurrentAccount p)
        {
            var values = c.CurrentAccounts.FirstOrDefault(x=> x.CurrentAccountMail == p.CurrentAccountMail && x.CurrentAccountPassword== p.CurrentAccountPassword);
            if (values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.CurrentAccountMail, false);
                Session["CurrentAccountMail"]=values.CurrentAccountMail.ToString();
                return RedirectToAction("Index", "CurrentAccountPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var values = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["UserName"] = values.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}