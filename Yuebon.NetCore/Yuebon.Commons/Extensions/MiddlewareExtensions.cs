/*******************************************************************************
 * Copyright © 2017-2019 Yuebon.Framework 版权所有
 * Author: Yuebon
 * Description: Yuebon快速开发平台
 * Website：http://www.yuebon.com
*********************************************************************************/
using System;
using Microsoft.AspNetCore.Builder;
using Yuebon.Commons.Middlewares;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// 中间件扩展类
    /// </summary>
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMemoryCacheInterceptor(this IApplicationBuilder app)
        {
            if(app==null)throw new ArgumentNullException(nameof(app));
            return app.UseMiddleware<MemoryCacheInterceptor>();
        }

        public static IApplicationBuilder UseRedisCacheInterceptor(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            return app.UseMiddleware<RedisCacheInterceptor>();
        }
    }
}
