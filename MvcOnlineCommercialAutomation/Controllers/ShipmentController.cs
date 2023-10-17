using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: Shipment
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var values = from x in c.ShipmentDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.TrackingNumber.Contains(p));
            }
            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult AddShipment()
        {
            string randomString = Guid.NewGuid().ToString().Substring(0, 10);
            ViewBag.trackingNumber = randomString;
            return View();
        }
        [HttpPost]
        public ActionResult AddShipment(ShipmentDetail p)
        {
            c.ShipmentDetails.Add(p);
            c.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ActionResult ShipmentDetail(string id)
        {
            var value = c.ShipmentTracks.Where(x => x.TrackingNumber == id).ToList();
            return View(value);
        }
    }
}