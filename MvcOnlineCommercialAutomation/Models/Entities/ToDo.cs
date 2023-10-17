using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class ToDo
    {
        [Key]
        public int ToDoID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string Title { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }

    }
}