using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Demos.WebformsMVP.DataAccess.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    public class ActivityTypeServiceTests : BaseTest 
    {
        private readonly ITestOutputHelper _output;
        private IDbContext _dbCtx;

        public ActivityTypeServiceTests(ITestOutputHelper output)
        {
            _output = output;
            _dbCtx = CreateSimpleTestContext();
        }

        private ActivityTypeService CreateTestTarget(IDbContext dbCtx)
        {
            var repo = new ActivityTypeRepository(dbCtx);
            return new ActivityTypeService(repo);
        }

        [Fact]
        public void GetAllActivityTypesTest()
        {
            var target = CreateTestTarget(_dbCtx);
            var result = target.GetAll(includeInactive: true);
            Assert.True(result.Count == 5);
        }

        [Fact]
        public void GetAllActivateActivityTypesTest()
        {
            var target = CreateTestTarget(_dbCtx);
            var result = target.GetAll(includeInactive: false);
            Assert.True(result.Count == 4);
        }


    }
}
