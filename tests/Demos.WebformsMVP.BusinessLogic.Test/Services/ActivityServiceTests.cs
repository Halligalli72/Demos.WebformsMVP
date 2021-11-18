using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class ActivityServiceTests : BaseTest
    {
        [TestMethod]
        public void CreateActivityTest()
        {
            //TODO: Add test
            Assert.Inconclusive();
        }



        private ActivityService CreateTestTarget()
        {
            Mock<IDbContext> ctxMock = CreateEmptyDbContext();
            return new ActivityService(new DataAccess.ActivityRepository(ctxMock.Object));
        }

    }
}
