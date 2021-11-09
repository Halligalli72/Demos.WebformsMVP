using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class ActivityListPresenter
    {
        private IActivityListView _view;
        private IActivityService _service;

        public ActivityListPresenter(IActivityListView view)
        {
            _view = view;
            _service = new ActivityService();
        }

        public IActivityListView View
        {
            get { return _view; }
        }

        public void InitView(string selection)
        {
            if (View.LoggedInUser.ID == 0)
                View.RedirectToLoginView();

            IList<IActivity> activityList = null;
            if (selection.Trim().ToLower().Equals("team"))
            {
                View.ListHeader = "Your teams activities";
                activityList = _service.GetByTeam(View.LoggedInUser.TeamName);
            }
            else if (selection.Trim().ToLower().Equals("department"))
            {
                View.ListHeader = "Your departments activities";
                activityList = _service.GetByDepartment(View.LoggedInUser.Department);
            }
            else
            {
                View.ListHeader = "Your own activities";
                activityList = _service.GetByUserProfileId(View.LoggedInUser.ID);
            }

            View.DisplayActivities(activityList);
        }

        public void HandleDeleteOfSingleActivity(int userProfileId, DateTime activityDate, int activityTypeId)
        {
            IActivity hit = _service.GetByKeys(userProfileId, activityTypeId, activityDate);
            if (hit != null)
            {
                _service.Delete(hit);
                InitView(string.Empty);
            }
            else
            {
                View.DisplayErrorMessage("Activity not found!");
            }
        }
    }
}
