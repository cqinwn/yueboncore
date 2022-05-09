using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// Redis缓存 启动服务
    /// </summary>
    public static class RedisCacheSetup
    {
        /// <summary>
        /// Redis缓存 启动服务
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddRedisCacheSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            CacheProvider cacheProvider = new CacheProvider
            {
                IsUseRedis = Appsettings.Configuration.GetSection("CacheProvider:UseRedis").Value.ToBool(false),
                ConnectionString = Appsettings.Configuration.GetSection("CacheProvider:Redis_ConnectionString").Value,
                InstanceName = Appsettings.Configuration.GetSection("CacheProvider:Redis_InstanceName").Value
            };

            var options = new JsonSerializerOptions();
            options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            options.WriteIndented = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.AllowTrailingCommas = true;
            //设置时间格式
            options.Converters.Add(new DateTimeJsonConverter());
            options.Converters.Add(new DateTimeNullableConverter());
            //设置bool获取格式
            options.Converters.Add(new BooleanJsonConverter());
            //设置数字
            options.Converters.Add(new IntJsonConverter());
            options.Converters.Add(new LongJsonConverter());
            options.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
            options.PropertyNameCaseInsensitive = true;                     //忽略大小写
            //判断是否使用Redis，如果不使用 Redis就默认使用 MemoryCache
            if (cacheProvider.IsUseRedis)
            {
                //Use Redis
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = cacheProvider.ConnectionString;
                    options.InstanceName = cacheProvider.InstanceName;
                });
                services.AddSingleton(typeof(ICacheService), new RedisCacheService(new RedisCacheOptions
                {
                    Configuration = cacheProvider.ConnectionString,
                    InstanceName = cacheProvider.InstanceName
                }, options, 0));
                services.AddSingleton(typeof(RedisHelper), new RedisHelper(new RedisCacheOptions
                {
                    Configuration = cacheProvider.ConnectionString,
                    InstanceName = cacheProvider.InstanceName
                }, options, 0));
                services.Configure<DistributedCacheEntryOptions>(option => option.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5));//设置Redis缓存有效时间为5分钟。
            }
            else
            {
                //Use MemoryCache
                services.AddSingleton<IMemoryCache>(factory =>
                {
                    var cache = new MemoryCache(new MemoryCacheOptions());
                    return cache;
                });
                services.AddSingleton<ICacheService, MemoryCacheService>();
                services.Configure<MemoryCacheEntryOptions>(
                    options => options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)); //设置MemoryCache缓存有效时间为5分钟
            }
            services.AddTransient<MemoryCacheService>();
            services.AddMemoryCache();// 启用MemoryCache

            services.AddSingleton(cacheProvider);//注册缓存配置

        }
    }
}
