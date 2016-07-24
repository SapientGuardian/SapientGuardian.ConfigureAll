using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapientGuardian.ConfigureAll
{
    [AttributeUsage(System.AttributeTargets.Class)]
    public class ConfigurationObject : Attribute
    {
        public string ConfigurationKey => configurationKey;
        private string configurationKey;
        public ConfigurationObject(string configurationKey)
        {
            this.configurationKey = configurationKey;
        }
    }
}
