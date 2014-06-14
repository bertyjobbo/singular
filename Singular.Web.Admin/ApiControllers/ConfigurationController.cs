using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Singular.Configuration;

namespace Singular.Web.Admin.ApiControllers
{
    /// <summary>
    /// Configuration controller
    /// </summary>
    public class ConfigurationController : ApiController
    {
        // fields
        private readonly ISingularConfigurationFactory _factory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configurationFactory"></param>
        public ConfigurationController(ISingularConfigurationFactory configurationFactory)
        {
            _factory = configurationFactory;
        }

         
        /// <summary>
        /// Sections
        /// </summary>
        /// <returns></returns>
        [Route("singularapi/config/sections")]
        [AcceptVerbs("GET")]
        public IList<SingularAdminSection> Sections()
        {
            return _factory.Applications.SelectMany(x => x.AdminSections).ToList();
        }
    }
}
