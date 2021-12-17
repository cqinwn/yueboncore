using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.DependencyInjection;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.IoC;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Models;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;

namespace Yuebon.Commons.Extensions
{
    /// <summary>
    /// IServiceCollection自定义扩展
    /// </summary>
    public static class AppServiceCollectionExtensions
    {
        #region 用DI批量注入接口程序集中对应的实现类，接口和实现类在一个程序集中。
        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// 针对每一次服务提供请求，IServiceProvider对象总是创建一个新的服务实例
        /// <para>
        /// 需要注意的是，这里有如下约定：
        /// IUserService --> UserService, IUserRepository --> UserRepository.
        /// </para>
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection AddTransientAssembly(this IServiceCollection service, string interfaceAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));

            var assembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (assembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = assembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                var implementTypeName = type.Name.Substring(1);
                var implementType = RuntimeHelper.GetImplementType(implementTypeName, type);
                if (implementType != null)
                    service.AddTransient(type, implementType);
            }
            return service;
        }
        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// 在同一个作用域内只初始化一个实例 ，可以理解为每一个请求只创建一个实例，同一个请求会在一个作用域内。在Scooped的生存周期内，如果容器释放 它也就被释放了
        /// <para>
        /// 需要注意的是，这里有如下约定：
        /// IUserService --> UserService, IUserRepository --> UserRepository.
        /// </para>
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection AddScopedAssembly(this IServiceCollection service, string interfaceAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));

            var assembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (assembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = assembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                var implementTypeName = type.Name.Substring(1);
                var implementType = RuntimeHelper.GetImplementType(implementTypeName, type);
                if (implementType != null)
                    service.AddScoped(type, implementType);
            }
            return service;
        }

        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// 整个应用程序生命周期以内只创建一个实例，后续每个请求都使用相同的实例。如果应用程序需要单例行为，建议让服务容器管理服务的生命周期，而不是在自己的类中实现单例模式。
        /// <para>
        /// 需要注意的是，这里有如下约定：
        /// IUserService --> UserService, IUserRepository --> UserRepository.
        /// </para>
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection AddSingletonAssembly(this IServiceCollection service, string interfaceAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));

            var assembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (assembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = assembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                var implementTypeName = type.Name.Substring(1);
                var implementType = RuntimeHelper.GetImplementType(implementTypeName, type);
                if (implementType != null)
                    service.AddSingleton(type, implementType);
            }
            return service;
        }
        #endregion

        #region 用DI批量注入接口程序集中对应的实现类，接口和实现类在独立的程序集中。
        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <param name="implementAssemblyName">实现程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection AddScopedAssembly(this IServiceCollection service, string interfaceAssemblyName, string implementAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));
            if (string.IsNullOrEmpty(implementAssemblyName))
                throw new ArgumentNullException(nameof(implementAssemblyName));

            var interfaceAssembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (interfaceAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            var implementAssembly = RuntimeHelper.GetAssembly(implementAssemblyName);
            if (implementAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{implementAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = interfaceAssembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                //过滤掉抽象类、泛型类以及非class
                var implementType = implementAssembly.DefinedTypes
                    .FirstOrDefault(t => t.IsClass && !t.IsAbstract && !t.IsGenericType &&
                                         t.GetInterfaces().Any(b => b.Name == type.Name));
                if (implementType != null)
                {
                    service.AddScoped(type, implementType.AsType());
                }
            }

            return service;
        }

        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <param name="implementAssemblyName">实现程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection AddTransientAssembly(this IServiceCollection service, string interfaceAssemblyName, string implementAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));
            if (string.IsNullOrEmpty(implementAssemblyName))
                throw new ArgumentNullException(nameof(implementAssemblyName));

            var interfaceAssembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (interfaceAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            var implementAssembly = RuntimeHelper.GetAssembly(implementAssemblyName);
            if (implementAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{implementAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = interfaceAssembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                //过滤掉抽象类、泛型类以及非class
                var implementType = implementAssembly.DefinedTypes
                    .FirstOrDefault(t => t.IsClass && !t.IsAbstract && !t.IsGenericType &&
                                         t.GetInterfaces().Any(b => b.Name == type.Name));
                if (implementType != null)
                {
                    service.AddTransient(type, implementType.AsType());
                }
            }

            return service;
        }

        /// <summary>
        /// 用DI批量注入接口程序集中对应的实现类。
        /// </summary>
        /// <param name="service"></param>
        /// <param name="interfaceAssemblyName">接口程序集的名称（不包含文件扩展名）</param>
        /// <param name="implementAssemblyName">实现程序集的名称（不包含文件扩展名）</param>
        /// <returns></returns>
        public static IServiceCollection AddSingletonAssembly(this IServiceCollection service, string interfaceAssemblyName, string implementAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(interfaceAssemblyName))
                throw new ArgumentNullException(nameof(interfaceAssemblyName));
            if (string.IsNullOrEmpty(implementAssemblyName))
                throw new ArgumentNullException(nameof(implementAssemblyName));

            var interfaceAssembly = RuntimeHelper.GetAssembly(interfaceAssemblyName);
            if (interfaceAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{interfaceAssemblyName}\" not be found");
            }

            var implementAssembly = RuntimeHelper.GetAssembly(implementAssemblyName);
            if (implementAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{implementAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = interfaceAssembly.GetTypes().Where(t => t.GetTypeInfo().IsInterface && !t.GetTypeInfo().IsGenericType);

            foreach (var type in types)
            {
                //过滤掉抽象类、泛型类以及非class
                var implementType = implementAssembly.DefinedTypes
                    .FirstOrDefault(t => t.IsClass && !t.IsAbstract && !t.IsGenericType &&
                                         t.GetInterfaces().Any(b => b.Name == type.Name));
                if (implementType != null)
                {
                    service.AddSingleton(type, implementType.AsType());
                }
            }

            return service;
        }

        #endregion

        #region 注入控制器Controler
        /// <summary>
        /// 注入Controler
        /// </summary>
        /// <param name="service"></param>
        /// <param name="controllerAssemblyName"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterControllers(this IServiceCollection service,
            string controllerAssemblyName)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            if (string.IsNullOrEmpty(controllerAssemblyName))
                throw new ArgumentNullException(nameof(controllerAssemblyName));
            var controllerAssembly = RuntimeHelper.GetAssembly(controllerAssemblyName);
            if (controllerAssembly == null)
            {
                throw new DllNotFoundException($"the dll \"{controllerAssemblyName}\" not be found");
            }

            //过滤掉非接口及泛型接口
            var types = controllerAssembly.GetTypes().Where(t =>
            {
                var typeInfo = t.GetTypeInfo();
                return typeInfo.IsClass && !typeInfo.IsAbstract && !typeInfo.IsGenericType && t.IsAssignableFrom(typeof(Controller));
            });

            foreach (var type in types)
            {
                service.AddScoped(type);
            }

            return service;
        }

        #endregion


        #region 数据库上下文相关服务注入
        /// <summary>
        /// 注册数据库上下文工厂
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContextFactory(this IServiceCollection services,
            Action<DbContextFactory> action)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            var factory = DbContextFactory.Instance;
            factory.ServiceCollection = services;
            action?.Invoke(factory);
            return factory.ServiceCollection;
        }

        /// <summary>
        /// 注入数据库上下文
        /// </summary>
        /// <typeparam name="IT"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="option">数据库上下文配置参数</param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext<IT, T>(this IServiceCollection services, DbContextOption option) where IT : IDbContextCore where T : BaseDbContext, IT
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (option == null) throw new ArgumentNullException(nameof(option));
            services.AddSingleton(option);
            return services.AddDbContext<IT, T>(option);
        }

        /// <summary>
        /// 注入数据库上下文
        /// </summary>
        /// <typeparam name="IT"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbContext<IT, T>(this IServiceCollection services) where IT : IDbContextCore where T : BaseDbContext, IT
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            return services.AddDbContext<IT, T>();
        }

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="dbContextTagName">上下文标签名称</param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static object GetDbContext(this IServiceProvider provider, string dbContextTagName, Type serviceType)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            var implService = provider.GetRequiredService(serviceType);
            var option = provider.GetServices<DbContextOption>().FirstOrDefault(m => m.dbConfigName == dbContextTagName);

            var context = Activator.CreateInstance(implService.GetType(), option);

            return context;
        }
        #endregion



        #region  注册仓储Repositories

        /// <summary>
        /// 注册仓储Repositories
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterDefaultRepositories<T>(this IServiceCollection services) where T : DbContext, new()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var list = assembly.GetTypes().Where(t => t.GetCustomAttributes<DbContextAttribute>()
                                                          .Any(a => a.ContextType == typeof(T))
                                                      && !t.GetCustomAttributes<MigrationAttribute>().Any() &&
                                                      !t.FullName.Contains("Migrations")).ToList();
            if (list.Any())
            {
                foreach (var type in list)
                {
                    var pkType = GetPrimaryKeyType(type);
                    var implType = GetRepositoryType(type, pkType);
                    if (pkType != null)
                    {
                        services.TryAddScoped(typeof(IRepository<,>).MakeGenericType(type, pkType), implType);
                    }
                }
            }
            return services;
        }
        /// <summary>
        /// 获取继承仓储BaseRepository的所有仓储类型
        /// </summary>
        /// <param name="entityType"></param>
        /// <param name="primaryKeyType"></param>
        /// <returns></returns>
        private static Type GetRepositoryType(Type entityType, Type primaryKeyType)
        {
            return typeof(BaseRepository<,>).MakeGenericType(entityType, primaryKeyType);
        }


        /// <summary>
        /// 获取继承Entity的所有实体类型主键类型
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        private static Type GetPrimaryKeyType(Type entityType)
        {
            foreach (var interfaceType in entityType.GetTypeInfo().GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(Entity))
                {
                    return interfaceType.GenericTypeArguments[0];
                }
            }

            return null;
        }
        #endregion


        /// <summary>
        /// 添加自动扫描注入Service服务和Respository仓储        /// 
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
