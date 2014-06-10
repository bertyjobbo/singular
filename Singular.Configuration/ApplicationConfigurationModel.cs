using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular.Configuration
{
    /// <summary>
    /// App config model
    /// </summary>
    public class ApplicationConfigurationModel
    {
        /// <summary>
        /// Application
        /// </summary>
        public SingularApplicationBase Application { get; set; }

        /// <summary>
        /// Configuration root
        /// </summary>
        public SingularApplicationConfigurationRoot ConfigurationRoot { get; set; }
    }
}
