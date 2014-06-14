using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySingularApplication.Defaults;
using MySingularApplication.IOC;
using Singular.Web.Admin.Defaults;
using Singular.Web.Admin.IOC;

namespace Singular.Configuration.Tests
{
    [TestClass]
    public class FluentApiTests
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FluentApiTests()
        {
            SingularConfigurationFactory.Current.Init();
        }

        /// <summary>
        /// Instantiation
        /// </summary>
        [TestMethod]
        public void Test_Instantiation()
        {
            var currentConfig = SingularConfigurationFactory.Current;
            Assert.IsTrue(currentConfig.ApplicationsWithConfiguration.Count == 2);
            Assert.IsTrue(currentConfig.MasterApplication != null);
        }

        /// <summary>
        /// App name
        /// </summary>
        [TestMethod]
        public void Test_Name_Application()
        {
            Assert.IsTrue(SingularConfigurationFactory.Current.MasterApplication.Name == SingularAdminDefaults.APP_NAME);
        }

        /// <summary>
        /// Test sections
        /// </summary>
        [TestMethod]
        public void Test_Sections()
        {
            Assert.IsTrue(SingularConfigurationFactory.Current.Applications.Single(x=>x.ApplicationId== SingularAdminDefaults.AppId).AdminSections.Count == 2);
        }

        /// <summary>
        /// Test installers
        /// </summary>
        [TestMethod]
        public void Test_Installers()
        {
            Assert.IsTrue(SingularConfigurationFactory.Current.ControllerInstallers.Count == 2);
            SingularConfigurationFactory.Current.AddControllerInstaller(new MySingularInstaller());
            Assert.IsTrue(SingularConfigurationFactory.Current.ControllerInstallers.Count == 3);
            Assert.IsTrue(SingularConfigurationFactory.Current.WebApiControllerInstallers.Count == 1);
            SingularConfigurationFactory.Current.AddWebApiControllerInstaller(new SingularAdminApiInstaller());
            Assert.IsTrue(SingularConfigurationFactory.Current.WebApiControllerInstallers.Count == 2);
        }

        /// <summary>
        /// Test app starts
        /// </summary>
        [TestMethod]
        public void Test_AppStartMethods()
        {
            Assert.IsTrue(SingularConfigurationFactory.Current.AppStartMethods.Count==0);
        }
    }
}
