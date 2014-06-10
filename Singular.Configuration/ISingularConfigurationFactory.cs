using System.Collections;
using System.Collections.Generic;

namespace Singular.Configuration
{
    /// <summary>
    /// Config factory
    /// </summary>
    public interface ISingularConfigurationFactory
    {
        /// <summary>
        /// Applications
        /// </summary>
        IList<ISingularApplication> Applications { get; }

        /// <summary>
        /// Master application
        /// </summary>
        ISingularApplication MasterApplication { get; }
    }
}