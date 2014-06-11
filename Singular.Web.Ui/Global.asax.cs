using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Singular.Configuration;
using Singular.Web.Ui.IOC;

namespace Singular.Web.Ui
{
    public class Global : HttpApplication
    {
        /// <summary>
        /// Windsor container
        /// </summary>
        private static IWindsorContainer _container;

        /// <summary>
        /// Bootstrap container
        /// </summary>
        private static void bootstrapContainer()
        {
            // initialise singular config
            SingularConfigurationFactory.Current.Init();

            // add installer from this project
            SingularConfigurationFactory.Current.AddInstaller(new ControllersInstaller());

            // create container, adding all installers
            _container = new WindsorContainer().Install(SingularConfigurationFactory.Current.Installers.ToArray());

            // create controller factory
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);

            // set controller factory
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        /// <summary>
        /// App start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            bootstrapContainer();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}