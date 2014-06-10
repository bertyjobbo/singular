using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular.Configuration
{
    /// <summary>
    /// Admin section
    /// </summary>
    public class SingularAdminSection
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Controller eg /#/{controller}/
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Action eg /#/home/{action}
        /// </summary>
        public string Action { get; set; }
    }
}
