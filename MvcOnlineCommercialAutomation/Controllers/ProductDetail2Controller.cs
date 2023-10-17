using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ProductDetail2Controller : Controller
    {
        // GET: ProductDetail2
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
    }
}