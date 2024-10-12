using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using System.Runtime.Loader;
using Yuebon.Commons.Options;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class RuntimeHelper
    {
        /// <summary>
        /// 获取项目程序集，排除所有的系统程序集(Microsoft.***、System.***等)、Nuget下载包
        /// </summary>
        /// <returns></returns>
        public static List<Assembly> GetAllAssemblies()
        {
            var list = new List<Assembly>();
            var deps = DependencyContext.Default;
            //排除所有的系统程序集、Nuget下载包
            var libs = deps.CompileLibraries.Where(lib => lib.Type == AssembleTypeConsts.Project);//只获取本项目用到的包
            foreach (var lib in libs)
            {
                try
                {
                    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                    list.Add(assembly);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return list;
        }
        /// <summary>
        /// 获取项目程序集，排除所有的系统程序集(Microsoft.***、System.***等)、Nuget下载包和Yuebon.Commons.dll
        /// 获取所有关于Yuebon的程序集
        /// </summary>
        /// <returns></returns>
        public static List<Assembly> GetAllYuebonAssemblies()
        {
            var list = new List<Assembly>();
            var deps = DependencyContext.Default;
            //排除所有的系统程序集、Nuget下载包
            var libs = deps.CompileLibraries.Where(lib => lib.Type == AssembleTypeConsts.Project);//只获取本项目用到的包
            foreach (var lib in libs)
            {
                try
                {
                    if (lib.Name != "Yuebon.Commons")
                    {
                        var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name));
                        list.Add(assembly);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            //string targetPath = AppDomain.CurrentDomain.BaseDirectory + "Modules";
            //string[] dlls = Directory.GetFiles(targetPath, "*.dll");
            //foreach (string dll in dlls)
            //{
            //    try
            //    {
            //        //解决插件还引用其他主程序没有引用的第三方dll问题System.IO.FileNotFoundException
            //        var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
            //        if (assembly.FullName.StartsWith("Yuebon.WCS") && !list.Contains(assembly) && assembly.GetName().Name != "Yuebon.Commons")
            //        {
            //            list.Add(assembly);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //非.net程序集类型的dll关联load时会报错，这里忽略就可以
            //        Log4NetHelper.Error(ex.Message);
            //    }
            //}
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static Assembly GetAssembly(string assemblyName)
        {
            return GetAllYuebonAssemblies().FirstOrDefault(assembly => assembly.FullName.Contains(assemblyName));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IList<Type> GetAllTypes()
        {
            var list = new List<Type>();
            foreach (var assembly in GetAllAssemblies())
            {
                var typeInfos = assembly.DefinedTypes;
                foreach (var typeInfo in typeInfos)
                {
                    list.Add(typeInfo.AsType());
                }
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public static IList<Type> GetTypesByAssembly(string assemblyName)
        {
            var list = new List<Type>();
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
            var typeInfos = assembly.DefinedTypes;
            foreach (var typeInfo in typeInfos)
            {
                list.Add(typeInfo.AsType());
            }
            return list;
        }
        /// <summary>
        /// 获取实现类
        /// </summary>
        /// <param name="typeName"></param>
        /// <param name="baseInterfaceType"></param>
        /// <returns></returns>
        public static Type GetImplementType(string typeName, Type baseInterfaceType)
        {
            return GetAllTypes().FirstOrDefault(t =>
            {
                if (t.Name == typeName &&
                    t.GetTypeInfo().GetInterfaces().Any(b => b.Name == baseInterfaceType.Name))
                {
                    var typeInfo = t.GetTypeInfo();
                    return typeInfo.IsClass && !typeInfo.IsAbstract && !typeInfo.IsGenericType;
                }
                return false;
            });
        }
    }
}
