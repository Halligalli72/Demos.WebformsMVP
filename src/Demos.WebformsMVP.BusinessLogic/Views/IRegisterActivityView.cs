using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace Demos.WebformsMVP.BusinessLogic.Views
{
    public interface IRegisterActivityView
    {
        IUserInfo LoggedInUser { get; set; }
        string UserName { get; set; }
        int SelectedActivityIdInput { get; }
        string OtherActivityNameInput { get; set; }
        string ActivityDateInput { get; set; }
        int DurationInput { get; set; }


        void InitAvailableActivityTypes(IList<IActivityType> activityTypes);
        
        void DisplayInfoMessage(string msg);

        void DisplayErrorMessage(string msg);

        void RedirectAfterSaveOK();
        void RedirectToLoginView();
    }
}
