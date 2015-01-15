using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Traders_Marketplace.Models
{
    public class RolesModel
    {
    }

    public class createRoleModel
    {
        public string Role { get; set; }
    }

    public class getAllRoles
    {
        public int RoleID { get; set; }
        public string role { get; set; }
    }

    public class editRole
    {
        public int RoleID { get; set; }
        public string role { get; set; }
    }
}