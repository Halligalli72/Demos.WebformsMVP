using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Demos.WebformsMVP.BusinessLogic.Views;
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
        public void AlreadyRegisteredUserShouldBeRedirectedToProfilePage()
        {
            //Arrange
            var userMock = new Mock<IUserInfo>();
            userMock.Setup(u => u.UserName).Returns("TestUserName");
            var viewMock = new RegisterUserViewMock();
            var svcMock = new Mock<IUserInfoService>();
            svcMock.Setup(s => s.GetAllTeamNames()).Returns(new string[] { "Team 1", "Team 2", "Team 3" });
            var testTarget = new RegisterUserPresenter(viewMock, svcMock.Object);
            //Act
            testTarget.InitView(userMock.Object, alternateUsername: string.Empty);
            //Assert
            Assert.True(viewMock.BeenRedirectedToProfilePage);
        }

        [Fact]
        public void NotRegisteredUserShouldBeDisplayedRegistrationForm()
        {
            //Arrange
            const string altUsername = "MyUserName";
            var userMock = new Mock<IUserInfo>();
            userMock.Setup(u => u.UserName).Returns(string.Empty);
            var viewMock = new RegisterUserViewMock();
            var svcMock = new Mock<IUserInfoService>();
            svcMock.Setup(s => s.GetAllTeamNames()).Returns(new string[] { "Team 1", "Team 2", "Team 3" });
            var testTarget = new RegisterUserPresenter(viewMock, svcMock.Object);
            //Act
            testTarget.InitView(userMock.Object, altUsername);
            //Assert
            Assert.False(viewMock.BeenRedirectedToProfilePage);
            Assert.True(viewMock.AvailableTeams.Count > 0);
            Assert.Equal(altUsername, viewMock.UserNameInput);
            Assert.Equal("Fill in the registration form", viewMock.DisplayedInfoMessage);
        }





        internal class RegisterUserViewMock : IRegisterUserView
        {
            public bool BeenRedirectedToProfilePage { get; private set; } = false;
            public string DisplayedInfoMessage { get; private set; }
            private string _userNameInput;
            public IList<string> AvailableTeams { get; private set; }
            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
            public string UserNameInput { get { return _userNameInput; } set { _userNameInput = value; } }
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
                DisplayedInfoMessage = msg;
            }

            public void InitAvailableTeams(IList<string> teamNames)
            {
                AvailableTeams = teamNames;
            }

            public void RedirectToProfilePage()
            {
                BeenRedirectedToProfilePage = true;
            }
        }
    }
}
