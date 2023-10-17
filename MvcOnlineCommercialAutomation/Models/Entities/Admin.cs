using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string UserName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Password { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Permission { get; set; }
    }
}