using Microsoft.AspNetCore.Http;

namespace Yuebon.Extensions.ServiceExtensions;

/// <summary>
/// HttpContext 相关服务
/// </summary>
public static class HttpContextSetup
{
    public static void AddHttpContextSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}
