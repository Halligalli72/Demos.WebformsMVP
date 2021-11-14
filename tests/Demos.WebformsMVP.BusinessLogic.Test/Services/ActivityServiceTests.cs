using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class ActivityServiceTests
    {
        [TestMethod]
        public void CreateActivityTest()
        {
            //TODO: Add test
            Assert.Inconclusive();
        }



        private ActivityService CreateTestTarget()
        {
            //TODO: Use Moq to remove dependency against database
            const string CONNECTION_STRING = "name=WebformsMVPDemoEntities";
            var dbCtx = new WebformsMVPDemoEntities(CONNECTION_STRING);
            return new ActivityService(ActivityRepository.CreateInstance(dbCtx));
        }

    }
}
