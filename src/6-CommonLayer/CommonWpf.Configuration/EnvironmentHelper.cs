namespace CommonWpf.Configuration;

public static class EnvironmentHelper
{
    public static string GetCurrentEnvironment()
    {
#if DEBUG
        return "Development";
#else
        return "Production";
#endif
    }
}
