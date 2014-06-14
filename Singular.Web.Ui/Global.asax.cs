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
using Castle.Core.Internal;
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
        private IWindsorContainer _container;

        /// <summary>
        /// Windsor container
        /// </summary>
        private IWindsorContainer _webApiContainer;

        /// <summary>
        /// Bootstrap container
        /// </summary>
        private void bootstrapControllersContainer()
        {
            // add installer from this project
            SingularConfigurationFactory.Current.AddControllerInstaller(new ControllersInstaller());

            // create container, adding all installers
            _container = new WindsorContainer().Install(SingularConfigurationFactory.Current.ControllerInstallers.ToArray());

            // create controller factory
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);

            // set controller factory
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        /// <summary>
        /// Bootstrap container
        /// </summary>
        private void bootstrapWebApiContainer()
        {
            // add installer from this project
            SingularConfigurationFactory.Current.AddWebApiControllerInstaller(new WebApiControllersInstaller());

            // create container, adding all installers
            _webApiContainer = new WindsorContainer().Install(SingularConfigurationFactory.Current.WebApiControllerInstallers.ToArray());

            // set 
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorWebApiDependencyResolver(_webApiContainer);
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

            // containers
            bootstrapControllersContainer();
            bootstrapWebApiContainer();

            // register areas
            AreaRegistration.RegisterAllAreas();

            // register routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // web api
            //WebApiConfig.Register(GlobalConfiguration.Configuration); //v1
            GlobalConfiguration.Configure(WebApiConfig.Register); // v2


            // fileters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // call other methods
            SingularConfigurationFactory
                .Current
                .AppStartMethods
                .ForEach(m => m.Invoke());

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