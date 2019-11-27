using System.Reflection;

using Yuebon.Commons.Dependency;
using Yuebon.Commons.Finders;



namespace Yuebon.Commons.Reflection
{
    /// <summary>
    /// 定义程序集查找器
    /// </summary>
    [IgnoreDependency]
    public interface IAssemblyFinder : IFinder<Assembly>
    { }
}