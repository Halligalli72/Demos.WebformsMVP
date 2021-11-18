using Demos.WebformsMVP.BusinessLogic.Test.Extensions;
using Demos.WebformsMVP.DataAccess;
using Moq;

namespace Demos.WebformsMVP.BusinessLogic.Test
{
    public class BaseTest
    {
        protected Mock<IDbContext> CreateEmptyDbContext()
        {
            var ctx = new Mock<IDbContext>();
            ctx.AddEntities(new Activity());
            ctx.AddEntities(new ActivityType());
            ctx.AddEntities(new UserProfile());
            return ctx;
        }

    }
}
