using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Traders_Marketplace.Models
{
    public class EditPermissionModel
    {
        public int permissionID { get; set; }
        public string Username { get; set; }
        public bool Create { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
    }
}