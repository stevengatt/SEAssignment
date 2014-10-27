using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using DataAccess;


namespace TradersMarketplaceTestProject
{


    /// <summary>
    ///This is a test class for UserRepositryTest and is intended
    ///to contain all UserRepositryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserRepositryTest
    {

        TradersMarketplaceEntities entities = new TradersMarketplaceEntities();
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Test studs for create

        /// <summary>
        ///Test if role was created
        ///</summary>
        [TestMethod()]
        public void createRoleTest1()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.RoleName = "CreateTestRole";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "CreateTestRole";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "Not the same");
            }

            target.deleteRole(r.RoleID);
        }

        /// <summary>
        /// Boundary test 4 char
        /// </summary>
        [TestMethod()]
        public void createBoundary4Char()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.RoleName = "Test";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "Test";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "Not the same");
            }

            target.deleteRole(r.RoleID);
        }

        /// <summary>
        /// Test if role is empty
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void createRoleTest6()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = string.Empty;

            try { target.createRole(r); }
            catch{ throw; }
        }


        /// <summary>
        /// Boundary test 15 char
        /// </summary>
        [TestMethod()]
        public void createBoundary15Char()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.RoleName = "qwertyuiopasdfg";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "qwertyuiopasdfg";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "Not the same");
            }

            target.deleteRole(r.RoleID);
        }

        /// <summary>
        /// Boundary test 16 char
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void createBoundary16Char()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.RoleName = "TheRoleIsCreated";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "TheRoleIsCreated";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "Not the same");
            }

            target.deleteRole(r.RoleID);
        }

        /// <summary>
        /// Test if role is >= 3 characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void createBoundary3Char()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "Tes";

            try
            {
                target.createRole(r);
            }
            catch { throw; }
        }

        /// <summary>
        /// test if role is only letters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void createRoleTest4()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "4Tfe";

            try { target.createRole(r); }
            catch { throw; }
        }

        /// <summary>
        /// Test if role is smaller than 15 characters
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void createRoleTest5()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = new Guid().ToString();

            try { target.createRole(r); }
            catch { throw; }

        }



        #endregion

        #region test stub for edit
        /// <summary>
        ///A test for editRoles with a successful update
        ///</summary>
        [TestMethod()]
        public void editRolesTest1()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "RoleChanged";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.RoleName = "RoleChanged";

            Assert.AreEqual(expected.RoleName, actual.RoleName);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A boundary test for editRoles with a successful update 4 char
        ///</summary>
        [TestMethod()]
        public void editBoundary4Char()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "Role";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.RoleName = "Role";

            Assert.AreEqual(expected.RoleName, actual.RoleName);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A boundary test for editRoles with a successful update 16 char
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editBoundary16Char()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "TheRoleIsCreated";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.RoleName = "TheRolesIsCreated";

            Assert.AreEqual(expected.RoleName, actual.RoleName);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A test for editRoles that does not accept numbers
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editRolesTest2()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "Role34Changed";
            try
            {
                target.editRoles(rCreate);
            }
            catch
            {
                throw;
            }
            finally
            {
                target.deleteRole(rCreate.RoleID);
            }
        }

        /// <summary>
        ///A test for editRoles that does not accept characters
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editRolesTest3()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "Role_Changed_";
            try
            {
                target.editRoles(rCreate);
            }
            catch
            {
                throw;
            }
            finally
            {
                target.deleteRole(rCreate.RoleID);
            }
        }

        /// <summary>
        ///A boundary test for editRoles with a  update 3 char
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editBoundary3Char()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "Rol";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.RoleName = "Rol";

            Assert.AreEqual(expected.RoleName, actual.RoleName);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A boundary test for editRoles with a successful update 15 char
        ///</summary>
        [TestMethod()]
        public void editBoundary15Char()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "THRoleIsCreated";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.RoleName = "THRoleIsCreated";

            Assert.AreEqual(expected.RoleName, actual.RoleName);
            target.deleteRole(actual.RoleID);
        }
        /// <summary>
        ///A test for editRoles that does not accept a role with 3 or less characters
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editRolesTest5()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = "Ro";
            try
            {
                target.editRoles(rCreate);
            }
            catch
            {
                throw;
            }
            finally
            {
                target.deleteRole(rCreate.RoleID);
            }
        }

        /// <summary>
        ///A test for editRoles that does not accept a role with greather then 15 character
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editRolesTest6()
        {
            UserRepositry target = new UserRepositry();
            Role rCreate = new Role();
            rCreate.RoleName = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.RoleName = new Guid().ToString();
            try
            {
                target.editRoles(rCreate);
            }
            catch
            {
                throw;
            }
            finally
            {
                target.deleteRole(rCreate.RoleID);
            }
        }
        #endregion

        #region test for delete role
        /// <summary>
        ///A test for deleteRole
        ///</summary>
        [TestMethod()]
        public void deleteRoleTest1()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.RoleName = "CreateTestRole";
            target.createRole(r);

            bool same = false;
            int role = r.RoleID; // TODO: Initialize to an appropriate value

            target.deleteRole(r.RoleID);
            IEnumerable<Role> expected = entities.Roles.ToList();
            IEnumerable<Role> actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() == expected.Count())
            {
                same = true;
            }

            Assert.IsTrue(same);

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "Not the same");
            }
        }

        /// <summary>
        ///A test for deleteRole when role does not exist
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void deleteRoleTest2()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            int role = 12344; // TODO: Initialize to an appropriate value
            try
            {
                target.deleteRole(role);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void deleteBoundary1()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            int role = 4; // TODO: Initialize to an appropriate value
            try
            {
                target.deleteRole(role);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void deleteBoundary0()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            int role = 0; // TODO: Initialize to an appropriate value
            try
            {
                target.deleteRole(role);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region test for get role by id
        /// <summary>
        ///A test for getRoleByID to find a role
        ///</summary>
        [TestMethod()]
        public void getRoleByIDTest1()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value
            int roleID = 1; // TODO: Initialize to an appropriate value

            Role expected = (entities.Roles.SingleOrDefault(r => r.RoleID == roleID)); // TODO: Initialize to an appropriate value
            Role actual;

            actual = (Role)target.getRoleByID(roleID);

            Assert.AreEqual(expected.RoleName, actual.RoleName);
        }

        /// <summary>
        //A test for getRoleByID with id that does not exist
        ///</summary>
        [TestMethod()]
        public void getRoleByIDTest2()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value
            int roleID = 30; // TODO: Initialize to an appropriate value

            Assert.IsNull(target.getRoleByID(roleID), "Role was found");
        }


        /// <summary>
        ////A test for getRoleByID with id with negative numeric
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void getRoleByIDTest3()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value
            int roleID = -5; // TODO: Initialize to an appropriate value

            try
            {

                target.getRoleByID(roleID);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        ////A test for getRoleByID with id with negative numeric
        ///</summary>
        //[TestMethod()]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void getBoundary1()
        //{
        //    UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value
        //    int roleID = 15; // TODO: Initialize to an appropriate value

        //    try
        //    {
        //        target.getRoleByID(roleID);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void getBoundary0()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value
            int roleID = 0; // TODO: Initialize to an appropriate value

            try
            {

                target.getRoleByID(roleID);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region tests for get all roles
        /// <summary>
        ///A test for getAllRoles_UserManagement
        ///</summary>
        [TestMethod()]
        public void getAllRoles_UserManagementTest()
        {
            UserRepositry target = new UserRepositry(); // TODO: Initialize to an appropriate value

            IEnumerable<Role> expected = entities.Roles.ToList();
            IEnumerable<Role> actual = target.getAllRoles_UserManagement();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).RoleName, actual.ElementAt(i).RoleName, "Not the same");
            }

        }

        #endregion
    }
}
