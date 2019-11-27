using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyModel;

using Yuebon.Commons.Collections;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Finders;

namespace Yuebon.Commons.Reflection
{
    /// <summary>
    /// 应用程序目录程序集查找器
    /// </summary>
    public class AppDomainAllAssemblyFinder : FinderBase<Assembly>, IAllAssemblyFinder
    {
        private readonly bool _filterNetAssembly;

        /// <summary>
        /// 初始化一个<see cref="AppDomainAllAssemblyFinder"/>类型的新实例
        /// </summary>
        public AppDomainAllAssemblyFinder(bool filterNetAssembly = true)
        {
            _filterNetAssembly = filterNetAssembly;
        }

        /// <summary>
        /// 重写以实现程序集的查找
        /// </summary>
        /// <returns></returns>
        protected override Assembly[] FindAllItems()
        {
            string[] filters =
            {
                "System",
                "Microsoft",
                "netstandard",
                "dotnet",
                "Window",
                "mscorlib",
                "api-ms-win-core"
            };
            DependencyContext context = DependencyContext.Default;
            if (context != null)
            {
                List<string> names = new List<string>();
                string[] dllNames = context.CompileLibraries.SelectMany(m => m.Assemblies).Distinct().Select(m => m.Replace(".dll", "")).ToArray();
                if (dllNames.Length > 0)
                {
                    names = (from name in dllNames
                             let i = name.LastIndexOf('/') + 1
                             select name.Substring(i, name.Length - i)).Distinct()
                        .WhereIf(name => !filters.Any(name.StartsWith), _filterNetAssembly)
                        .ToList();
                }
                else
                {
                    foreach (CompilationLibrary library in context.CompileLibraries)
                    {
                        string name = library.Name;
                        if (_filterNetAssembly && filters.Any(name.StartsWith))
                        {
                            continue;
                        }
                        if (name == "OSharpNS")
                        {
                            continue;
                        }
                        if (name == "OSharpNS.Core")
                        {
                            name = "OSharp";
                        }
                        else if (name.StartsWith("OSharpNS."))
                        {
                            name = name.Replace("OSharpNS.", "Yuebon.Commons.");
                        }
                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                    }
                }
                return LoadFiles(names);
            }

            //遍历文件夹的方式，用于传统.netfx
            string path = Directory.GetCurrentDirectory();
            string[] files = Directory.GetFiles(path, "*.dll", SearchOption.TopDirectoryOnly)
                .Concat(Directory.GetFiles(path, "*.exe", SearchOption.TopDirectoryOnly))
                .ToArray();

            return files.Where(file => filters.All(token => Path.GetFileName(file)?.StartsWith(token) != true)).Select(Assembly.LoadFrom).ToArray();
        }

        private static Assembly[] LoadFiles(IEnumerable<string> files)
        {
            List<Assembly> assemblies = new List<Assembly>();
            foreach (string file in files)
            {
                AssemblyName name = new AssemblyName(file);
                try
                {
                    assemblies.Add(Assembly.Load(name));
                }
                catch (FileNotFoundException)
                { }
            }
            return assemblies.ToArray();
        }
    }
}