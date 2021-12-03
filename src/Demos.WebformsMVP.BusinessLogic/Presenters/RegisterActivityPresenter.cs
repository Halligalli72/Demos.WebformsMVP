using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Views;
using System;

namespace Demos.WebformsMVP.BusinessLogic.Presenters
{
    public class RegisterActivityPresenter
    {
        private readonly IRegisterActivityView _view;
        private readonly IActivityService _activityService;
        private readonly IActivityTypeService _activityTypeService;
        private const int _defaultDuration = DomainConstants.DefaultActivityDuration;

        public RegisterActivityPresenter(IRegisterActivityView view, IActivityService activitySvc, IActivityTypeService activityTypeSvc)
        {
            _view = view;
            _activityService = activitySvc;
            _activityTypeService = activityTypeSvc;
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
            View.InitAvailableActivityTypes(_activityTypeService.GetAll(false));
            View.DurationInput = _defaultDuration;
        }

        public void HandleSaveAction()
        {
            // Do validations here
            string objections = ValidateRequiredInput(View);
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

        private string ValidateRequiredInput(IRegisterActivityView view)
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
