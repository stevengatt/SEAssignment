using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BusinessLayer;
using Traders_Marketplace.Models;
using System.Web.Security;

namespace TradersMarketplace.Controllers
{

    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(RegisterUser ru)
        {
            new UserBL().addUser(ru.Username, ru.Name, ru.Surname, ru.Password, ru.Email, ru.Role);
            return RedirectToAction("Index", "Home");

        }

        public ActionResult LoggingInUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoggingInUser(LoggingInModel lm)
        {
            new UserBL().IsAutenticated(lm.Username.ToString(), lm.Password.ToString());
            FormsAuthentication.RedirectFromLoginPage(lm.Username, true);

            return Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditUser(string username)
        {
            Session["userForDetails"] = username;

            User u = new UserBL().getUserByUsername(username);

            UserRole ur = new UserBL().getUserRole(username);
            EditUserModel eum = new EditUserModel();
            eum.Username = u.Username;
            eum.Name = u.Name;
            eum.Surname = u.Surname;
            eum.Password = u.Password;
            eum.Email = u.Email;

            eum.UserRoleID = ur.UserRoleID;
            eum.Role = ur.RoleFK;
            eum.IsAdmin = ur.IsAdmin;
            return View(eum);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditUser(EditUserModel eum)
        {

            if (ModelState.IsValid)
            {
                new UserBL().updateUser(eum.Username, eum.Password, eum.Name, eum.Surname, eum.Email);

                new UserBL().editUserRole(eum.UserRoleID, eum.Username, eum.Role, eum.IsAdmin);

                return RedirectToAction("Index", "Home");
            }
            return View(eum);
        }

        [Authorize]
        public ActionResult deleteUser(string username)
        {
            new UserBL().deleteUser(username);
            return RedirectToAction("GetAllUsers");
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return View(new UserBL().getAllUsers());
        }

        [Authorize]
        [HttpGet]
        public ActionResult rolesIndex()
        {
            return View(new UserBL().getAllRoles());
        }



        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(createRoleModel crm)
        {
            new UserBL().createRole(crm.Role);
            return RedirectToAction("Index", "Home");

        }



        [Authorize]
        [HttpGet]
        public ActionResult EditRole(int roleID)
        {
            Role r = new UserBL().getRoleByID(roleID);

            editRole er = new editRole();

            er.RoleID = r.RoleID;
            er.role = r.RoleName;
            return View(er);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditRole(editRole er)
        {

            if (ModelState.IsValid)
            {
                new UserBL().editRoles(er.RoleID, er.role);


                return RedirectToAction("Index", "Home");
            }
            return View(er);
        }

        [Authorize]
        public ActionResult deleteRole(int id)
        {
            new UserBL().deleteRole(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
