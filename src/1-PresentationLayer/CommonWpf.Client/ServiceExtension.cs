using CommonWpf.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CommonWpf.Client
{
    internal static class ServiceExtension
    {
        public static IContainerRegistry AddDatabase(this IContainerRegistry registry, IContainerProvider container)
        {
            var configuration = container.Resolve<IConfiguration>();
            var option = (IConfiguration)configuration.GetSection(ConnectionOption.ConnectionString);
            registry.RegisterSingleton<IOptions<ConnectionOption>>(() => Options.Create(option.Get<ConnectionOption>()!));
            return registry;
        }
    }
}
