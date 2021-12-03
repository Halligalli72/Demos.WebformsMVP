using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
using Moq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class UserProfilePresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public UserProfilePresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SampleTest()
        {
            //Arrange
            var viewMock = new UserProfileViewMock();
            var svcMock = new Mock<IUserInfoService>();
            var testTarget = new UserProfilePresenter(viewMock, svcMock.Object);
            //Act

            //Assert

        }








        internal class UserProfileViewMock : IUserProfileView
        {
            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public string ExistingUserName => throw new System.NotImplementedException();

            public string UserNameInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string NameInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public string SelectedTeam => throw new System.NotImplementedException();

            public string TeamNameInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string DepartmentInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public bool ResultsArePublicInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public void DisplayErrorMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayInfoMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayUserProfileInformation()
            {
                throw new System.NotImplementedException();
            }

            public void EnableLogoutFunction()
            {
                throw new System.NotImplementedException();
            }

            public void InitAvailableTeams(IList<string> teamNames)
            {
                throw new System.NotImplementedException();
            }

            public void RedirectAfterUpdateOK()
            {
                throw new System.NotImplementedException();
            }

            public void RedirectToLoginPage()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
