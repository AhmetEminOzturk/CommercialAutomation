using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}