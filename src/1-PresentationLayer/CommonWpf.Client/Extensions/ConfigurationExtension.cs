using CommonWpf.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommonWpf.Client.Extensions
{
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                   .AddJsonFile($"appsettings.{EnvironmentHelper.GetCurrentEnvironment()}.json", optional: true, reloadOnChange: true)
                                   .Build();
            services.AddSingleton<IConfiguration>(config);
            services.Configure<ConnectionOption>(config.GetSection(ConnectionOption.Position));
            return services;
        }
    }
}
