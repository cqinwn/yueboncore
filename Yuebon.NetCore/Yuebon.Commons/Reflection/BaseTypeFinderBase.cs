using System;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Finders;


namespace Yuebon.Commons.Reflection
{
    /// <summary>
    /// 指定基类的实现类型查找器基类
    /// </summary>
    /// <typeparam name="TBaseType">要查找类型的基类</typeparam>
    public abstract class BaseTypeFinderBase<TBaseType> : FinderBase<Type>, ITypeFinder
    {
        private readonly IAllAssemblyFinder _allAssemblyFinder;

        /// <summary>
        /// 初始化一个<see cref="BaseTypeFinderBase{TBaseType}"/>类型的新实例
        /// </summary>
        protected BaseTypeFinderBase(IAllAssemblyFinder allAssemblyFinder)
        {
            _allAssemblyFinder = allAssemblyFinder;
        }

        /// <summary>
        /// 重写以实现所有项的查找
        /// </summary>
        /// <returns></returns>
        protected override Type[] FindAllItems()
        {
            Assembly[] assemblies = _allAssemblyFinder.FindAll(true);
            return assemblies.SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsDeriveClassFrom<TBaseType>()).Distinct().ToArray();
        }
    }
}