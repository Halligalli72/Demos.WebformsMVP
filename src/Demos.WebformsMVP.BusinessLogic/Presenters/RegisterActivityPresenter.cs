using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class RegisterActivityPresenter
    {
        private IRegisterActivityView _view;
        private IActivityService _activityService;
        private IActivityTypeService _activityTypeService;

        public RegisterActivityPresenter(DataAccess.IDbContext dbCtx, IRegisterActivityView view)
        {
            _view = view;
            _activityService = new ActivityService();
            _activityTypeService = new ActivityTypeService(dbCtx);
        }
        public IRegisterActivityView View
        {
            get { return _view; }
        }

        public void InitView()
        {
            if (View.LoggedInUser.ID == 0)
                View.RedirectToLoginView();

            View.UserName = View.LoggedInUser.UserName;
            View.ActivityDateInput = DateTime.Now.ToShortDateString();
            View.InitAvailableActivities(_activityTypeService.GetAll(false));
            View.DurationInput = 30;
        }

        public void HandleSaveAction()
        {
            // Do validations here
            string objections = validateRequiredInput(View);
            if (objections.Length == 0)
            {
                IActivity act = Factory.CreateActivity();
                act.Performer = View.LoggedInUser;
                act.UserProfileId = View.LoggedInUser.ID;
                act.ActivityDate = DateTime.Parse(View.ActivityDateInput);
                act.ActivityTypeId = View.SelectedActivityIdInput;
                act.OtherActivity = View.OtherActivityNameInput;
                act.Duration = View.DurationInput;
                _activityService.Save(act);
                View.RedirectAfterSaveOK();
            }
            else
            {
                View.DisplayErrorMessage(objections);
            }
        }

        private string validateRequiredInput(IRegisterActivityView view)
        {
            string objections = string.Empty;
            if (DateTime.Parse(view.ActivityDateInput) > DateTime.Now)
                objections += "Future date is not permitted!" + Environment.NewLine;
            if (view.SelectedActivityIdInput == 0)
                objections += "Activity is mandatory! (Choose 'Other' if you can't find an appropriate type)" + Environment.NewLine;

            return objections;
        }
    }
}
