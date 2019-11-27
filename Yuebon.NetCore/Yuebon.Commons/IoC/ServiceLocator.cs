using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Yuebon.Commons.IoC
{
    /// <summary>
    /// 服务定位器。
    /// </summary>
    public static class ServiceLocator
    {
        #region Others

        /// <summary>
        /// .NET CORE 内置服务提供者引用。
        /// </summary>
        public static IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// 手动获取.NET CORE已注册服务实例。
        /// 使用之前请确保在启动类（Startup.cs）配置（Configure）方法中已经保持【app.ApplicationServices】引用。
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            if (ServiceProvider == null)
            {
                throw new ArgumentNullException(nameof(ServiceProvider));
            }
            return (T)ServiceProvider.GetService(typeof(T));
        }

        #endregion

        #region Fields

        /// <summary>
        /// 类型与实例类型的映射集合。
        /// </summary>
        private static readonly Dictionary<Type, Type> _mapping = new Dictionary<Type, Type>();

        /// <summary>
        /// 类型与已实例化对象映射集合。
        /// </summary>
        private static readonly Dictionary<Type, object> _resources = new Dictionary<Type, object>();

        /// <summary>
        /// 操作锁。（待优化）
        /// 存在问题：lock机制会把其它线程锁在外面，无论是读还是写，都会被锁，性能比较低。
        /// 解决方案：线程安全可尝试用ConcurrentDictionary代替。
        /// </summary>
        private static object _lock = new object();

        #endregion

        #region Add

        /// <summary>
        /// 添加注册资源。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="instance">资源实例</param>
        public static void Add<T>(object instance) where T : class
        {
            Add(typeof(T), instance);
        }

        /// <summary>
        /// 添加注册资源。
        /// </summary>
        /// <param name="type">资源类型</param>
        /// <param name="instance">资源实例</param>
        public static void Add(Type type, object instance)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (!type.IsInstanceOfType(instance))
            {
                throw new InvalidCastException(
                    string.Format(CultureInfo.InvariantCulture, "Resource does not implement supplied interface: {0}", type.FullName));
            }

            lock (_lock)
            {
                if (_resources.ContainsKey(type))
                {
                    throw new ArgumentException(
                        string.Format(CultureInfo.InvariantCulture, "Resource is already existing : {0}", type.FullName));
                }
                _resources[type] = instance;
            }
        }

        #endregion

        #region Get

        /// <summary>
        /// 查找指定类型的资源实例。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <returns>资源实例</returns>
        public static T Get<T>() where T : class
        {
            return Get(typeof(T)) as T;
        }

        /// <summary>
        /// 查找指定类型的资源实例。
        /// </summary>
        /// <param name="type">The type of instance.</param>
        /// <returns>资源实例</returns>
        public static object Get(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            object resource;

            lock (_lock)
            {
                if (!_resources.TryGetValue(type, out resource))
                {
                    throw new KeyNotFoundException(type.FullName);
                }
            }

            if (resource == null)
            {
                throw new NullReferenceException(type.FullName);
            }

            return resource;
        }

        /// <summary>
        /// 尝试查找指定类型的资源实例。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="resource">资源实例</param>
        /// <returns>是否存在</returns>
        public static bool TryGet<T>(out T resource) where T : class
        {
            bool isFound = false;
            object target;
            resource = null;

            lock (_lock)
            {
                if (_resources.TryGetValue(typeof(T), out target))
                {
                    resource = target as T;
                    isFound = true;
                }
            }

            return isFound;
        }

        #endregion

        #region Register

        /// <summary>
        /// 注册类型。
        /// </summary>
        /// <typeparam name="T">实体类型，类型限制为有公共无参构造函数</typeparam>
        public static void RegisterType<T>() where T : class, new()
        {
            lock (_lock)
            {
                _mapping[typeof(T)] = typeof(T);
            }
        }

        /// <summary>
        /// 注册类型。
        /// </summary>
        /// <typeparam name="TFrom">资源类型</typeparam>
        /// <typeparam name="TTo">实体类型，类型限制为有公共无参构造函数</typeparam>
        public static void RegisterType<TFrom, TTo>()
            where TFrom : class
            where TTo : TFrom, new()
        {
            lock (_lock)
            {
                _mapping[typeof(TFrom)] = typeof(TTo);
                _mapping[typeof(TTo)] = typeof(TTo);
            }
        }

        /// <summary>
        /// 是否已注册此类型。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <returns>是否已注册此类型</returns>
        public static bool IsRegistered<T>()
        {
            lock (_lock)
            {
                return _mapping.ContainsKey(typeof(T));
            }
        }

        #endregion

        #region Resolve

        /// <summary>
        /// 获取类型实例。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <returns>类型实例</returns>
        public static T Resolve<T>()
          where T : class
        {
            T resource = default(T);

            bool existing = TryGet<T>(out resource);
            if (!existing)
            {
                ConstructorInfo constructor = null;

                lock (_lock)
                {
                    if (!_mapping.ContainsKey(typeof(T)))
                    {
                        throw new KeyNotFoundException(
                          string.Format(CultureInfo.InvariantCulture, "Cannot find the target type : {0}", typeof(T).FullName));
                    }

                    Type concrete = _mapping[typeof(T)];
                    constructor = concrete.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new Type[0], null);

                    if (constructor == null)
                    {
                        throw new NullReferenceException(
                          string.Format(CultureInfo.InvariantCulture, "Public constructor is missing for type : {0}", typeof(T).FullName));
                    }
                }

                Add<T>((T)constructor.Invoke(null));
            }

            return Get<T>();
        }

        #endregion

        #region Remove

        /// <summary>
        /// 移除指定类型的资源实例。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        public static void Remove<T>()
        {
            Teardown(typeof(T));
        }

        /// <summary>
        /// 移除指定类型的资源实例。
        /// </summary>
        /// <param name="type">资源类型</param>
        public static void Remove(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (_lock)
            {
                _resources.Remove(type);
            }
        }

        #endregion

        #region Teardown

        /// <summary>
        /// 拆除指定类型的资源实例及注册映射类型。
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        public static void Teardown<T>()
        {
            Teardown(typeof(T));
        }

        /// <summary>
        /// 拆除指定类型的资源实例及注册映射类型。
        /// </summary>
        /// <param name="type">资源类型</param>
        public static void Teardown(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (_lock)
            {
                _resources.Remove(type);
                _mapping.Remove(type);
            }
        }

        #endregion

        #region Clear

        /// <summary>
        /// 移除所有资源。
        /// </summary>
        public static void Clear()
        {
            lock (_lock)
            {
                _resources.Clear();
                _mapping.Clear();
            }
        }

        #endregion
    }
}
