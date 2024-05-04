using Microsoft.AspNetCore.Builder;

namespace Yuebon.AspNetCore.Common
{
    /// <summary>
    /// 跨域中间件
    /// 解决net core 3.1 跨域 Cors 找不到 “Access-Control-Allow-Origin”
    /// </summary>
    public class CorsMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            if(!httpContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            }
            await _next(httpContext);
        }
    }

    /// <summary>
    /// 跨域中间件
    /// </summary>
    public static class CorsMiddlewareExtensions
    {
        /// <summary>
        /// 跨域中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}
