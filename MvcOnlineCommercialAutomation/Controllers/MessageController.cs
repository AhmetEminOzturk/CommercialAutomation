using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
    }
}