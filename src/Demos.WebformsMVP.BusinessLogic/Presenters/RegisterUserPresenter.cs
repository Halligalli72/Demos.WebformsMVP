using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class RegisterUserPresenter
    {
        private IRegisterUserView _view;
        private IUserInfoService _service;

        public RegisterUserPresenter(DataAccess.IDbContext dbCtx, IRegisterUserView view)
        {
            _view = view;
            _service = new UserInfoService(dbCtx);
        }

        public IRegisterUserView View
        {
            get { return _view; }
        }

        public void InitView(IUserInfo userinfo, string alternateUsername)
        {
            View.InitAvailableTeams(_service.GetAllTeamNames());
            if (userinfo.UserName.Length > 0)
            {
                View.RedirectToProfilePage();
            }
            else
            {
                View.UserNameInput = alternateUsername;
                View.DisplayInfoMessage("Fill in the registration form");
            }

        }

        public void HandleRegisterNewUserAction() 
        {
            //Do validations here
            string objections = validateRequredInput(View);
            if (objections.Length == 0)
            {
                IUserInfo user = Factory.CreateUserInfo();
                user.UserName = View.UserNameInput;
                user.Name = View.NameInput;
                //Selected team or new?
                if (View.SelectedTeam != string.Empty)
                    user.TeamName = View.SelectedTeam;
                else
                    user.TeamName = View.TeamNameInput;
                user.Department = View.DepartmentInput;
                user.ResultsArePublic = View.ResultsArePublicInput;
                _service.CreateUser(user);
                View.RedirectToProfilePage();
            }
            else
            {
                View.DisplayErrorMessage(objections);
            }
        }

        private string validateRequredInput(IRegisterUserView view)
        {
            string objections = string.Empty;
            if (view.UserNameInput.Trim().Length == 0)
                objections += "Username is mandatory!" + Environment.NewLine;
            if (view.NameInput.Trim().Length == 0)
                objections += "Name is mandatory!" + Environment.NewLine;

            return objections;
        }
    }
}
