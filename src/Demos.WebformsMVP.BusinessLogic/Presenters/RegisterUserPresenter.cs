using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class RegisterUserPresenter
    {
        private readonly IRegisterUserView _view;
        private readonly IUserInfoService _service;

        public RegisterUserPresenter(IRegisterUserView view, IUserInfoService userInfoSvc)
        {
            _view = view;
            _service = userInfoSvc;
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
            string objections = ValidateRequredInput(View);
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

        private string ValidateRequredInput(IRegisterUserView view)
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
