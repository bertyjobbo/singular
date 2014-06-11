using System;
using Singular.Configuration;
using Singular.Web.Admin.Defaults;
using Singular.Web.Admin.IOC;

namespace Singular.Web.Admin.Configuration
{
    /// <summary>
    /// Admin app config
    /// </summary>
    public class SingularAdminApplication : SingularApplicationBase
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="config"></param>
        public override void Configure(SingularApplicationConfigurationRoot config)
        {
            config

                .IsMasterApplication()

                .HasInstaller(new SingularAdminInstaller())

                .IsNamed(SingularAdminDefaults.APP_NAME)

                .HasAdminSection(x =>
                {
                    x.Name = "Home";
                    x.Controller = "home";
                    x.Action = "index";
                })

                .HasAdminSection(x =>
                {
                    x.Name = "Content";
                    x.Controller = "content";
                    x.Action = "index";
                });
        }

        /// <summary>
        /// Application ID
        /// </summary>
        public override Guid ApplicationId
        {
            get { return SingularAdminDefaults.AppId; }
        }
    }
}