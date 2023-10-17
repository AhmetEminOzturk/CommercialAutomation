using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class CurrentAccountPanelController : Controller
    {
        // GET: CurrentAccountPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentAccountMail"];
            var values = c.Messages.Where(x => x.Receiver == mail).ToList();
            ViewBag.mail = mail;
            var mailId = c.CurrentAccounts.Where(x => x.CurrentAccountMail == mail).Select(y => y.CurrentAccountID).FirstOrDefault();
            ViewBag.mailId = mailId;
            var totalSale = c.SaleTransactions.Where(x => x.CurrentAccountID == mailId).Count();
            ViewBag.totalSale = totalSale;
            var amount = c.SaleTransactions.Where(x => x.CurrentAccountID == mailId).Sum(y => (decimal?) y.Amount);
            ViewBag.amount = amount;
            var totalProduct = c.SaleTransactions.Where(x => x.CurrentAccountID == mailId).Sum(y => (decimal?) y.Quantity);
            ViewBag.totalProduct = totalProduct;
            var nameSurname = c.CurrentAccounts.Where(x => x.CurrentAccountMail == mail).Select(y => y.CurrentAccountName + " " + y.CurrentAccountSurname).FirstOrDefault();
            ViewBag.nameSurname = nameSurname;
            return View(values);
        }
        public ActionResult Order()
        {
            var mail = (string)Session["CurrentAccountMail"];
            var id = c.CurrentAccounts.Where(x => x.CurrentAccountMail == mail).Select(y => y.CurrentAccountID).FirstOrDefault();
            var values = c.SaleTransactions.Where(x => x.CurrentAccountID == id).ToList();
            return View(values);
        }

        public ActionResult InboxMessage()
        {
            var mail = (string)Session["CurrentAccountMail"];
            var values = c.Messages.Where(x => x.Receiver == mail).OrderByDescending(x => x.MessagejID).ToList();
            var ınbox = c.Messages.Count(x => x.Receiver == mail).ToString();
            var outbox = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.d2 = outbox;
            ViewBag.d1 = ınbox;

            return View(values);
        }
        public ActionResult OutboxMessage()
        {
            var mail = (string)Session["CurrentAccountMail"];
            var values = c.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessagejID).ToList();
            var outbox = c.Messages.Count(x => x.Sender == mail).ToString();
            var ınbox = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = ınbox;
            ViewBag.d2 = outbox;

            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var values = c.Messages.Where(x => x.MessagejID == id).ToList();
            var mail = (string)Session["CurrentAccountMail"];
            var outbox = c.Messages.Count(x => x.Sender == mail).ToString();
            var ınbox = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = ınbox;
            ViewBag.d2 = outbox;
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentAccountMail"];
            var outbox = c.Messages.Count(x => x.Sender == mail).ToString();
            var ınbox = c.Messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = ınbox;
            ViewBag.d2 = outbox;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["CurrentAccountMail"];
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            c.Messages.Add(message);
            c.SaveChanges();
            return View();
        }
        public ActionResult TrackOrder(string p)
        {
            var values = from x in c.ShipmentDetails select x;
            values = values.Where(y => y.TrackingNumber.Contains(p));
            return View(values.ToList());
        }
        public ActionResult CurrentAccountOrderTrack(string id)
        {
            var value = c.ShipmentTracks.Where(x => x.TrackingNumber == id).ToList();
            return View(value.ToList());
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CurrentAccountMail"];
            var id = c.CurrentAccounts.Where(x => x.CurrentAccountMail == mail).Select(y => y.CurrentAccountID).FirstOrDefault();
            var findCurrentAccounts = c.CurrentAccounts.Find(id);
            return PartialView("Partial1", findCurrentAccounts);
        }
        public PartialViewResult Partial2()
        {
            var values = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(values);
        }
        public ActionResult UpdateCurrentAccount(CurrentAccount cr)
        {
            var currentAccount = c.CurrentAccounts.Find(cr.CurrentAccountID);
            currentAccount.CurrentAccountName = cr.CurrentAccountName;
            currentAccount.CurrentAccountSurname = cr.CurrentAccountSurname;
            currentAccount.CurrentAccountPassword = cr.CurrentAccountPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}