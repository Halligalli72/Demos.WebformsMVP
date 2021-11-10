using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Interfaces
{
    public interface IRegisterActivityView
    {
        IUserInfo LoggedInUser { get; set; }
        string UserName { get; set; }
        int SelectedActivityIdInput { get; }
        string OtherActivityNameInput { get; set; }
        string ActivityDateInput { get; set; }
        int DurationInput { get; set; }


        void InitAvailableActivities(IList<IActivityType> activityTypes);
        
        void DisplayInfoMessage(string msg);

        void DisplayErrorMessage(string msg);

        void RedirectAfterSaveOK();
        void RedirectToLoginView();
    }
}
