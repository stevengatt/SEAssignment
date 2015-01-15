using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Traders_Marketplace.Models;
using BusinessLayer;
using Common;
namespace Traders_Marketplace.Controllers
{
    public class PermissionController : Controller
    {
        //
        // GET: /Permission/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreatePermission(string username)
        {
            Session["userForPermission"] = username;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePermission(CreatePermissionModel cpm, string username)
        {

            new PermissionBL().addPermission(username, cpm.Create, cpm.Delete, cpm.Edit, cpm.View);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditPermission(string username)
        {
            Session["userForPermission"] = username;

            UserPermission u = new PermissionBL().getPermissionOfUser(username);

            EditPermissionModel epm = new EditPermissionModel();
            epm.Create = u.AllowCreate;
            epm.Edit = u.AllowEdit;
            epm.Delete = u.AllowDelete;
            epm.View = u.AllowView;
            epm.permissionID = u.UserRolesPermissionsID;
            epm.Username = u.UserFK;

            return View(epm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPermission(EditPermissionModel epm)
        {

            if (ModelState.IsValid)
            {
                new PermissionBL().editPermission(epm.permissionID, epm.Username, epm.Create, epm.Edit, epm.Delete, epm.View);

                return RedirectToAction("Index", "Home");
            }
            return View(epm);
        }
    }
}
