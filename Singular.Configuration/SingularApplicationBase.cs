using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using Castle.MicroKernel.Registration;

namespace Singular.Configuration
{
    /// <summary>
    /// Base application class
    /// </summary>
    public abstract class SingularApplicationBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected SingularApplicationBase()
        {
            AdminSections = new List<SingularAdminSection>();
            NodeTypes = new List<NodeTypeDefinition>();
        }

        /// <summary>
        /// Root configuration
        /// </summary>
        public SingularApplicationConfigurationRoot RootConfiguration { get; set; }

        /// <summary>
        /// Is master
        /// </summary>
        public bool IsMasterApplication { get; set; }

        /// <summary>
        /// Name of app
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="config"></param>
        public abstract void Configure(SingularApplicationConfigurationRoot config);

        /// <summary>
        /// Application ID
        /// </summary>
        public abstract Guid ApplicationId { get; }

        /// <summary>
        /// Admin sections
        /// </summary>
        public IList<SingularAdminSection> AdminSections { get; private set; }

        /// <summary>
        /// Installer
        /// </summary>
        public IWindsorInstaller ControllerInstaller { get; set; }

        /// <summary>
        /// Installer
        /// </summary>
        public IWindsorInstaller WebApiControllerInstaller { get; set; }

        /// <summary>
        /// App start method
        /// </summary>
        public Action AppStartMethod { get; set; }

        /// <summary>
        /// Node types
        /// </summary>
        public IList<NodeTypeDefinition> NodeTypes { get; set; }
    }
}