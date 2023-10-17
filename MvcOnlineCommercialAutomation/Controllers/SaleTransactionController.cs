using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class SaleTransactionController : Controller
    {
        Context c = new Context();
        // GET: SaleTransaction
        public ActionResult Index()
        {
            var values = c.SaleTransactions.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSaleTransaction()
        {
            List<SelectListItem> list = (from x in c.Products.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ProductName,
                                             Value = x.ProductID.ToString(),
                                         }).ToList();

            List<SelectListItem> list2 = (from x in c.CurrentAccounts.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CurrentAccountName + " " + x.CurrentAccountSurname,
                                              Value = x.CurrentAccountID.ToString(),
                                          }).ToList();

            List<SelectListItem> list3 = (from x in c.Employees.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.EmployeeName + " " + x.EmployeeSurname,
                                              Value = x.EmployeeID.ToString(),
                                          }).ToList();

            ViewBag.lst=list;
            ViewBag.lst2=list2;
            ViewBag.lst3=list3;
            return View();
        }
        [HttpPost]
        public ActionResult AddSaleTransaction(SaleTransaction s)
        {
            s.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SaleTransactions.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSaleTransaction(int id)
        {
            List<SelectListItem> list = (from x in c.Products.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ProductName,
                                             Value = x.ProductID.ToString(),
                                         }).ToList();

            List<SelectListItem> list2 = (from x in c.CurrentAccounts.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CurrentAccountName + " " + x.CurrentAccountSurname,
                                              Value = x.CurrentAccountID.ToString(),
                                          }).ToList();

            List<SelectListItem> list3 = (from x in c.Employees.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.EmployeeName + " " + x.EmployeeSurname,
                                              Value = x.EmployeeID.ToString(),
                                          }).ToList();

            ViewBag.lst = list;
            ViewBag.lst2 = list2;
            ViewBag.lst3 = list3;

            var value = c.SaleTransactions.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSaleTransaction(SaleTransaction s) 
        {
            var value = c.SaleTransactions.Find(s.SaleID);
            value.ProductID = s.ProductID;
            value.CurrentAccountID = s.CurrentAccountID;
            value.EmployeeID = s.EmployeeID;
            value.Quantity= s.Quantity;
            value.Price= s.Price;
            value.Amount= s.Amount;
            value.Date= DateTime.Parse(DateTime.Now.ToString());
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailSaleTransaction(int id)
        {
            var values = c.SaleTransactions.Where(x=> x.SaleID == id).ToList();
            return View(values);
        }

    }
}