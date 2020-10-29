using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Yuebon.Commons.IoC
{
    /// <summary>
    /// Autofac IOC 容器
    /// </summary>
    public class IoCContainer
    {
        private static ContainerBuilder _builder = new ContainerBuilder();
        private static IContainer _container;
        private static string[] _otherAssembly;
        private static string[] _otherAssemblyFrom;
        private static List<Type> _types = new List<Type>();
        private static Dictionary<Type, Type> _dicTypes = new Dictionary<Type, Type>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IContainer InitAutofac(IServiceCollection services)
        {
            return _container;
        }
        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="assemblies">程序集名称的集合</param>
        public static void Register(params string[] assemblies)
        {
            _otherAssembly = assemblies;
        }

        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="assemblies">程序集名称的集合,全路径</param>
        public static void RegisterFrom(params string[] assemblies)
        {
            _otherAssemblyFrom = assemblies;
        }
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="types"></param>
        public static void Register(params Type[] types)
        {
            _types.AddRange(types.ToList());
        }
        /// <summary>
        /// 注册程序集。
        /// </summary>
        /// <param name="implementationAssemblyName">接口实现程序集</param>
        /// <param name="interfaceAssemblyName">接口程序集</param>
        public static void Register(string implementationAssemblyName, string interfaceAssemblyName)
        {
            var implementationAssembly = Assembly.Load(implementationAssemblyName);
            var interfaceAssembly = Assembly.Load(interfaceAssemblyName);
            var implementationTypes =
                implementationAssembly.DefinedTypes.Where(t =>
                    t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested);
            foreach (var type in implementationTypes)
            {
                var interfaceTypeName = interfaceAssemblyName + ".I" + type.Name;
                var interfaceType = interfaceAssembly.GetType(interfaceTypeName);
                if (interfaceType != null)
                {
                    if (interfaceType.IsAssignableFrom(type))
                    {
                        _dicTypes.Add(interfaceType, type);
                    }
                }
            }
        }
        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="AssemblyName">程序集</param>
        /// <param name="namespaceName">命名空间</param>
        public static void RegisterNew(string AssemblyName, string namespaceName)
        {
            var implementationAssembly = Assembly.Load(AssemblyName);

            var interfaceAssembly = implementationAssembly;
            var implementationTypes =
                implementationAssembly.DefinedTypes.Where(t =>
                    t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested).OrderBy(t => t.Namespace);
            foreach (var type in implementationTypes)
            {
                var interfaceTypeName = string.Empty;
                if (type.Namespace != null)
                {
                    if (type.Namespace.Contains("Services")&& type.Namespace.Contains("Yuebon"))
                    {
                        interfaceTypeName = namespaceName + ".IServices.I" + type.Name;
                    }
                    if (type.Namespace.Contains("Repositories") && type.Namespace.Contains("Yuebon"))
                    {
                        interfaceTypeName = namespaceName + ".IRepositories.I" + type.Name;
                    }
                    if (!string.IsNullOrEmpty(interfaceTypeName) && !interfaceTypeName.Contains("OperationLogEvent"))
                    {
                        var interfaceType = interfaceAssembly.GetType(interfaceTypeName);
                        if (interfaceType != null)
                        {
                            if (interfaceType.IsAssignableFrom(type))
                            {
                                _dicTypes.Add(interfaceType, type);
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssemblyName"></param>
        /// <param name="namespaceName"></param>
        public static void RegisterLoadFrom(string AssemblyName, string namespaceName)
        {
            var implementationAssembly = Assembly.LoadFrom(AssemblyName);

            var interfaceAssembly = implementationAssembly;
            var implementationTypes =
                implementationAssembly.DefinedTypes.Where(t =>
                    t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested).OrderBy(t => t.Namespace);
            var applicationNamespace = string.Empty;
            foreach (var type in implementationTypes)
            {
                var interfaceTypeName = string.Empty;
                if (type.Namespace.Contains("Services"))
                {
                    interfaceTypeName = namespaceName + ".IServices.I" + type.Name;
                }
                if (type.Namespace.Contains("Repositories"))
                {
                    interfaceTypeName = namespaceName + ".IRepositories.I" + type.Name;
                }

                if (!string.IsNullOrEmpty(interfaceTypeName))
                {
                    var interfaceType = interfaceAssembly.GetType(interfaceTypeName);
                    if (interfaceType != null)
                    {
                        if (interfaceType.IsAssignableFrom(type))
                        {
                            _dicTypes.Add(interfaceType, type);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 注册类
        /// </summary>
        /// <typeparam name="TInterface">接口</typeparam>
        /// <typeparam name="TImplementation">实现类</typeparam>
        public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _dicTypes.Add(typeof(TInterface), typeof(TImplementation));
        }

        /// <summary>
        /// 注册一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        public static void Register<T>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).SingleInstance();
        }
        /// <summary>
        /// 构建IOC容器，需在各种Register后调用。
        /// </summary>
        public static IServiceProvider Build(IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (_otherAssembly != null)
            {
                foreach (var item in _otherAssembly)
                {
                    _builder.RegisterAssemblyTypes(Assembly.Load(item));
                }
            }
            if (_otherAssemblyFrom != null)
            {
                foreach (var item in _otherAssemblyFrom)
                {
                    _builder.RegisterAssemblyTypes(Assembly.LoadFrom(item));
                }
            }
            if (_types != null)
            {
                foreach (var type in _types)
                {
                    _builder.RegisterType(type);
                }
            }

            if (_dicTypes != null)
            {
                foreach (var dicType in _dicTypes)
                {
                    _builder.RegisterType(dicType.Value).As(dicType.Key);
                }
            }

            _builder.Populate(services);
            _container = _builder.Build();
            return new AutofacServiceProvider(_container);
        }


        /// <summary>
        /// 从容器中获取对象 Resolve an instance of the default requested type from the container
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

    }
}