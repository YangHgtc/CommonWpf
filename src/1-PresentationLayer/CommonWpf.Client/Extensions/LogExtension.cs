using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

namespace CommonWpf.Client.Extensions
{
    public static class LogExtension
    {
        public static IServiceCollection AddLog(this IServiceCollection services)
        {
            var logservice = services;
            using var provider = logservice.BuildServiceProvider().CreateScope();
            var config = provider.ServiceProvider.GetService<IConfiguration>()!;

            var providers = new LoggerProviderCollection();
            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .WriteTo.Providers(providers)
            .CreateLogger();

            services.AddSingleton(providers);
            services.AddSingleton<ILoggerFactory>(sc =>
            {
                var providerCollection = sc.GetService<LoggerProviderCollection>();
                var factory = new SerilogLoggerFactory(null, true, providerCollection);

                foreach (var provider in sc.GetServices<ILoggerProvider>())
                {
                    factory.AddProvider(provider);
                }

                return factory;
            });

            services.AddLogging();
            return services;
        }
    }
}
