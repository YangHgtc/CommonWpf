using System.Windows;
using CommonWpf.Client.Extensions;
using CommonWpf.Client.Views;
using DryIoc.Microsoft.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }

    protected override IContainerExtension CreateContainerExtension()
    {
        var services = new ServiceCollection();
        services.AddConfiguration();
        services.AddLog();
        return new DryIocContainerExtension(new DryIoc.Container(CreateContainerRules()).WithDependencyInjectionAdapter(services));
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }
}
