﻿using System;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demos.WebformsMVP.BusinessLogic.Test.Services
{
    [TestClass]
    public class ActivityServiceTests
    {
        [TestMethod]
        public void CreateActivityTypeTest()
        {
            try
            {
                //Arrange
                IActivityTypeService target = new ActivityTypeService();
                IActivityType newAct = Factory.CreateActivityType();
                newAct.ActivityName = "Power walk";
                newAct.Steps = 50;
                newAct.IsActivated = true;

                //Act
                IActivityType createdAct = target.Create(newAct);

                //Assert
                Assert.AreEqual(newAct.ActivityName, createdAct.ActivityName);
                Assert.AreEqual(newAct.Steps, createdAct.Steps);
                Assert.AreEqual(newAct.IsActivated, createdAct.IsActivated);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
