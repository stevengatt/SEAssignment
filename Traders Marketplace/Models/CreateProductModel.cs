using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.ComponentModel.DataAnnotations;

namespace Traders_Marketplace.Models
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}