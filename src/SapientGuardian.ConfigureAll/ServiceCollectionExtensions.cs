using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SapientGuardian.ConfigureAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Options
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures all objects implementing <see cref="IConfigurationObject" />
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add the services to.</param>
        /// <param name="assembly">The assembly containing configuration objects.</param>
        /// <param name="configuration">The configuration being bound.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection ConfigureAll(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (assembly == null)
            {
                throw new ArgumentNullException(nameof(assembly));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var configurationObjectTypes = from type in assembly.GetTypes()
                                           let typeInfo = type.GetTypeInfo()
                                           where typeof(IConfigurationObject).GetTypeInfo().IsAssignableFrom(typeInfo)
                                           && typeInfo.IsClass
                                           select type;

            foreach (var configurationObjectType in configurationObjectTypes)
            {
                var configurationObjectTypeParameter = new Type[] { configurationObjectType };                
                var configurationOptionsInterfaceType = typeof(IConfigureOptions<>).MakeGenericType(configurationObjectTypeParameter);                
                var configureFromConfigurationOptionsType = typeof(ConfigureFromConfigurationOptions<>).MakeGenericType(configurationObjectTypeParameter);

                var configurationOptionsObject = (IConfigurationObject)Activator.CreateInstance(configurationObjectType);

                var configureFromConfigurationOptions = Activator.CreateInstance(configureFromConfigurationOptionsType, configuration.GetSection(configurationOptionsObject.ConfigurationKey));

                services.AddSingleton(configurationOptionsInterfaceType, configureFromConfigurationOptions);
            }

            return services;
        }
    }
}
