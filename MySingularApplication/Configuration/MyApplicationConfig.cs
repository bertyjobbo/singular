using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySingularApplication.Defaults;
using MySingularApplication.IOC;
using Singular.Configuration;

namespace MySingularApplication.Configuration
{
    /// <summary>
    /// My app config
    /// </summary>
    public class MyApplicationConfig : SingularApplicationBase
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="config"></param>
        public override void Configure(SingularApplicationConfigurationRoot config)
        {
            config
                .HasInstaller(new MySingularInstaller());
        }


        /// <summary>
        /// App id
        /// </summary>
        public override Guid ApplicationId
        {
            get
            {
                return MySingularDefaults.AppId; 
            }
        }
    }
}