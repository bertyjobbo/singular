﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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

            var pathToBin = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var dllPath in Directory.GetFiles(pathToBin,"*.dll"))
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
                    
                    var app = (SingularApplicationBase) Activator.CreateInstance(appType);
                    
                    rootConfig.Application = app;
                    
                    app.Configure(rootConfig);
                    
                    ApplicationsWithConfiguration.Add(new ApplicationConfigurationModel
                    {
                        Application = app,
                        ConfigurationRoot = rootConfig
                    });
                }
            }

            // finally
            Applications = ApplicationsWithConfiguration.Select(x => x.Application).ToList();
        }

        /// <summary>
        /// Set master app (or error)
        /// </summary>
        private void setMasterApplication()
        {
            // check error
            var isTooManyError = ApplicationsWithConfiguration.Count(x => x.Application.IsMasterApplication) > 1;
            if(isTooManyError) throw new Exception("Too many master applications");
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
    }
}