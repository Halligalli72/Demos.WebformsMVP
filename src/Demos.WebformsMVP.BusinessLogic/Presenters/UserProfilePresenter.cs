using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class UserProfilePresenter
    {
        private IUserProfileView _view;
        private IUserInfoService _service;

        public UserProfilePresenter(DataAccess.IDbContext dbCtx, IUserProfileView view)
        {
            _view = view;
            _service = new UserInfoService(dbCtx);
        }

        public IUserProfileView View
        {
            get { return _view; }
        }

        public void InitView(IUserInfo userinfo)
        {
            View.InitAvailableTeams(_service.GetAllTeamNames());
            if (userinfo.UserName.Length > 0)
            {
                //User is already logged in
                View.LoggedInUser = userinfo;
                View.DisplayUserProfileInformation();
                View.EnableLogoutFunction();
            }
            else
            {
                View.RedirectToLoginPage();
            }
        }

        public void HandleUpdateUserProfile()
        {
            //TODO: Add validations here
            IUserInfo newUserInfo = Factory.CreateUserInfo();
            newUserInfo.UserName = View.UserNameInput;
            newUserInfo.Name = View.NameInput;
            //Selected team or new?
            if (View.SelectedTeam != string.Empty)
                newUserInfo.TeamName = View.SelectedTeam;
            else
                newUserInfo.TeamName = View.TeamNameInput;
            newUserInfo.Department = View.DepartmentInput;
            newUserInfo.ResultsArePublic = View.ResultsArePublicInput;
            //update and refresh view
            View.LoggedInUser = _service.UpdateUser(View.ExistingUserName, newUserInfo);
            View.RedirectAfterUpdateOK();
        }

        public void HandleLogoutUser()
        {
            //Do logout
            
        }
    }
}
