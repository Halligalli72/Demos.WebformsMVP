using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.BusinessLogic.Test.Extensions;
using Demos.WebformsMVP.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class UserInfoServiceTests : BaseTest
    {

        [TestMethod]
        public void CreateUserTest()
        {
            try
            {
                //Arrange
                IUserInfoService target = CreateTestTarget();
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
                IUserInfoService target = CreateTestTarget();
                const bool includeAdmins = false;
                //Act
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
                IUserInfoService target = CreateTestTarget();
                //Act
                IList<IUserInfo> result = target.GetAdminUsers();
                //Assert
                Assert.IsNotNull(result, "Method returned null!");
                foreach (var item in result)
                {
                    Assert.IsTrue(item.IsAdmin, "Only Admins were supposed to be fetched!");
                }

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
                IUserInfoService target = CreateTestTarget();
                const string filter = "TestTeam";
                //Act
                IList<IUserInfo> result = target.GetByTeam(filter);
                Assert.IsNotNull(result,"Method returned null!");
                //Assert
                foreach (var item in result)
                {
                    Assert.AreEqual(filter, item.TeamName, "Mixed teams fetched!");
                }
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
                IUserInfoService target = CreateTestTarget();
                //Act
                IList<string> result = target.GetAllTeamNames();
                //Assert
                Assert.IsNotNull(result, "Method returned null!");
                const int expectedCount = 2;
                Assert.AreEqual(expectedCount, result.Count);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }




        private UserInfoService CreateTestTarget()
        {
            Mock<IDbContext> ctxMock = CreateEmptyDbContext();
            var users = new List<UserProfile> 
            {
                new UserProfile() { UserProfileId = 1, UserName = "TestUserName", Name = "TestName", Department = "TestDepartment", Team = "TestTeam", IsAdmin = false },
                new UserProfile() { UserProfileId = 2, UserName = "AdminUserName", Name = "AdminName", Department = "AdminDepartment", Team = "AdminTeam", IsAdmin = false },
            };
            ctxMock.AddEntities(users.ToArray());
            return new UserInfoService(new UserProfileRepository(ctxMock.Object));
        }
    }
}
