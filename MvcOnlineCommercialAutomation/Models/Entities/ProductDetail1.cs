﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineCommercialAutomation.Models.Entities
{
    public class ProductDetail1
    {
        public IEnumerable<Product> Value1 { get; set; }
        public IEnumerable<ProductDetail> Value2 { get; set; }
    }
}