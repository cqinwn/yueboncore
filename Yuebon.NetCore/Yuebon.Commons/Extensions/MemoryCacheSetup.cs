using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// Memory缓存 启动服务
    /// </summary>
    public static class MemoryCacheSetup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddMemoryCacheSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<ICacheService, MemoryCaching>();
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var value = factory.GetRequiredService<IOptions<MemoryCacheOptions>>();
                var cache = new MemoryCache(value);
                return cache;
            });
        }
    }
}
