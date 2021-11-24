using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Demos.WebformsMVP.DataAccess.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    public class UserInfoServiceTests : BaseTest
    {
        private readonly ITestOutputHelper _output;
        private IDbContext _dbCtx;

        public UserInfoServiceTests(ITestOutputHelper output)
        {
            _output = output;
            _dbCtx = CreateSimpleTestContext();
        }

        private UserInfoService CreateTestTarget(IDbContext dbCtx) 
        {
            var repo = new UserProfileRepository(dbCtx);
            return new UserInfoService(repo);
        }

        [Fact]
        public void GetAllUsersTest()
        {
            var target = CreateTestTarget(_dbCtx);
            var result = target.GetAllUsers(includeAdmins:true);
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void GetAdminUsersTest() 
        {
            var target = CreateTestTarget(_dbCtx);
            var result = target.GetAdminUsers();
            Assert.True(result.Count == 1);
        }

        [Fact]
        public void GetByTeamTest() 
        {
            var target = CreateTestTarget(_dbCtx);
            const string filter = "TestTeam";
            var result = target.GetByTeam(filter);
            foreach (var user in result)
            {
                Assert.Equal(filter, user.TeamName);
            }
        }

        [Fact]
        public void GetAllTeamNamesTest() 
        {
            var target = CreateTestTarget(_dbCtx);
            var result = target.GetAllTeamNames();
            Assert.NotNull(result);
            const int expectedCount = 2;
            Assert.Equal(expectedCount, result.Count);
        }

        [Fact]
        public void CreateUserTest() 
        {
            var target = CreateTestTarget(_dbCtx);
            IUserInfo newUser = Factory.CreateUserInfo();
            newUser.UserName = "dummyuser";
            newUser.Name = "User Testuser";
            newUser.IsAdmin = false;
            newUser.ResultsArePublic = true;
            newUser.TeamName = "Test team";
            newUser.Department = "Testing";
            //Act
            IUserInfo createdUser = target.CreateUser(newUser);
            //Assert
            Assert.True(createdUser.ID > 0);
            Assert.Equal(newUser.UserName, createdUser.UserName);
            Assert.Equal(newUser.Name, createdUser.Name);
            Assert.Equal(newUser.IsAdmin, createdUser.IsAdmin);
            Assert.Equal(newUser.ResultsArePublic, createdUser.ResultsArePublic);
            Assert.Equal(newUser.TeamName, createdUser.TeamName);
            Assert.Equal(newUser.Department, createdUser.Department);
        }

    }

}
