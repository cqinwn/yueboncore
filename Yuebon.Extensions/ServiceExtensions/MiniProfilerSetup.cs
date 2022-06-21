namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// MiniProfiler 启动服务
/// </summary>
public static class MiniProfilerSetup
{

    /// <summary>
    /// MiniProfiler 启动服务
    /// </summary>
    /// <param name="services"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void AddMiniProfilerSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        services.AddMiniProfiler();
    }
}
