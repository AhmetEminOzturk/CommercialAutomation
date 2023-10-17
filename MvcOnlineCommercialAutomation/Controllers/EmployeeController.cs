using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        Context c = new Context();
        // GET: Employee
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> list = (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString(),
                                         }).ToList();
            ViewBag.v = list;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee p)
        {
            if (Request.Files.Count>0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.EmployeeImage = "/Image/" + fileName + extension;
            }
            
            c.Employees.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            List<SelectListItem> list = (from x in c.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString(),
                                         }).ToList();
            ViewBag.v = list;
            var value = c.Employees.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEmployee(Employee p)
        {

            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName);
                string path = "~/Image/" + fileName + extension;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.EmployeeImage = "/Image/" + fileName + extension;
            }


            var value = c.Employees.Find(p.EmployeeID);
            value.EmployeeName = p.EmployeeName;
            value.EmployeeSurname = p.EmployeeSurname;
            value.EmployeeImage = p.EmployeeImage;
            value.DepartmentID = p.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeList()
        {
            var values = c.Employees.ToList();
            return View(values);
        }

    }
}