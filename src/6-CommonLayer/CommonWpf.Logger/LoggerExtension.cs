using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace CommonWpf.Logger
{
    public static class LoggerExtension
    {
        public static IContainerRegistry AddLog(this IContainerRegistry containerRegistry, IContainerProvider provider)
        {
            // 注册 NLog 日志
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.ClearProviders();
                var log = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .ReadFrom.Configuration(provider.Resolve<IConfiguration>())
                    .Enrich.FromLogContext()
                    .CreateLogger();
                //builder.AddNLog();
                builder.AddSerilog(log);
            });

            containerRegistry.RegisterSingleton<ILoggerFactory>(() => loggerFactory);
            containerRegistry.RegisterSingleton(typeof(ILogger<>), typeof(Logger<>));
            return containerRegistry;
        }
    }
}
