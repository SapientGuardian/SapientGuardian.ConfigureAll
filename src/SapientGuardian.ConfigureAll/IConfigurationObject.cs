using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapientGuardian.ConfigureAll
{
    public interface IConfigurationObject
    {
        string ConfigurationKey { get; }
    }
}
