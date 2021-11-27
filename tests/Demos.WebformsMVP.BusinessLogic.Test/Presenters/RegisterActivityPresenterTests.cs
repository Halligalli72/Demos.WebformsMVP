using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Moq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class RegisterActivityPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public RegisterActivityPresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SampleTest()
        {
            //Arrange
            var viewMock = new RegisterActivityViewMock();
            var actSvcMock = new Mock<IActivityService>();
            var actTypeSvcMock = new Mock<IActivityTypeService>();
            var testTarget = new RegisterActivityPresenter(viewMock, actSvcMock.Object, actTypeSvcMock.Object);
            //Act

            //Assert

        }





        internal class RegisterActivityViewMock : IRegisterActivityView
        {
            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string UserName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public int SelectedActivityIdInput => throw new System.NotImplementedException();

            public string OtherActivityNameInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string ActivityDateInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public int DurationInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public void DisplayErrorMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayInfoMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void InitAvailableActivityTypes(IList<IActivityType> activityTypes)
            {
                throw new System.NotImplementedException();
            }

            public void RedirectAfterSaveOK()
            {
                throw new System.NotImplementedException();
            }

            public void RedirectToLoginView()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
