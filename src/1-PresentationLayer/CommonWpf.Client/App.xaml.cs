using System.Windows;
using CommonWpf.Client.Views;
using CommonWpf.Configuration;
using CommonWpf.Logger;

namespace CommonWpf.Client;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
    }

    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.AddConfiguration();
        containerRegistry.AddDatabase(Container);
        containerRegistry.AddLog(Container);
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }
}
