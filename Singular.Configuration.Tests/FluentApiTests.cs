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
            Assert.IsTrue(currentConfig.Applications.Count == 1);
            Assert.IsTrue(currentConfig.MasterApplication != null);
        }
    }
}
