using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Yuebon.Commons.DependencyInjection;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// IServiceCollection自定义扩展
    /// </summary>
    public static class AppServiceCollectionExtensions
    {
        /// <summary>
        /// 添加自动扫描注入Service服务和Respository仓储
        /// <para>
        /// 需要注意的是，遵循如下约定：
        /// IUserService --> UserService, IUserRepository --> UserRepository.
        /// </para>
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns>服务集合</returns>
        public static IServiceCollection AddAutoScanInjection(this IServiceCollection services)
        {
            RuntimeHelper.GetAllYuebonAssemblies().ToList().ForEach(a =>
            {
                a.GetTypes().Where(t => typeof(IPrivateDependency).IsAssignableFrom(t) && t.IsClass).ToList().ForEach(t =>
                {
                    var serviceType = t.GetInterface($"I{t.Name}");
                    //if (serviceType != null)
                    //{
                    //    services.AddScoped(serviceType, t);
                    //}
                    //else
                    //{
                    //    services.AddScoped(t);
                    //}
                    if ((serviceType ?? t).GetInterface(typeof(ISingletonDependency).Name) != null)
                    {
                        if (serviceType != null)
                        {
                            services.AddSingleton(serviceType, t);
                        }
                        else
                        {
                            services.AddSingleton(t);
                        }
                    }
                    else if ((serviceType ?? t).GetInterface(typeof(IScopedDependency).Name) != null)
                    {
                        if (serviceType != null)
                        {
                            services.AddScoped(serviceType, t);
                        }
                        else
                        {
                            services.AddScoped(t);
                        }
                    }
                    else if ((serviceType ?? t).GetInterface(typeof(ITransientDependency).Name) != null)
                    {
                        if (serviceType != null)
                        {
                            services.AddTransient(serviceType, t);
                        }
                        else
                        {
                            services.AddTransient(t);
                        }
                    }
                    else
                    {
                        if (serviceType != null)
                        {
                            services.AddTransient(serviceType, t);
                        }
                        else
                        {
                            services.AddTransient(t);
                        }
                    }
                });
            });
            return services;
        }
    }
}
