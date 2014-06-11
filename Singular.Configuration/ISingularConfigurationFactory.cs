using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Castle.MicroKernel.Registration;

namespace Singular.Configuration
{
    /// <summary>
    /// Config factory
    /// </summary>
    public interface ISingularConfigurationFactory
    {
        /// <summary>
        /// Init
        /// </summary>
        void Init();

        /// <summary>
        /// Applications
        /// </summary>
        IList<ApplicationConfigurationModel> ApplicationsWithConfiguration { get; }

        /// <summary>
        /// Applications
        /// </summary>
        IList<SingularApplicationBase> Applications { get; }

        /// <summary>
        /// Master application
        /// </summary>
        SingularApplicationBase MasterApplication { get; }

        /// <summary>
        /// Installers
        /// </summary>
        IList<IWindsorInstaller> Installers { get; set; }

        /// <summary>
        /// Add installer
        /// </summary>
        /// <param name="installer"></param>
        void AddInstaller(IWindsorInstaller installer);
    }
}