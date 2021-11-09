using Demos.WebformsMVP.BusinessLogic.BusinessObjects;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.WebformsMVP.BusinessLogic
{
    public static class Factory
    {
        public static IUserInfo CreateUserInfo()
        {
            return new UserInfo();
        }
        public static IActivity CreateActivity()
        {
            return new Activity();
        }

        public static IActivityType CreateActivityType()
        {
            return new ActivityType();
        }
    }
}
