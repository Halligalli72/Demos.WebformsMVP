using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Interfaces
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
