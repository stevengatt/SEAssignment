using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;

namespace BusinessLayer
{
    public class UserBL
    {
        //get all users
        public IEnumerable<User> getAllUsers()
        {
            return new UserRepositry().getAllUsers();
        }

        //get user by username
        public User getUserByUsername(string username)
        {
            return new UserRepositry().getUser(username);
        }

        //add new user
        public void addUser(string username, string name, string surname, string password, string email, int roleID)
        {
            UserRepositry ur = new UserRepositry();

            User u = new User
            {
                Username = username,
                Password = password,
                Name = name,
                Surname = surname,
                Email = email
            };

            ur.createUser(u);
            allocateUserRoles(username, roleID);
            new PermissionBL().addPermission(username, false, false, false, true);

        }

        //delete user
        public void deleteUser(string username)
        {
            UserRepositry ur = new UserRepositry();
            ur.deleteUser(username);
        }

        //update user
        public void updateUser(string username, string password, string name, string surname, string email)
        {
            UserRepositry ur = new UserRepositry();

            User updateUser = new User()
            {
                Username = username,
                Password = password,
                Name = name,
                Surname = surname,
                Email = email
            };

            ur.editUser(updateUser);
        }

        //validate
        public bool IsAutenticated(string username, string password)
        {

            return new UserRepositry().IsAutenticated(username, password);
        }

        //checks if username allready exists
        public bool usernameValid(string username)
        {
            return new UserRepositry().usernameValid(username);
        }

        //---------------------------------------------------------Roles

        public IEnumerable<Role> getAllRoles()
        {
            return new UserRepositry().getAllRoles();
        }

        //allocat user role
        public void allocateUserRoles(string username, int roleID)
        {
            UserRepositry ur = new UserRepositry();

            UserRole userRole = new UserRole()
            {
                UserFK = username,
                RoleFK = roleID,
                IsAdmin = false
            };

            ur.AllocateUser(userRole);
        }

        //get role by ID
        public Role getRoleByID(int roleID)
        {
            return (Role)new UserRepositry().getRoleByID(roleID);
        }

        public int getRoleOfUser(string username)
        {
            return new UserRepositry().getRoleOfUser(username);
        }


        public UserRole getUserRole(string username)
        {
            return new UserRepositry().getUserRole(username);
        }

        public void editUserRole(int userRoleID, string username, int role, bool isAdmin)
        {
            UserRepositry ur = new UserRepositry();

            UserRole userRole = new UserRole()
            {
                UserRoleID = userRoleID,
                UserFK = username,
                RoleFK = role,
                IsAdmin = isAdmin
            };

            ur.editUserRole(userRole);
        }



        public IEnumerable<Role> getAllRoles_UserManagement()
        {
            return new UserRepositry().getAllRoles_UserManagement();
        }


        public void createRole(string role)
        {
            UserRepositry ur = new UserRepositry();

            Role r = new Role()
            {
                RoleName = role
            };

            ur.createRole(r);
        }

        public void editRoles(int roleID, string role)
        {
            UserRepositry ur = new UserRepositry();

            Role r = new Role()
            {
                RoleID = roleID,
                RoleName = role
            };

            ur.editRoles(r);
        }

        public void deleteRole(int role)
        {
            UserRepositry ur = new UserRepositry();
            ur.deleteRole(role);

        }
    }
}
