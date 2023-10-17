using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class ShipmentTrack
    {
        [Key]
        public int ShipmentTrackID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TrackingNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}