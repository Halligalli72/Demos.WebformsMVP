using Demos.WebformsMVP.BusinessLogic;
using Demos.WebformsMVP.BusinessLogic.BusinessObjects;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demos.WebformsMVP.WebUI.Views
{
    public class DemoBasePage : System.Web.UI.Page
    {
        public IUserInfo LoggedInUser
        {
            get
            {
                if (Session[Constants.UserObjectKey] == null)
                    return Factory.CreateUserInfo();
                else
                    return  Session[Constants.UserObjectKey] as IUserInfo;
            }
            set
            {
                Session[Constants.UserObjectKey] = value;
            }
        }
    }
}