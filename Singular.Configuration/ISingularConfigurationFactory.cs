using System;
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
        IList<IWindsorInstaller> ControllerInstallers { get; set; }

        /// <summary>
        /// Installers
        /// </summary>
        IList<IWindsorInstaller> WebApiControllerInstallers { get; set; }

        /// <summary>
        /// App start methods
        /// </summary>
        IList<Action> AppStartMethods { get; set; }

        /// <summary>
        /// Add installer
        /// </summary>
        /// <param name="installer"></param>
        void AddControllerInstaller(IWindsorInstaller installer);

        /// <summary>
        /// Add web api installer
        /// </summary>
        /// <param name="installer"></param>
        void AddWebApiControllerInstaller(IWindsorInstaller installer);

        /// <summary>
        /// Node types
        /// </summary>
        IList<NodeTypeDefinition> NodeTypes { get; set; }
    }
}