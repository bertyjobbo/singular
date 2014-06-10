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
        IList<ApplicationConfigurationModel> ApplicationsWithConfiguration { get; }

        /// <summary>
        /// Applications
        /// </summary>
        IList<SingularApplicationBase> Applications { get; }

        /// <summary>
        /// Master application
        /// </summary>
        SingularApplicationBase MasterApplication { get; }
    }
}