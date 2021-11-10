using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Interfaces
{
    public interface IUserProfileView
    {
        IUserInfo LoggedInUser { get; set; }
        string ExistingUserName { get; }
        string UserNameInput { get; set; }
        string NameInput { get; set; }
        string SelectedTeam { get; }
        string TeamNameInput { get; set; }
        string DepartmentInput { get; set; }
        bool ResultsArePublicInput { get; set; }


        void InitAvailableTeams(IList<string> teamNames);

        void EnableLogoutFunction();

        void DisplayInfoMessage(string msg);

        void DisplayErrorMessage(string msg);

        void DisplayUserProfileInformation();

        void RedirectToLoginPage();

        void RedirectAfterUpdateOK();
    }
}
