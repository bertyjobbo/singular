using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular.Configuration
{
    /// <summary>
    /// Application interface
    /// </summary>
    public interface ISingularApplication
    {
        /// <summary>
        /// Is master application
        /// </summary>
        bool IsMasterApplication { get; }
    }
}
