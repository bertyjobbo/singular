using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singular.Configuration
{
    /// <summary>
    /// Node type
    /// </summary>
    public class NodeTypeDefinition
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Can be root node?
        /// </summary>
        public bool CanBeRoot { get; set; }

        /// <summary>
        /// Can be json
        /// </summary>
        public bool CanBeJson { get; set; }

        /// <summary>
        /// Can be page
        /// </summary>
        public bool CanBePage { get; set; }

        /// <summary>
        /// Magic name
        /// </summary>
        public string MagicName { get; set; }

        /// <summary>
        /// Children allowed (comma sep magic name)
        /// </summary>
        public string AllowedChildTypeMagicNames { get; set; }

        /// <summary>
        /// Allowed child types
        /// </summary>
        public IList<NodeTypeDefinition> AllowedChildTypes { get; set; }
    }
}
