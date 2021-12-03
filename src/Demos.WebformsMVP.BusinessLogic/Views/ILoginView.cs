using Demos.WebformsMVP.BusinessLogic.Interfaces;

namespace Demos.WebformsMVP.BusinessLogic.Views
{
    public interface ILoginView
    {
        IUserInfo LoggedInUser { get; set; }

        string UserNameInput { get; set; }

        void DisplayInfoMessage(string msg);

        void DisplayErrorMessage(string msg);

        void RedirectLoginOK();
        void RedirectAlreadyLoggedIn();
    }
}
