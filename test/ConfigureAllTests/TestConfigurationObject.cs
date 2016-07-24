using SapientGuardian.ConfigureAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureAllTests
{
    public class TestConfigurationObject : IConfigurationObject
    {
        public string ConfigurationKey => "TestKey";

        public string TestValue { get; set; }
    }
}
