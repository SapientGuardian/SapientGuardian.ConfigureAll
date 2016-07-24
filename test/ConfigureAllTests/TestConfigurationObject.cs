using SapientGuardian.ConfigureAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureAllTests
{
    [ConfigurationObject("TestKey")]
    public class TestConfigurationObject
    {        
        public string TestValue { get; set; }
    }
}
