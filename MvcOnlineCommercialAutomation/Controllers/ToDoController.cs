using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.CurrentAccounts.Count();
            ViewBag.v1=value1;
            var value2 = c.Products.Count();
            ViewBag.v2=value2;
            var value3 = c.Categories.Count();
            ViewBag.v3=value3;
            var value4 = (from x in c.CurrentAccounts select x.CurrentAccountCity).Distinct().Count();
            ViewBag.v4=value4;
            var values = c.ToDoList.ToList();
            return View(values);
        }
    }
}