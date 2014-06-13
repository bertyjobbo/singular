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
using Singular.Web.Admin;
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
            // initialise singular config
            SingularConfigurationFactory.Current.Init();

            // register areas
            AreaRegistration.RegisterAllAreas();

            // register routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // loop multi props from apps
            foreach (var app in SingularConfigurationFactory.Current.Applications)
            {
                if (app.WebApiConfigMethod != null) 
                    GlobalConfiguration.Configure(app.WebApiConfigMethod);

                // do the same for filters, model binders, etc
            }
            
            // TODO move this into loop above
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
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