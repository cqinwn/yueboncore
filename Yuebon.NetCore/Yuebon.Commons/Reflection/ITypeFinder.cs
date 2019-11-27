using System;
using Yuebon.Commons.Dependency;
using Yuebon.Commons.Finders;


namespace Yuebon.Commons.Reflection
{
    /// <summary>
    /// 定义类型查找行为
    /// </summary>
    [IgnoreDependency]
    public interface ITypeFinder : IFinder<Type>
    { }
}