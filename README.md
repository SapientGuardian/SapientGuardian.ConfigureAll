#SapientGuardian.ConfigureAll

[![Windows Build status](https://ci.appveyor.com/api/projects/status/bxtp3m8vi50m1ba5?svg=true)](https://ci.appveyor.com/project/SapientGuardian/sapientguardian-configureall)<br />
[![Linux/OSX Build Status](https://travis-ci.org/SapientGuardian/SapientGuardian.ConfigureAll.png)](https://travis-ci.org/SapientGuardian/SapientGuardian.ConfigureAll)<br />
[![NuGet Package](https://img.shields.io/nuget/vpre/SapientGuardian.ConfigureAll.svg)](https://www.nuget.org/packages/SapientGuardian.ConfigureAll/)

## Description
ConfigureAll is a library to make using the Options configuration pattern easier. Just add the ConfigurationObject attribute and ConfigureAll!

## How to use it

1. Add the ConfigurationObject attribute on your configuration objects indicating the name of the key in your configuration that maps to the object
    ```C#
    using SapientGuardian.ConfigureAll;
    
    
    namespace ConfigureAllTests
    {
        [ConfigurationObject("TestKey")]
        public class TestConfigurationObject : IConfigurationObject
        {    
            public string TestValue { get; set; }
        }
    }
    ```  
2. Call ConfigureAll in your ConfigureServices method
    ```C#
    using Microsoft.Extensions.Options;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
        {            
            services.AddOptions();

            services.ConfigureAll(this.GetType().GetTypeInfo().Assembly, Configuration);
        }
    ```
    If your configuration objects are stored in a different assembly than the one containing your ConfigureServices method, be sure to specify that in the first parameter to ConfigureAll.