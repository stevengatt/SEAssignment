using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using System.ComponentModel.DataAnnotations;

namespace Traders_Marketplace.Models
{
    public class EditUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Role { get; set; }

        public bool IsAdmin { get; set; }

        public int UserRoleID { get; set; }
    }
}