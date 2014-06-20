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
                .HasControllerInstaller(new MySingularInstaller())

                .IsNamed("My SG App!")

                .HasNodeType(x =>
                {
                    x.AllowedChildTypeMagicNames = "CONTENT_PAGE";
                    x.CanBeJson = true;
                    x.CanBePage = true;
                    x.CanBeRoot = true;
                    x.MagicName = "HOME_PAGE";
                    x.Name = "Home page";
                })

                .HasNodeType(x =>
                {
                    x.AllowedChildTypeMagicNames = "CONTENT_PAGE";
                    x.CanBeJson = true;
                    x.CanBePage = true;
                    x.CanBeRoot = false;
                    x.MagicName = "CONTENT_PAGE";
                    x.Name = "Content page";
                })
                
                ;
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