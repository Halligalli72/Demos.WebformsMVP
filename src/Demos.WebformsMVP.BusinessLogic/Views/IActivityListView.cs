using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System.Collections.Generic;

namespace Demos.WebformsMVP.BusinessLogic.Views
{
    public interface IActivityListView
    {
        IUserInfo LoggedInUser { get; set; }

        string ListHeader { get; set; }

        void DisplayActivities(IList<IActivity> activities);

        void DisplayInfoMessage(string msg);

        void DisplayErrorMessage(string msg);
        void RedirectToLoginView();
    }
}
