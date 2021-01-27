using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.DependencyInjection
{
    /// <summary>
    /// 自动化按服务生命周期进行注入
    /// </summary>
    public static class ServiceLifetimeDependencyInjectExtensions
    {
        /// <summary>
        /// 自动化按服务生命周期进行注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServiceLifetimeDependencies(this IServiceCollection services)
        {
            RuntimeHelper.GetAllAssemblies().ToList().ForEach(a =>
            {
                a.GetTypes().Where(t => t.IsClass).ToList().ForEach(t =>
                {
                    var serviceType = t.GetInterface($"I{t.Name}");
                    if ((serviceType??t).GetInterface(typeof(ISingletonDependency).Name)!=null)
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
                    else if ((serviceType ?? t).GetInterface(typeof(IScopedDependency).Name)!=null)
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
                    else if ((serviceType ?? t).GetInterface(typeof(ITransientDependency).Name)!=null)
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
