using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var graph = new Chart(600, 600);
            graph.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var results = c.Products.ToList();
            results.ToList().ForEach(x => xvalue.Add(x.ProductName));
            results.ToList().ForEach(y => yvalue.Add(y.Stock));
            var graph = new Chart(width: 800, height: 800)
                .AddTitle("Stoklar")
                .AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(graph.ToWebImage().GetBytes(), "image/jpeg");
        }


        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }

        public List<ChartGroup> ProductList()
        {
            List<ChartGroup> cls = new List<ChartGroup>();
            using (var c = new Context())
            {
                cls = c.Products.Select(x => new ChartGroup
                {
                    PName = x.ProductName,
                    Stck = x.Stock
                }).ToList();
            }
            return cls;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7() 
        {
            return View();
        }
    }
}