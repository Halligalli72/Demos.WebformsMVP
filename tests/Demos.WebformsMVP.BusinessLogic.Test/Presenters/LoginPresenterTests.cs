using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Demos.WebformsMVP.DataAccess.Repositories;
using Xunit;
using Xunit.Abstractions;

namespace Demos.WebformsMVP.BusinessLogic.Test.Presenters
{
    public class LoginPresenterTests : BaseTest
    {
        private readonly ITestOutputHelper _output;
        private IDbContext _dbCtx;

        public LoginPresenterTests(ITestOutputHelper output)
        {
            _output = output;
            _dbCtx = CreateSimpleTestContext();
        }




        internal class MockLoginView : ILoginView
        {
            public IUserInfo LoggedInUser { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public string UserNameInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

            public void DisplayErrorMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void DisplayInfoMessage(string msg)
            {
                throw new System.NotImplementedException();
            }

            public void RedirectAlreadyLoggedIn()
            {
                throw new System.NotImplementedException();
            }

            public void RedirectLoginOK()
            {
                throw new System.NotImplementedException();
            }
        }

    }
}
