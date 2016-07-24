using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapientGuardian.ConfigureAll
{
    /// <summary>
    /// Interface for ConfigureAll
    /// </summary>
    public interface IConfigurationObject
    {
        /// <summary>
        /// Gets the configuration key that maps to this object.
        /// </summary>
        /// <value>
        /// The configuration key.
        /// </value>
        string ConfigurationKey { get; }
    }
}
