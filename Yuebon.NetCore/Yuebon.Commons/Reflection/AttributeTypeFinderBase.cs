using System;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Finders;


namespace Yuebon.Commons.Reflection
{
    /// <summary>
    /// 标注了指定<see cref="Attribute"/>特性的类型的查找器基类
    /// </summary>
    /// <typeparam name="TAttributeType">标注的<see cref="Attribute"/>类型</typeparam>
    public class AttributeTypeFinderBase<TAttributeType> : FinderBase<Type>, ITypeFinder
        where TAttributeType : Attribute
    {
        private readonly IAllAssemblyFinder _allAssemblyFinder;

        /// <summary>
        /// 初始化一个<see cref="AttributeTypeFinderBase{TAttributeType}"/>类型的新实例
        /// </summary>
        public AttributeTypeFinderBase(IAllAssemblyFinder allAssemblyFinder)
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
                .Where(type => type.IsClass && !type.IsAbstract && type.HasAttribute<TAttributeType>()).Distinct().ToArray();
        }
    }
}