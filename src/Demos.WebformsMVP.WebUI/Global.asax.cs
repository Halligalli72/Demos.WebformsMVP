using Autofac;
using Autofac.Integration.Web;
using Demos.WebformsMVP.BusinessLogic.Interfaces;
using Demos.WebformsMVP.BusinessLogic.Services;
using Demos.WebformsMVP.DataAccess;
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
            #region Autofac DI
            // https://autofac.readthedocs.io/en/latest/integration/webforms.html?highlight=web%20forms#web-forms
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            //builder.RegisterType<Component>().As<IService>().InstancePerRequest();
            builder.RegisterType<WebformsMVPDemoEntities>().As<IDbContext>().InstancePerRequest();
            builder.RegisterType<ActivityRepository>().As<IActivityRepository>().InstancePerRequest();
            builder.RegisterType<ActivityService>().As<IActivityService>().InstancePerRequest();

            //builder.RegisterType<SomeDependency>();
            // ... continue registering dependencies...

            // Once you're done registering things, set the container
            // provider up with your registrations.
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