using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class CurrentAccountController : Controller
    {
        // GET: CurrentAccount
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.CurrentAccounts.Where(x=> x.Status == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCurrentAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrentAccount(CurrentAccount account)
        {
            account.Status = true;
            c.CurrentAccounts.Add(account);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCurrentAccount(int id)
        {
            var value = c.CurrentAccounts.Find(id);
            value.Status= false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCurrentAccount(int id) 
        {
            var value = c.CurrentAccounts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCurrentAccount(CurrentAccount currentAccount)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateCurrentAccount");
            }

            var value = c.CurrentAccounts.Find(currentAccount.CurrentAccountID);
            value.CurrentAccountName = currentAccount.CurrentAccountName;
            value.CurrentAccountSurname = currentAccount.CurrentAccountSurname;
            value.CurrentAccountCity = currentAccount.CurrentAccountCity;
            value.CurrentAccountMail = currentAccount.CurrentAccountMail;
            c.SaveChanges();
            return RedirectToAction("Index");           
        }

        public ActionResult GetSales(int id) 
        {
            var value = c.SaleTransactions.Where(x=> x.CurrentAccountID== id).ToList();
            var cr = c.CurrentAccounts.Where(x => x.CurrentAccountID == id).Select(y => y.CurrentAccountName + " " + y.CurrentAccountSurname).FirstOrDefault();
            ViewBag.v2 = cr;
            return View(value);
        }

    }
}