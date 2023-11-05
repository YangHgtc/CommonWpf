using Microsoft.Extensions.Configuration;

namespace CommonWpf.Configuration;

/// <summary>
/// 文件配置帮助类
/// </summary>
public static class ConfigurationExtension
{
    public static IContainerRegistry AddConfiguration(this IContainerRegistry containerRegistry)
    {
        var configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .AddJsonFile($"appsettings.{EnvironmentHelper.GetCurrentEnvironment()}.json", true)
                               .Build();
        containerRegistry.RegisterSingleton<IConfiguration>(() => configuration);
        return containerRegistry;
    }
}
