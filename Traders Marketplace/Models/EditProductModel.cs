﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Traders_Marketplace.Models
{
    public class EditProductModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Username { get; set; }
    }
}