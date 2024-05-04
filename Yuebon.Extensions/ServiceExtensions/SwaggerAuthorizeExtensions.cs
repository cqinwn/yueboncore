using Microsoft.AspNetCore.Builder;
using Yuebon.Extensions.Middlewares;

namespace Yuebon.Extensions.ServiceExtensions;
/// <summary>
/// 
/// </summary>
public static class SwaggerAuthorizeExtensions
{
    public static IApplicationBuilder UseSwaggerAuthorized(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<SwaggerBasicAuthMiddleware>();
    }
}
