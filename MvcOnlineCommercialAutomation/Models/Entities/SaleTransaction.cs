using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class SaleTransaction
    {
        [Key]
        public int SaleID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }

        public int ProductID { get; set; }
        public int CurrentAccountID { get; set; }
        public int EmployeeID { get; set; }

        public virtual Product Product { get; set; }
        public virtual CurrentAccount CurrentAccount { get; set; }
        public virtual Employee Employee { get; set; }
    }
}