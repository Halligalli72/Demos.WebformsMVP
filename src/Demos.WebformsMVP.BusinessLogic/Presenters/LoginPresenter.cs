using Demos.WebformsMVP.BusinessLogic.Interfaces;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class LoginPresenter
    {
        private ILoginView _view;
        private IUserInfoService _service;

        public LoginPresenter(ILoginView view, IUserInfoService userInfoSvc)
        {
            _view = view;
            _service = userInfoSvc;
        }

        public ILoginView View
        {
            get { return _view; }
        }

        public void InitView(IUserInfo userinfo, string alternateUsername)
        {
            if (userinfo.UserName.Length > 0)
            {
                //User is already logged in
                View.RedirectAlreadyLoggedIn();
            }
            else
            {
                if (alternateUsername.Trim().Length > 0)
                {
                    View.UserNameInput = Helper.ExtractUserName(alternateUsername);
                }
            }

        }


        public void TryLogin()
        {
            IUserInfo userinfo = _service.GetByUsername(View.UserNameInput);
            if (userinfo.UserName.Length > 0)
            {
                View.LoggedInUser = userinfo;
                View.RedirectLoginOK();
            }
            else
            {
                View.DisplayErrorMessage("User with username '" + View.UserNameInput + "' was not found. Please go to registration page.");
            } 
        }
    }
}
