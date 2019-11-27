using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Repositories;
using Yuebon.Commons.Entity;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Log;

namespace Yuebon.Commons.Module
{
    /// <summary>
    /// 
    /// </summary>
    public class MoudleService
    {
        /// <summary>
        /// 实现应用模块程序集的注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider LoaderMoudleService(IServiceCollection services)
        {
           // services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            var apps = AppContext.BaseDirectory + "Apps";
            if (!Directory.Exists(apps))
            {
                Directory.CreateDirectory(apps);
            }
            // 把 Apps 下的动态库拷贝一份来运行，
            // 使 Apps 中的动态库不会在运行时被占用（以便重新编译）
            var targetPath = PrepareShadowCopies();
            // 从 Shadow Copy 目录加载 Assembly 并注册到 Mvc 中
            //LoadFromShadowCopies(targetPath);

            string PrepareShadowCopies()
            {
                // 准备 Shadow Copy 的目标目录
                var target = Path.Combine(AppContext.BaseDirectory, "app_data", "apps-cache");

                if (!Directory.Exists(target))
                {
                    Directory.CreateDirectory(target);
                }
                // 找到插件目录下 bin 目录中的 .dll，拷贝
                 Directory.EnumerateDirectories(apps)
                    .Select(path => Path.Combine(path, "bin"))
                    .Where(Directory.Exists)
                    .SelectMany(bin => Directory.EnumerateFiles(bin, "*.dll"))
                    .ForEach(dll => File.Copy(dll, Path.Combine(target, Path.GetFileName(dll)), true));

                return target;
            }

            DirectoryInfo folder = new DirectoryInfo(targetPath);
            List<Assembly> myAssembly = new List<Assembly>();
            myAssembly.Add(Assembly.Load("Yuebon.Security.Core"));
            if (File.Exists(AppContext.BaseDirectory+ "Yuebon.Messages.Core.dll"))
            {
                myAssembly.Add(Assembly.Load("Yuebon.Messages.Core"));
            }
            foreach (FileInfo finfo in folder.GetFiles("*.Core.dll"))
            {
                try
                {
                    myAssembly.Add(Assembly.LoadFrom(finfo.FullName));
                    string dllNamespaceStr = finfo.Name.Substring(0, finfo.Name.IndexOf(".Core"));
                    IoCContainer.RegisterFrom(finfo.FullName);
                    IoCContainer.RegisterLoadFrom(finfo.FullName, dllNamespaceStr);
                    var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
                    Log4NetHelper.WriteInfo(type, "注入应用模块" + finfo.Name + "成功");
                }
                catch (Exception ex)
                {
                    var type = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType;
                    Log4NetHelper.WriteError(type, "注入应用模块" + finfo.Name + "失败\r\n" + ex.Message);
                }
            }

            services.AddAutoMapper(myAssembly);
            services.AddScoped<IMapper, Mapper>();

            return IoCContainer.Build(services);
        }

    }
}
