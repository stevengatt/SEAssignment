using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class UserRepositry : ConnectionClass
    {
        public UserRepositry() : base() { }

        //create
        public void createUser(User u)
        {
            entities.AddToUsers(u);
            entities.SaveChanges();
        }

        //get user by username
        public User getUser(string username)
        {
            return entities.Users.SingleOrDefault(x => x.Username == username);
        }

        //edit
        public void editUser(User u)
        {
            entities.Users.Attach(getUser(u.Username));
            entities.Users.ApplyCurrentValues(u);
            entities.SaveChanges();
        }

        //delete
        public void deleteUser(string username)
        {
            entities.Users.DeleteObject(getUser(username));
            entities.SaveChanges();
        }

        //get all users
        public IEnumerable<User> getAllUsers()
        {
            return entities.Users.AsEnumerable();
        }

        //validate user
        public bool IsAutenticated(string username, string password)
        {
            if (entities.Users.SingleOrDefault(x => x.Username == username && x.Password == password) == null)
                return false;
            else
                return true;
        }

        //checks if username allready exists
        public bool usernameValid(string username)
        {
            if (entities.Users.Count(u => u.Username == username) == 0)
                return false;
            else
                return true;
        }

        //-----------------------------------------Role Section

        //get role by ID
        public Role getRoleByID(int roleID)
        {
            if (roleID < 1)
            {
                throw new NullReferenceException();
            }
            else
            {
                try
                {
                    return entities.Roles.SingleOrDefault(r => r.RoleID == roleID);
                }
                catch
                {
                    throw new NullReferenceException();
                }
            }

            
         }

        public int getRoleOfUser(string username)
        {
            return (from ur in entities.UserRoles
                    join u in entities.Users
                        on ur.UserFK equals u.Username
                    where ur.UserFK == username
                    select ur.RoleFK).SingleOrDefault();
        }


        public UserRole getUserRole(string username)
        {
            return entities.UserRoles.SingleOrDefault(ur => ur.UserFK == username);
        }

        public void editUserRole(UserRole ur)
        {
            entities.UserRoles.Attach(getUserRole(ur.UserFK));
            entities.UserRoles.ApplyCurrentValues(ur);
            entities.SaveChanges();
        }

        public IEnumerable<Role> getAllRoles()
        {
            //return entities.Roles.AsEnumerable();
            return (from r in entities.Roles
                    where r.RoleName != "Admin"
                    select r).AsEnumerable();
        }

        public IEnumerable<Role> getAllRoles_UserManagement()
        {
            return entities.Roles.AsEnumerable();
        }
        public void AllocateUser(UserRole ur)
        {
            entities.AddToUserRoles(ur);
            entities.SaveChanges();
        }


        public void createRole(Role r)
        {
            if (r.RoleName == string.Empty)
            {
                throw new FormatException();
            }
            else if (r.RoleName.Length <= 3)
            {
                throw new FormatException();
            }
            else if (r.RoleName.Length >= 16)
            {
                throw new FormatException();
            }
            else if (!Regex.IsMatch(r.RoleName, @"^[a-zA-Z]+$"))//to check for numbers
            {
                throw new FormatException();
            }
            else
            {
                entities.AddToRoles(r);
                entities.SaveChanges();
            }
            
           
            
        }

        public void editRoles(Role r)
        {
            if (!Regex.IsMatch(r.RoleName, @"^[a-zA-Z]+$"))
            {
                throw new FormatException();
            }
            else if (r.RoleName.Length <= 3)
            {
                throw new FormatException();
            }
            else if (r.RoleName.Length > 15)
            {
                throw new FormatException();
            }
            else
            {   entities.Roles.Attach((Role)getRoleByID(r.RoleID));
                entities.Roles.ApplyCurrentValues(r);
                entities.SaveChanges();
            }
        }

        public void deleteRole(int r)
        {
            try
            {
                entities.Roles.DeleteObject(getRoleByID(r));
                entities.SaveChanges();
            }
            catch
            {
                throw new NullReferenceException();
            }
        }
    }
}
