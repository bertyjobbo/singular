using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySingularApplication.Defaults;
using Singular.Web.Admin.Defaults;

namespace Singular.Configuration.Tests
{
    [TestClass]
    public class FluentApiTests
    {
        [TestMethod]
        public void Test_Instantiation()
        {
            var currentConfig = SingularConfigurationFactory.Current;
            Assert.IsTrue(currentConfig.ApplicationsWithConfiguration.Count == 2);
            Assert.IsTrue(currentConfig.MasterApplication != null);
        }

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
    }
}
