using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.MicroKernel.Registration;
using Singular.Common;

namespace Singular.Configuration
{
    /// <summary>
    /// Config
    /// </summary>
    public class SingularConfigurationFactory : ISingularConfigurationFactory
    {
        /// <summary>
        /// Interface type
        /// </summary>
        private readonly Type _appBaseType = typeof(SingularApplicationBase);

        /// <summary>
        /// Singleton constructor
        /// </summary>
        private SingularConfigurationFactory()
        {
            
        }

        /// <summary>
        /// Init
        /// </summary>
        public void Init()
        {
            setAssemblies();
            setApplications();
            setMasterApplication();
        }

        /// <summary>
        /// Set assemblies
        /// </summary>
        private void setAssemblies()
        {
            _assemblies = new List<Assembly>();

            var pathToBin = System.AppDomain.CurrentDomain.BaseDirectory;

            if (!pathToBin.Contains("bin")) pathToBin = Path.Combine(pathToBin, "bin");

            foreach (var dllPath in Directory.GetFiles(pathToBin, "*.dll"))
            {
                var assemblyName = AssemblyName.GetAssemblyName(dllPath);
                var assembly = Assembly.Load(assemblyName);
                _assemblies.Add(assembly);
            }
        }

        /// <summary>
        /// Set applications
        /// </summary>
        private void setApplications()
        {
            // set data store
            ApplicationsWithConfiguration = new List<ApplicationConfigurationModel>();

            // loop assemblies
            foreach (var assembly in _assemblies)
            {
                // find application types
                var appTypes = assembly.GetTypes().Where(x => x.IsSubclassOf(_appBaseType));

                // loop them and add
                foreach (var appType in appTypes)
                {
                    var rootConfig = new SingularApplicationConfigurationRoot();

                    var app = (SingularApplicationBase)Activator.CreateInstance(appType);

                    rootConfig.Application = app;

                    app.Configure(rootConfig);

                    ApplicationsWithConfiguration.Add(new ApplicationConfigurationModel
                    {
                        Application = app,
                        ConfigurationRoot = rootConfig
                    });
                }
            }

            // Set applications on this object
            Applications = ApplicationsWithConfiguration.Select(x => x.Application).ToList();

            // Set admin sections on this object
            AdminSections = Applications.SelectMany(x => x.AdminSections).ToList();

            // set controller installers
            Applications.ForEach(x =>
            {
                if (x.ControllerInstaller != null) AddControllerInstaller(x.ControllerInstaller);
            });

            // set web api controller installers
            Applications.ForEach(x =>
            {
                if (x.WebApiControllerInstaller != null) AddWebApiControllerInstaller(x.WebApiControllerInstaller);
            });

            // set app start methods
            AppStartMethods = Applications.Where(x=>x.AppStartMethod != null).Select(x => x.AppStartMethod).ToList();

            // node types
            NodeTypes = Applications.SelectMany(x => x.NodeTypes).OrderBy(x => x.Name).ToList();
            foreach (var def in NodeTypes)
            {
                if (!string.IsNullOrEmpty(def.AllowedChildTypeMagicNames))
                {
                    var allowedTypes = new List<NodeTypeDefinition>();
                    foreach (var magicName in def.AllowedChildTypeMagicNames.Split(','))
                    {
                        // find
                        var found = NodeTypes.FirstOrDefault(x => x.MagicName == magicName);
                        if (found != null) allowedTypes.Add(found.SlowParameterlessConstructorClone());
                        def.AllowedChildTypes = allowedTypes.OrderBy(x=>x.Name).ToList();
                    }
                }
            }

        }

        /// <summary>
        /// Set master app (or error)
        /// </summary>
        private void setMasterApplication()
        {
            // check error
            var isTooManyError = ApplicationsWithConfiguration.Count(x => x.Application.IsMasterApplication) > 1;
            if (isTooManyError) throw new Exception("Too many master applications");
            var isTooFewError = ApplicationsWithConfiguration.Count(x => x.Application.IsMasterApplication) < 1;
            if (isTooFewError) throw new Exception("No master application");

            // set master
            MasterApplication = ApplicationsWithConfiguration.Single(x => x.Application.IsMasterApplication).Application;
        }

        /// <summary>
        /// Assemblies
        /// </summary>
        private IList<Assembly> _assemblies;

        /// <summary>
        /// Singleton backing field
        /// </summary>
        private static ISingularConfigurationFactory _current;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static ISingularConfigurationFactory Current
        {
            get { return _current ?? (_current = new SingularConfigurationFactory()); }
        }

        /// <summary>
        /// Applications
        /// </summary>
        public IList<ApplicationConfigurationModel> ApplicationsWithConfiguration { get; private set; }

        /// <summary>
        /// Apps
        /// </summary>
        public IList<SingularApplicationBase> Applications { get; private set; }

        /// <summary>
        /// Master application
        /// </summary>
        public SingularApplicationBase MasterApplication { get; private set; }

        /// <summary>
        /// Controller installers
        /// </summary>
        public IList<IWindsorInstaller> ControllerInstallers { get; set; }

        /// <summary>
        /// Installers
        /// </summary>
        public IList<IWindsorInstaller> WebApiControllerInstallers { get; set; }

        /// <summary>
        /// App start methods
        /// </summary>
        public IList<Action> AppStartMethods { get; set; }

        /// <summary>
        /// Add installer
        /// </summary>
        /// <param name="installer"></param>
        public void AddControllerInstaller(IWindsorInstaller installer)
        {
            if (ControllerInstallers == null) ControllerInstallers = new List<IWindsorInstaller>();
            ControllerInstallers.Add(installer);
        }

        /// <summary>
        /// Add web api installers
        /// </summary>
        /// <param name="installer"></param>
        public void AddWebApiControllerInstaller(IWindsorInstaller installer)
        {
            if (WebApiControllerInstallers == null) WebApiControllerInstallers = new List<IWindsorInstaller>();
            WebApiControllerInstallers.Add(installer);
        }

        /// <summary>
        /// Node types
        /// </summary>
        public IList<NodeTypeDefinition> NodeTypes { get; set; }

        /// <summary>
        /// Admin sections
        /// </summary>
        public IList<SingularAdminSection> AdminSections { get; set; }
    }
}