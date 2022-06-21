using AutoMapper.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Options;

namespace Yuebon.Commons.Core.App
{
    /// <summary>
    /// 全局应用类
    /// </summary>
    public  class Appsettings
    {

        /// <summary>
        /// 构造函数
        /// </summary>
        static Appsettings()
        {
            //// 未托管的对象

            //// 加载程序集
            //var assObject = GetAssemblies();
            //Assemblies = assObject.Assemblies;
            //ExternalAssemblies = assObject.ExternalAssemblies;

            //// 获取有效的类型集合
            EffectiveTypes = RuntimeHelper.GetAllTypes();

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Appsettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 全局配置选项
        /// </summary>
        public static IConfiguration Configuration { get; set; }
        /// <summary>
        ///  应用服务
        /// </summary>
        public static IServiceCollection Services;
        /// <summary>
        /// 全局配置构建器
        /// </summary>
        private static IConfigurationBuilder ConfigurationBuilder;
        /// <summary>
        /// 私有环境变量，避免重复解析
        /// </summary>
        private static IWebHostEnvironment _webHostEnvironment;

        /// <summary>
        /// 应用环境，如，是否是开发环境，生产环境等
        /// </summary>
        public static IWebHostEnvironment WebHostEnvironment => _webHostEnvironment ??= GetService<IWebHostEnvironment>();

        /// <summary>
        /// 应用有效程序集
        /// </summary>
        public static readonly IEnumerable<Assembly> Assemblies;

        /// <summary>
        /// 有效程序集类型
        /// </summary>
        public static readonly IEnumerable<Type> EffectiveTypes;

        /// <summary>
        /// 服务提供器
        /// </summary>
        public static IServiceProvider ServiceProvider => HttpContext?.RequestServices ?? Services.BuildServiceProvider();

        /// <summary>
        /// 获取请求上下文
        /// </summary>
        public static HttpContext HttpContext => HttpContextLocal.Current();
        /// <summary>
        /// 用户信息
        /// </summary>
        public static UserInfo User { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static ClaimsPrincipal UserClaims { get; set; }

        /// <summary>
        /// 获取请求生命周期的服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService GetService<TService>()
            where TService : class
        {
            return GetService(typeof(TService)) as TService;
        }

        /// <summary>
        /// 获取请求生命周期的服务
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetService(Type type)
        {
            return ServiceProvider.GetService(type);
        }

        /// <summary>
        /// 获取请求生命周期的服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        public static TService GetRequiredService<TService>()
            where TService : class
        {
            return GetRequiredService(typeof(TService)) as TService;
        }

        /// <summary>
        /// 获取请求生命周期的服务
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object GetRequiredService(Type type)
        {
            return ServiceProvider.GetRequiredService(type);
        }

        /// <summary>
        /// 获取选项
        /// </summary>
        /// <typeparam name="TOptions">强类型选项类</typeparam>
        /// <returns>TOptions</returns>
        public static TOptions GetOptions<TOptions>()
            where TOptions : class, new()
        {
            return GetService<IOptions<TOptions>>()?.Value;
        }

        /// <summary>
        /// 获取选项
        /// </summary>
        /// <typeparam name="TOptions">强类型选项类</typeparam>
        /// <returns>TOptions</returns>
        public static TOptions GetOptionsMonitor<TOptions>()
            where TOptions : class, new()
        {
            return GetService<IOptionsMonitor<TOptions>>()?.CurrentValue;
        }

        /// <summary>
        /// 获取选项
        /// </summary>
        /// <typeparam name="TOptions">强类型选项类</typeparam>
        /// <returns>TOptions</returns>
        public static TOptions GetOptionsSnapshot<TOptions>()
            where TOptions : class, new()
        {
            return GetService<IOptionsSnapshot<TOptions>>()?.Value;
        }



        #region


        /// <summary>
        /// 添加配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="env"></param>
        internal static void AddConfigureFiles(IConfigurationBuilder config, IHostEnvironment env)
        {
            // 读取忽略的配置文件
            var ignoreConfigurationFiles = config.Build()
                .GetSection("IgnoreConfigurationFiles").Get<string[]>()
                ?? Array.Empty<string>();

            // 加载配置
            AutoAddJsonFiles(config, env, ignoreConfigurationFiles);
            AutoAddXmlFiles(config, env, ignoreConfigurationFiles);

            // 存储配置
            ConfigurationBuilder = config;
        }
        /// <summary>
        /// 自动加载自定义 .json 配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="env"></param>
        /// <param name="ignoreConfigurationFiles"></param>
        public static void AutoAddJsonFiles(IConfigurationBuilder config, IHostEnvironment env, string[] ignoreConfigurationFiles)
        {
            // 获取程序目录下的所有配置文件
            var jsonFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.json", SearchOption.TopDirectoryOnly)
                .Union(
                    Directory.GetFiles(Directory.GetCurrentDirectory(), "*.json", SearchOption.TopDirectoryOnly)
                )
                .Where(u => !excludeJsons.Contains(Path.GetFileName(u)) && !ignoreConfigurationFiles.Contains(Path.GetFileName(u)) && !runtimeJsonSuffixs.Any(j => u.EndsWith(j)));

            if (!jsonFiles.Any()) return;

            // 获取环境变量名
            var envName = env.EnvironmentName;
            var envFiles = new List<string>();

            // 自动加载配置文件
            foreach (var jsonFile in jsonFiles)
            {
                // 处理带环境的配置文件
                if (Path.GetFileNameWithoutExtension(jsonFile).EndsWith($".{envName}"))
                {
                    envFiles.Add(jsonFile);
                    continue;
                }

                config.AddJsonFile(jsonFile, optional: true, reloadOnChange: true);
            }

            // 配置带环境的配置文件
            envFiles.ForEach(u => config.AddJsonFile(u, optional: true, reloadOnChange: true));
        }

        /// <summary>
        /// 自动加载自定义 .xml 配置文件
        /// </summary>
        /// <param name="config"></param>
        /// <param name="env"></param>
        /// <param name="ignoreConfigurationFiles"></param>
        public   static void AutoAddXmlFiles(IConfigurationBuilder config, IHostEnvironment env, string[] ignoreConfigurationFiles)
        {
            // 获取程序目录下的所有配置文件，必须以 .config.xml 结尾
            var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
                .Union(
                    Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml", SearchOption.TopDirectoryOnly)
                )
                .Where(u => !ignoreConfigurationFiles.Contains(Path.GetFileName(u)) && u.EndsWith(".config.xml", StringComparison.OrdinalIgnoreCase));

            if (!xmlFiles.Any()) return;

            // 获取环境变量名
            var envName = env.EnvironmentName;
            var envFiles = new List<string>();

            // 自动加载配置文件
            foreach (var xmlFile in xmlFiles)
            {
                // 处理带环境的配置文件
                if (Path.GetFileNameWithoutExtension(xmlFile).EndsWith($".{envName}.config"))
                {
                    envFiles.Add(xmlFile);
                    continue;
                }

                config.AddXmlFile(xmlFile, optional: true, reloadOnChange: true);
            }

            // 配置带环境的配置文件
            envFiles.ForEach(u => config.AddXmlFile(u, optional: true, reloadOnChange: true));
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string app(params string[] sections)
        {
            try
            {

                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception) { }

            return "";
        }

        /// <summary>
        /// 递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> app<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            // 引用 Microsoft.Extensions.Configuration.Binder 包
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }


        /// <summary>
        /// 根据路径  configuration["App:Name"];
        /// </summary>
        /// <param name="sectionsPath"></param>
        /// <returns></returns>
        public static string GetValue(string sectionsPath)
        {
            try
            {
                return Configuration[sectionsPath];
            }
            catch (Exception) { }

            return "";

        }
        /// <summary>
        /// 默认排除配置项
        /// </summary>
        private static readonly string[] excludeJsons = new[] {
            "appsettings.json",
            "appsettings.Development.json",
            "appsettings.Production.json",
            "bundleconfig.json",
            "bundleconfig.Development.json",
            "bundleconfig.Production.json",
            "compilerconfig.json",
            "compilerconfig.Development.json",
            "compilerconfig.Production.json"
        };

        /// <summary>
        /// 排除运行时 Json 后缀
        /// </summary>
        private static readonly string[] runtimeJsonSuffixs = new[]
        {
            "deps.json",
            "runtimeconfig.dev.json",
            "runtimeconfig.prod.json",
            "runtimeconfig.json"
        };


        /// <summary>
        /// 获取应用有效程序集
        /// </summary>
        /// <returns>IEnumerable</returns>
        //private static (IEnumerable<Assembly> Assemblies, IEnumerable<Assembly> ExternalAssemblies) GetAssemblies()
        //{
        //    // 需排除的程序集后缀
        //    var excludeAssemblyNames = new string[] {
        //        "Database.Migrations"
        //    };

        //    // 读取应用配置
        //    var supportPackageNamePrefixs = Settings.SupportPackageNamePrefixs ?? Array.Empty<string>();

        //    var dependencyContext = DependencyContext.Default;

        //    // 读取项目程序集或 Furion 官方发布的包，或手动添加引用的dll，或配置特定的包前缀
        //    var scanAssemblies = dependencyContext.RuntimeLibraries
        //        .Where(u =>
        //               (u.Type == "project" && !excludeAssemblyNames.Any(j => u.Name.EndsWith(j))) ||
        //               (u.Type == "package" && (u.Name.StartsWith(nameof(Furion)) || supportPackageNamePrefixs.Any(p => u.Name.StartsWith(p)))) ||
        //               (Settings.EnabledReferenceAssemblyScan == true && u.Type == "reference"))    // 判断是否启用引用程序集扫描
        //        .Select(u => Reflect.GetAssembly(u.Name));

        //    IEnumerable<Assembly> externalAssemblies = Array.Empty<Assembly>();

        //    // 加载 `appsetting.json` 配置的外部程序集
        //    if (Settings.ExternalAssemblies != null && Settings.ExternalAssemblies.Any())
        //    {
        //        foreach (var externalAssembly in Settings.ExternalAssemblies)
        //        {
        //            // 加载外部程序集
        //            var assemblyFileFullPath = Path.Combine(AppContext.BaseDirectory
        //                , externalAssembly.EndsWith(".dll") ? externalAssembly : $"{externalAssembly}.dll");

        //            // 根据路径加载程序集
        //            var loadedAssembly = Reflect.LoadAssembly(assemblyFileFullPath);
        //            if (loadedAssembly == default) continue;
        //            var assembly = new[] { loadedAssembly };

        //            // 合并程序集
        //            scanAssemblies = scanAssemblies.Concat(assembly);
        //            externalAssemblies = externalAssemblies.Concat(assembly);
        //        }
        //    }

        //    return (scanAssemblies, externalAssemblies);
        //}
        #endregion
    }
}
