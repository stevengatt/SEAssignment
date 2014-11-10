using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;

namespace BusinessLayer
{
    public class PermissionBL
    {
        public void addPermission(string username, bool create, bool delete, bool edit, bool view)
        {
            PermissionsRepositry pr = new PermissionsRepositry();

            UserPermission up = new UserPermission()
            {
                UserFK = username;
                AllowCreate = create,
                AllowDelete = delete,
                AllowEdit = edit,
                AllowView = view
            };

            pr.addPermission(up);
        }

        public UserPermission getPermissionOfUser(string username)
        {
            return new PermissionsRepositry().getPermissionOfUser(username);
        }

        public void editPermission(int permissionID, string username, bool create, bool edit, bool delete, bool view)
        {
            PermissionsRepositry pr = new PermissionsRepositry();

            UserPermission up = new UserPermission()
            {
                UserRolesPermissionsID = permissionID,
                UserFK = username,
                AllowCreate = create,
                AllowDelete = delete,
                AllowEdit = edit,
                AllowView = view
            };

            pr.editPermission(up);
        }

        public void deletePermission(string username)
        {
            PermissionsRepositry pr = new PermissionsRepositry();
            pr.deletePermission(username);
        }
    }
}
