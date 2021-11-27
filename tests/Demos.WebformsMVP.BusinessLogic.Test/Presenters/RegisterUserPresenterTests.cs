using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Moq;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class RegisterUserPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public RegisterUserPresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void SampleTest()
        {
            //Arrange
            var viewMock = new RegisterUserViewMock();
            var svcMock = new Mock<IUserInfoService>();
            var testTarget = new RegisterUserPresenter(viewMock, svcMock.Object);
            //Act

            //Assert

        }






        internal class RegisterUserViewMock : IRegisterUserView
        {
            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
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

            public void InitAvailableTeams(IList<string> teamNames)
            {
                throw new System.NotImplementedException();
            }

            public void RedirectToProfilePage()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
