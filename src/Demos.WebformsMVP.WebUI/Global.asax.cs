using Autofac;
using Autofac.Integration.Web;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
using Demos.WebformsMVP.DataAccess.Repositories;
using System;

namespace Demos.WebformsMVP.WebUI
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        /// <summary>
        /// Added for Autofac DI integration
        /// </summary>
        static IContainerProvider _containerProvider;

        protected void Application_Start(object sender, EventArgs e)
        {
            #region Autofac DI Container setup
            // Autofac DI Reference: https://autofac.readthedocs.io/en/latest/integration/webforms.html?highlight=web%20forms#web-forms
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            //Register EF DbContext
            builder.RegisterType<WebformsDemoDbContext>().As<IDbContext>().InstancePerRequest();
            //Register Repositories
            builder.RegisterType<UserProfileRepository>().As<IUserProfileRepository>().InstancePerRequest();
            builder.RegisterType<ActivityRepository>().As<IActivityRepository>().InstancePerRequest();
            builder.RegisterType<ActivityTypeRepository>().As<IActivityTypeRepository>().InstancePerRequest();
            //Register Services
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().InstancePerRequest();
            builder.RegisterType<ActivityService>().As<IActivityService>().InstancePerRequest();
            builder.RegisterType<ActivityTypeService>().As<IActivityTypeService>().InstancePerRequest();

            // Once you're done registering things, set the container provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());
            #endregion
        }

        /// <summary>
        /// Added for Autofac DI integration
        /// </summary>
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}