using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class PermissionsRepositry : ConnectionClass
    {
        public PermissionsRepositry() : base() { }

        //create
        public void addPermission(UserPermission p)
        {
            entities.AddToUserPermissions(p);
            entities.SaveChanges();
        }

        public UserPermission getPermissionOfUser(string username)
        {
            return entities.UserPermissions.SingleOrDefault(up => up.UserFK == username);
        }

        public void editPermission(UserPermission p)
        {
            entities.UserPermissions.Attach(getPermissionOfUser(p.UserFK));
            entities.UserPermissions.ApplyCurrentValues(p);
            entities.SaveChanges();
        }

        public void deletePermission(string username)
        {
            entities.UserPermissions.DeleteObject(getPermissionOfUser(username));
            entities.SaveChanges();
        }
    }
}
