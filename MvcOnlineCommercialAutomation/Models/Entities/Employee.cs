using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string EmployeeImage { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string EmployeeAbout { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string EmployeeAdress { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string EmployeePhone { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}