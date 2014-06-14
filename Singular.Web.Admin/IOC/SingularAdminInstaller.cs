using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Singular.Configuration;

namespace Singular.Web.Admin.IOC
{
    public class SingularAdminInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
            
                // controllers
                Classes
                .FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient()
                
                
            );

            
        }
    }
}