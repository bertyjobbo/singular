using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singular.Configuration.Tests
{
    [TestClass]
    public class FluentApiTests
    {
        [TestMethod]
        public void Test_Instantiation()
        {
            var currentConfig = SingularConfigurationFactory.Current;
            Assert.IsTrue(currentConfig.ApplicationsWithConfiguration.Count == 1);
            Assert.IsTrue(currentConfig.MasterApplication != null);
        }

        [TestMethod]
        public void Test_Name_Application()
        {
            Assert.IsTrue(SingularConfigurationFactory.Current.ApplicationsWithConfiguration[0].Application.Name == "My first application");
        }
    }
}
