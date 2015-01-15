using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using System.ComponentModel.DataAnnotations;

namespace Traders_Marketplace.Models
{
    public class CreatePermissionModel
    {
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
    }
}