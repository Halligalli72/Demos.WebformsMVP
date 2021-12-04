using Autofac.Integration.Web.Forms;
using Demos.WebformsMVP.BusinessLogic;
using Demos.WebformsMVP.BusinessLogic.Interfaces;

namespace Demos.WebformsMVP.WebUI.Views
{
    /// <summary>
    /// Autofac DI Container is setup in Global.asax.cs
    /// Autofac DI Reference: https://autofac.readthedocs.io/en/latest/integration/webforms.html?highlight=web%20forms#web-forms
    /// </summary>
    [InjectProperties]
    public class BaseView : System.Web.UI.Page
    {
        /// <summary>
        /// User info service (injected with Autofac)
        /// </summary>
        public IUserInfoService UserInfoService { get; set; }

        /// <summary>
        /// Activity service (injected with Autofac)
        /// </summary>
        public IActivityService ActivityService { get; set; }

        /// <summary>
        /// ActivityType service (injected with Autofac)
        /// </summary>
        public IActivityTypeService ActivityTypeService { get; set; }

        public IUserInfo LoggedInUser
        {
            get
            {
                if (Session[AppConstants.SessionVariables.UserObjectKey] != null)
                    return Session[AppConstants.SessionVariables.UserObjectKey] as IUserInfo; //Already "logged in"
                else
                    return Factory.CreateUserInfo();
            }
            set
            {
                Session[AppConstants.SessionVariables.UserObjectKey] = value;
            }
        }
    }
}