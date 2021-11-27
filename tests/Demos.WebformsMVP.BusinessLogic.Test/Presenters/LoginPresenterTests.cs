using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Presenters;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class LoginPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;

        public LoginPresenterTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void SampleTest() 
        {
            //Arrange
            var viewMock = new MockLoginView();
            var svcMock = new Mock<IUserInfoService>();
            svcMock.Setup(m => m.GetByUsername("testuser"))
                .Returns(new Mock<IUserInfo>().Object);
            var testTarget = new LoginPresenter(viewMock, svcMock.Object);
            //Act

            //Assert
            Assert.True(true);
        }






        internal class MockLoginView : ILoginView
        {
            private string _userName;

            public bool BeenRedirected { get; private set; }
            public string DisplayedInfoMessage { get; private set; }
            public string DisplayedErrorMessage { get; private set; }

            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public string UserNameInput { get => _userName; set => _userName = value; }

            public void DisplayErrorMessage(string msg)
            {
                DisplayedErrorMessage = msg;
            }

            public void DisplayInfoMessage(string msg)
            {
                DisplayedInfoMessage=msg;
            }

            public void RedirectAlreadyLoggedIn()
            {
                BeenRedirected = true;
            }

            public void RedirectLoginOK()
            {
                BeenRedirected = true;
            }
        }

    }
}
