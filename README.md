#SapientGuardian.ConfigureAll

[![Windows Build status](https://ci.appveyor.com/api/projects/status/bxtp3m8vi50m1ba5?svg=true)](https://ci.appveyor.com/project/SapientGuardian/sapientguardian-configureall)<br />
[![Linux/OSX Build Status](https://travis-ci.org/SapientGuardian/SapientGuardian.ConfigureAll.png)](https://travis-ci.org/SapientGuardian/SapientGuardian.ConfigureAll)<br />
[![NuGet Package](https://img.shields.io/nuget/vpre/SapientGuardian.ConfigureAll.svg)](https://www.nuget.org/packages/SapientGuardian.ConfigureAll/)

## Description
ConfigureAll is a library to make using the Options configuration pattern easier. Just implement IConfigurationObject and ConfigureAll!

## How to use it

  1. Implement the IConfigurationObject interface on your configuration objects by adding a ConfigurationKey property indicating the name of the key in your configuration that maps to this object
```C#
using SapientGuardian.ConfigureAll;


namespace ConfigureAllTests
{
    public class TestConfigurationObject : IConfigurationObject
    {
        public string ConfigurationKey => "TestKey";

        public string TestValue { get; set; }
    }
}
```  
  2. Call ConfigureAll in your ConfigureServices method
```C#
 public IConfiguration Configuration { get; }

 public void ConfigureServices(IServiceCollection services)
        {            
            services.AddOptions();

            services.ConfigureAll(this.GetType().GetTypeInfo().Assembly, Configuration);
        }
```
If your configuration objects are stored in a different assembly than the one containing your ConfigureServices method, be sure to specify that in the first parameter to ConfigureAll.