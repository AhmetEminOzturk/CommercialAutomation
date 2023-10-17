using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class ShipmentDetail
    {
        [Key]
        public int ShipmentDetailID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingNumber { get; set; }//1234123AB

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Employee { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Receiver { get; set; }

        public DateTime Date { get; set; }
    }
}