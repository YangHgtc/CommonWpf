using Microsoft.Extensions.Configuration;

namespace CommonWpf.Configuration
{
    public static class ConfigurationHelper
    {
#pragma warning disable IDE1006 // Naming Styles
        private static readonly Lazy<IConfiguration> _configuration = new Lazy<IConfiguration>(() => new ConfigurationBuilder()
#pragma warning restore IDE1006 // Naming Styles
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json")
                               .AddJsonFile($"appsettings.{EnvironmentHelper.GetCurrentEnvironment()}.json", true)
                               .Build());

        public static IConfiguration Instance
        {
            get { return _configuration.Value; }
        }
    }
}
