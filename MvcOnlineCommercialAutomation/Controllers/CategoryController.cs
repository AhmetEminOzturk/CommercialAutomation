using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Entities;
using PagedList;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        public ActionResult Index(int page = 1)
        {
            var values = c.Categories.ToList().ToPagedList(page, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            c.Categories.Add(category);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id) 
        {
            var value = c.Categories.Find(id);
            c.Categories.Remove(value);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id) 
        {
            var value = c.Categories.Find(id);
            return View("EditCategory",value);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            var value = c.Categories.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cascading()
        {
            CascadingClass cs = new CascadingClass();
            cs.Category = new SelectList(c.Categories, "CategoryID", "CategoryName");
            cs.Product = new SelectList(c.Products, "ProductID", "ProductName");
            return View(cs);
        }
        public JsonResult GetProduct(int p)
        {
            var productList = (from x in c.Products
                               join y in c.Categories
                               on x.Category.CategoryID equals y.CategoryID
                               where x.Category.CategoryID == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductID.ToString()
                               }).ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
    }
}