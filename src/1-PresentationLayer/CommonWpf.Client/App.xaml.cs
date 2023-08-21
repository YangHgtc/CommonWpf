using System.Windows;
using CommonWpf.Client.Views;
using DryIoc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Prism.Ioc;
using LogLevel = NLog.LogLevel;

namespace CommonWpf.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:命名样式", Justification = "<挂起>")]
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
            LogManager.Setup().LoadConfiguration(builder =>
            {
                builder.ForLogger().FilterMinLevel(LogLevel.Info).WriteToConsole();
                builder.ForLogger().FilterMinLevel(LogLevel.Debug).WriteToFile(fileName: "file.txt");
            });
            _logger.Info("app start");
            base.OnStartup(e);
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册 NLog 日志
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddNLog();
            });

            containerRegistry.RegisterInstance<ILoggerFactory>(loggerFactory);
            containerRegistry.RegisterSingleton(typeof(ILogger<>), typeof(Logger<>));
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LogManager.Shutdown(); // Flush and close down internal threads and timers
            base.OnExit(e);
        }
    }
}
