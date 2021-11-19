using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class ActivityTypeServiceTests : BaseTest
    {

        [TestMethod]
        public void CreateActivityTypeTest()
        {
            //Arrange
            IActivityTypeService target = CreateTestTarget();
            IActivityType newAct = Factory.CreateActivityType();
            newAct.ActivityName = "TestActivityType";
            newAct.Steps = 11;
            newAct.IsActivated = true;

            //Act
            IActivityType createdAct = target.Create(newAct);

            //Assert
            Assert.AreEqual(newAct.ActivityName, createdAct.ActivityName);
            Assert.AreEqual(newAct.Steps, createdAct.Steps);
            Assert.AreEqual(newAct.IsActivated, createdAct.IsActivated);
        }




        private ActivityTypeService CreateTestTarget() 
        {
            Mock<IDbContext> ctxMock = CreateEmptyDbContext();
            return new ActivityTypeService(new ActivityTypeRepository(ctxMock.Object));
        }
    }
}
