using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Demos.WebformsMVP.DataAccess.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    public class ActivityServiceTests : BaseTest
    {
        private readonly ITestOutputHelper _output;
        private IDbContext _dbCtx;

        public ActivityServiceTests(ITestOutputHelper output)
        {
            _output = output;
            _dbCtx = CreateSimpleTestContext();
        }

        private ActivityService CreateTestTarget(IDbContext dbCtx)
        {
            var repo = new ActivityRepository(dbCtx);
            return new ActivityService(repo);
        }

        [Fact]
        public void GetAllActivitiesTest()
        {
            var target = CreateTestTarget(_dbCtx);
            const int userId = 1;
            var result = target.GetByUserProfileId(userId);
            foreach (var act in result)
            {
                Assert.Equal(userId,act.UserProfileId);
            }
        }




    }
}
