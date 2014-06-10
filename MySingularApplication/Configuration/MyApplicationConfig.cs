using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Singular.Configuration;

namespace MySingularApplication.Configuration
{
    /// <summary>
    /// My app config
    /// </summary>
    public class MyApplicationConfig : ISingularApplication
    {
        public bool IsMasterApplication
        {
            get { return true; }
        }
    }
}