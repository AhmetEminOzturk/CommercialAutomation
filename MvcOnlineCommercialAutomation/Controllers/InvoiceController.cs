
using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {

        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Invoices.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice ınvoice)
        {
            c.Invoices.Add(ınvoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateInvoice(int id)
        {
            var values = c.Invoices.Find(id);
            return View("UpdateInvoice", values);
        }
        [HttpPost]
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            var values = c.Invoices.Find(invoice.InvoiceID);
            values.InvoiceSequenceNo = invoice.InvoiceSequenceNo;
            values.InvoiceSerialNo = invoice.InvoiceSerialNo;
            values.Date = invoice.Date;
            values.Time = invoice.Time;
            values.TaxOffice = invoice.TaxOffice;
            values.Deliverer = invoice.Deliverer;
            values.Receiver = invoice.Receiver;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailInvoice(int id) 
        {
            var values = c.InvoiceItems.Where(x=> x.InvoiceID == id).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddInvoiceItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem ıtem)
        {
            c.InvoiceItems.Add(ıtem);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DynamicInvoice()
        {
            DynamicInvoiceClass cs = new DynamicInvoiceClass();
            cs.value1 = c.Invoices.ToList();
            cs.value2 = c.InvoiceItems.ToList();
            return View(cs);
        }
        public ActionResult InvoiceSave(string InvoiceSerialNo, string InvoiceSequenceNo, DateTime Date, string TaxOffice, string Time, string Deliverer, string Receiver, string Amount, InvoiceItem[] items)
        {
            Invoice f = new Invoice();
            f.InvoiceSerialNo = InvoiceSerialNo;
            f.InvoiceSequenceNo = InvoiceSequenceNo;
            f.Date = Date;
            f.TaxOffice = TaxOffice;
            f.Time = Time;
            f.Deliverer = Deliverer;
            f.Receiver = Receiver;
            f.Amount = decimal.Parse(Amount);
            c.Invoices.Add(f);
            foreach (var x in items)
            {
                InvoiceItem fk = new InvoiceItem();
                fk.Description = x.Description;
                fk.UnitPrice = x.UnitPrice;
                fk.InvoiceID = x.InvoiceItemID;
                fk.Quantity = x.Quantity;
                fk.Amount = x.Amount;
                c.InvoiceItems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}