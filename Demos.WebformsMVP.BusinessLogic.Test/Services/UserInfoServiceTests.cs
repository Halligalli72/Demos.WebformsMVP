using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using System.Collections.Generic;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class UserInfoServiceTests
    {
        [TestMethod]
        public void CreateUserTest()
        {
            try
            {
                IUserInfoService target = new UserInfoService();
                IUserInfo newUser = Factory.CreateUserInfo();
                IUserInfo createdUser = target.CreateUser(newUser);
                //TODO:Check that equal
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
                IUserInfoService target = new UserInfoService();
                bool includeAdmins = false;
                IList<IUserInfo> result = target.GetAllUsers(includeAdmins);
                Assert.IsNotNull(result, "Method returned null!");
                //TODO:Check that only non-admins where fetched
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
                IUserInfoService target = new UserInfoService();
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
                IUserInfoService target = new UserInfoService();
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
                IUserInfoService target = new UserInfoService();
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
