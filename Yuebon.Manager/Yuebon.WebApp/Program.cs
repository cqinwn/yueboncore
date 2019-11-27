using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Yuebon.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //注册编码提供程序
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json").Build();
            WebHost.CreateDefaultBuilder(args).UseConfiguration(config).UseStartup<Startup>().Build().Run();
            //CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
