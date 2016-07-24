using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace ConfigureAllTests
{
    public class ConfigureAllTests
    {
        public ConfigureAllTests()
        {
            
        }

        [Fact]
        public void LoadsConfiguration()
        {
            var configData = new Dictionary<string, string>()
            {
                 {"TestKey:TestValue", "Success!" }
            };

            var builder = new ConfigurationBuilder()
            .AddInMemoryCollection(configData);

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddOptions();
            services.ConfigureAll(this.GetType().GetTypeInfo().Assembly, configuration);
            
            var serviceProvider = services.BuildServiceProvider();
            var configurationObjectOptions = serviceProvider.GetService<IOptions<TestConfigurationObject>>();
            configurationObjectOptions.Value.TestValue.Should().Be("Success!");


        }
    }
}
