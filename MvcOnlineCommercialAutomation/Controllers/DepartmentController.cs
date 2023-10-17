using MvcOnlineCommercialAutomation.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var values= c.Departments.Where(x=>x.Status==true).ToList();
            return View(values);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department d) 
        {
            c.Departments.Add(d);
            c.SaveChangesAsync();
           return  RedirectToAction("Index");
        }
        public ActionResult DeleteDepartment(int id)
        {
            var value = c.Departments.Find(id);
            value.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateDepartment(int id) 
        {
            var value = c.Departments.Find(id);
            return View("UpdateDepartment",value);
        }
        [HttpPost]
        public ActionResult UpdateDepartment(Department p)
        {
            var value = c.Departments.Find(p.DepartmentID);
            value.DepartmentName = p.DepartmentName;
            c.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public ActionResult DetailDepartment(int id)
        {
            var value = c.Employees.Where(x=>x.DepartmentID==id).ToList();
            var departmentName = c.Departments.Where(x=> x.DepartmentID==id).Select(x=>x.DepartmentName).FirstOrDefault();
            ViewBag.v = departmentName;
            return View(value);
        }

        public ActionResult DepartmentEmployeeSales(int id)
        {
            var values = c.SaleTransactions.Where(x=>x.EmployeeID==id).ToList();
            var emp= c.Employees.Where(x=> x.EmployeeID==id).Select(y=> y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();
            ViewBag.v2 = emp;
            return View(values);
        }
    }
}