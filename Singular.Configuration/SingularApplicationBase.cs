using System;
using System.Collections;
using System.Collections.Generic;

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
    }
}