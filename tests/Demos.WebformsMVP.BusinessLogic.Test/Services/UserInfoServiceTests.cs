using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class UserInfoServiceTests
    {
        //TODO: Use Moq to abstract database
        const string CONNECTION_STRING = "name=WebformsMVPDemoEntities";

        [TestMethod]
        public void CreateUserTest()
        {
            try
            {
                //Arrange
                IUserInfoService target = new UserInfoService(new WebformsMVPDemoEntities(CONNECTION_STRING));
                IUserInfo newUser = Factory.CreateUserInfo();
                newUser.UserName = "testuser";
                newUser.Name = "User Testuser";
                newUser.IsAdmin = false;
                newUser.ResultsArePublic = true;
                newUser.TeamName = "Test team";
                newUser.Department = "Testing";

                //Act
                IUserInfo createdUser = target.CreateUser(newUser);

                //Assert
                Assert.AreEqual(newUser.UserName,createdUser.UserName);
                Assert.AreEqual(newUser.Name, createdUser.Name);
                Assert.AreEqual(newUser.IsAdmin, createdUser.IsAdmin);
                Assert.AreEqual(newUser.ResultsArePublic, createdUser.ResultsArePublic);
                Assert.AreEqual(newUser.TeamName, createdUser.TeamName);
                Assert.AreEqual(newUser.Department, createdUser.Department);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            try
            {
                IUserInfoService target = new UserInfoService(new WebformsMVPDemoEntities(CONNECTION_STRING));
                bool includeAdmins = false;
                IList<IUserInfo> result = target.GetAllUsers(includeAdmins);
                //Assert
                Assert.IsNotNull(result, "Method returned null!");
                foreach (var item in result)
                {
                    Assert.IsFalse(item.IsAdmin,"Admins were not supposed to be fetched!");
                }

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAdminUsersTest()
        {
            try
            {
                IUserInfoService target = new UserInfoService(new WebformsMVPDemoEntities(CONNECTION_STRING));
                IList<IUserInfo> result = target.GetAdminUsers();
                Assert.IsNotNull(result, "Method returned null!");
                //TODO:Check that only admins where fetched

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetByTeamTest()
        {
            try
            {
                IUserInfoService target = new UserInfoService(new WebformsMVPDemoEntities(CONNECTION_STRING));
                string filter = "laban";
                IList<IUserInfo> result = target.GetByTeam(filter);
                Assert.IsNotNull(result,"Method returned null!");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void GetAllTeamNamesTest()
        {
            try
            {
                IUserInfoService target = new UserInfoService(new WebformsMVPDemoEntities(CONNECTION_STRING));
                IList<string> result = target.GetAllTeamNames();
                Assert.IsNotNull(result, "Method returned null!");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
