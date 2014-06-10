using System;
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
        private readonly Type _iAppInterfaceType = typeof (ISingularApplication);

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
            Applications = new List<ISingularApplication>();

            foreach (var assembly in _assemblies)
            {
                // find application types
                var appTypes = assembly.GetTypes().Where(x => x.GetInterfaces().Contains(_iAppInterfaceType));

                // loop them and add
                foreach (var appType in appTypes)
                {
                    var app = (ISingularApplication) Activator.CreateInstance(appType);
                    Applications.Add(app);
                }
            }
        }

        /// <summary>
        /// Set master app (or error)
        /// </summary>
        private void setMasterApplication()
        {
            // check error
            var isTooManyError = Applications.Count(x => x.IsMasterApplication) > 1;
            if(isTooManyError) throw new Exception("Too many master applications");
            var isTooFewError = Applications.Count(x => x.IsMasterApplication) < 1;
            if (isTooFewError) throw new Exception("No master application");
            
            // set master
            MasterApplication = Applications.Single(x => x.IsMasterApplication);
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
        public IList<ISingularApplication> Applications { get; private set; }

        /// <summary>
        /// Master application
        /// </summary>
        public ISingularApplication MasterApplication { get; private set; }
    }
}