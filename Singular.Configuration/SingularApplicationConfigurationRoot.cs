using System;
using System.Web.Http;
using Castle.MicroKernel.Registration;

namespace Singular.Configuration
{
    public class SingularApplicationConfigurationRoot
    {
        /// <summary>
        /// Is master
        /// </summary>
        public SingularApplicationConfigurationRoot IsMasterApplication()
        {
            Application.IsMasterApplication = true;
            return this;
        }

        /// <summary>
        /// Application
        /// </summary>
        public SingularApplicationBase Application { get; set; }

        /// <summary>
        /// Has name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SingularApplicationConfigurationRoot IsNamed(string name)
        {
            if (!Application.IsMasterApplication) throw new Exception("Cannot name non-master application");

            Application.Name = name;

            return this;
        }

        /// <summary>
        /// Add admin section
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public SingularApplicationConfigurationRoot HasAdminSection(Action<SingularAdminSection> action)
        {
            var section = new SingularAdminSection();
            action.Invoke(section);
            Application.AdminSections.Add(section);
            return this;
        }

        /// <summary>
        /// Set installer
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public SingularApplicationConfigurationRoot HasControllerInstaller(IWindsorInstaller installer)
        {
            Application.ControllerInstaller = installer;
            return this;
        }

        /// <summary>
        /// Set installer
        /// </summary>
        /// <param name="installer"></param>
        /// <returns></returns>
        public SingularApplicationConfigurationRoot HasWebApiControllerInstaller(IWindsorInstaller installer)
        {
            Application.WebApiControllerInstaller = installer;
            return this;
        }

        /// <summary>
        /// Has app start method
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public SingularApplicationConfigurationRoot HasAppStartMethod(Action method)
        {
            Application.AppStartMethod = method;
            return this;
        }
    }
}