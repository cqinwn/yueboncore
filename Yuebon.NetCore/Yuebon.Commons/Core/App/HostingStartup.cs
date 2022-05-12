using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Extensions;
//通过HostingStartup指定要启动的类型
[assembly: HostingStartup(typeof(Yuebon.Commons.Core.App.HostingStartup))]
namespace Yuebon.Commons.Core.App
{
    /// <summary>
    /// 配置程序启动时自动注入
    /// </summary>
    public sealed class HostingStartup : IHostingStartup
    {
        /// <summary>
        /// 配置应用启动
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(IWebHostBuilder builder)
        {
            //可以添加配置
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                // 自动装载配置
                Appsettings.AddConfigureFiles(config, hostingContext.HostingEnvironment);
            });

            //可以添加ConfigureServices
            // 自动注入 AddApp() 服务
            builder.ConfigureServices(services =>
            {
                
            });
        }
    }
}
