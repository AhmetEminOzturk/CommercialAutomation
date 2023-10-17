using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class CascadingClass
    {
        public IEnumerable <SelectListItem> Category { get; set; }
        public IEnumerable <SelectListItem> Product { get; set; }
    }
}