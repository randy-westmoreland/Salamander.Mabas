using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Salamander.Mabas.Client.Configurations
{
    /// <summary>
    /// DependencyConfig Class.
    /// </summary>
    public static class DependencyConfig
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var business = Assembly.Load(configuration["Assemblies:Business"]);

            services.Scan(x =>
                x.FromAssemblies(business)
                .AddClasses(y => y.Where(type => type.Name.EndsWith("Wrapper", StringComparison.OrdinalIgnoreCase)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.Scan(x =>
                x.FromAssemblies(business)
                .AddClasses(y => y.Where(type => type.Name.EndsWith("Manager", StringComparison.OrdinalIgnoreCase)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.AddSingleton(configuration);
        }
    }
}