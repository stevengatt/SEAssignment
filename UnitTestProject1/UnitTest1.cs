using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    /// <summary>
    ///This is a test class for UserRepositoryTest and is intended
    ///to contain all UserRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserRepositoryTest
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.Role1 = "CreateTestRole";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "CreateTestRole";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Role1, actual.ElementAt(i).Role1, "Not the same");
            }

            target.deleteRole(r.RoleID);
        }

        /// <summary>
        /// Boundary test 4 char
        /// </summary>
        [TestMethod()]
        public void createBoundary4Char()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.Role1 = "Test";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "Test";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Role1, actual.ElementAt(i).Role1, "Not the same");
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = string.Empty;

            try { target.createRole(r); }
            catch { throw; }
        }


        /// <summary>
        /// Boundary test 15 char
        /// </summary>
        [TestMethod()]
        public void createBoundary15Char()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.Role1 = "qwertyuiopasdfg";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "qwertyuiopasdfg";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Role1, actual.ElementAt(i).Role1, "Not the same");
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            List<Role> expected;
            expected = entities.Roles.ToList();
            Role exRole = new Role();
            exRole.Role1 = "TheRoleIsCreated";
            expected.Add(exRole);

            List<Role> actual;

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "TheRoleIsCreated";
            target.createRole(r);


            actual = target.getAllRoles_UserManagement().ToList();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Role1, actual.ElementAt(i).Role1, "Not the same");
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "Tes";

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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "4Tfe";

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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = new Guid().ToString();

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
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "RoleChanged";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.Role1 = "RoleChanged";

            Assert.AreEqual(expected.Role1, actual.Role1);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A boundary test for editRoles with a successful update 4 char
        ///</summary>
        [TestMethod()]
        public void editBoundary4Char()
        {
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "Role";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.Role1 = "Role";

            Assert.AreEqual(expected.Role1, actual.Role1);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A boundary test for editRoles with a successful update 16 char
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editBoundary16Char()
        {
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "TheRoleIsCreated";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.Role1 = "TheRolesIsCreated";

            Assert.AreEqual(expected.Role1, actual.Role1);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A test for editRoles that does not accept numbers
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editRolesTest2()
        {
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "Role34Changed";
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
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "Role_Changed_";
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
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "Rol";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.Role1 = "Rol";

            Assert.AreEqual(expected.Role1, actual.Role1);
            target.deleteRole(actual.RoleID);
        }

        /// <summary>
        ///A boundary test for editRoles with a successful update 15 char
        ///</summary>
        [TestMethod()]
        public void editBoundary15Char()
        {
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = "THRoleIsCreated";
            target.editRoles(rCreate);

            Role actual = entities.Roles.SingleOrDefault(x => x.RoleID == rCreate.RoleID);

            Role expected = new Role();
            expected.Role1 = "THRoleIsCreated";

            Assert.AreEqual(expected.Role1, actual.Role1);
            target.deleteRole(actual.RoleID);
        }
        /// <summary>
        ///A test for editRoles that does not accept a role with 3 or less characters
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void editRolesTest5()
        {
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

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
            UserRepository target = new UserRepository();
            Role rCreate = new Role();
            rCreate.Role1 = "actualRole";

            entities.AddToRoles(rCreate);
            entities.SaveChanges();

            rCreate.Role1 = new Guid().ToString();
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            Role r = new Role(); // TODO: Initialize to an appropriate value
            r.Role1 = "CreateTestRole";
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
                Assert.AreEqual(expected.ElementAt(i).Role1, actual.ElementAt(i).Role1, "Not the same");
            }
        }

        /// <summary>
        ///A test for deleteRole when role does not exist
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void deleteRoleTest2()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            int role = 1; // TODO: Initialize to an appropriate value
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            int roleID = 1; // TODO: Initialize to an appropriate value

            Role expected = (entities.Roles.SingleOrDefault(r => r.RoleID == roleID)); // TODO: Initialize to an appropriate value
            Role actual;

            actual = (Role)target.getRoleByID(roleID);

            Assert.AreEqual(expected.Role1, actual.Role1);
        }

        /// <summary>
        //A test for getRoleByID with id that does not exist
        ///</summary>
        [TestMethod()]
        public void getRoleByIDTest2()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
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
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void getBaundary1()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
            int roleID = 1; // TODO: Initialize to an appropriate value

            try
            {

                target.getRoleByID(roleID);
            }
            catch
            {
                throw;
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void getBaundary0()
        {
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value
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
            UserRepository target = new UserRepository(); // TODO: Initialize to an appropriate value

            IEnumerable<Role> expected = entities.Roles.ToList();
            IEnumerable<Role> actual = target.getAllRoles_UserManagement();

            if (actual.Count() != expected.Count())
            {
                Assert.Fail("Lists are not the same");
            }

            for (int i = 0; i < actual.Count(); i++)
            {
                Assert.AreEqual(expected.ElementAt(i).Role1, actual.ElementAt(i).Role1, "Not the same");
            }

        }

        #endregion
    }
}
