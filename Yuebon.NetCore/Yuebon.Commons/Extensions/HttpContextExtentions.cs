using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// HttpContext 扩展
    /// </summary>
    public static class HttpContextExtentions
    {
        public static IApplicationBuilder UseStaticHttpContextAccessor(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            HttpContextHelper.Configure(httpContextAccessor);
            return app;
        }
    }
}
