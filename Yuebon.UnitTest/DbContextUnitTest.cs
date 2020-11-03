using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Yuebon.Commons.IoC;
using Yuebon.Commons.IDbContext;
using Yuebon.Security.Models;
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.Options;
using AutoMapper;
using System.Reflection;
using Yuebon.Commons.Extensions;

namespace Yuebon.UnitTest
{
    [TestClass]
    public class DbContextUnitTest
    {
        [TestMethod]
        public void TestCompileQuery()
        {
            BuildServiceForSqlServer();
            var dbContext = ServiceLocator.Resolve<IDbContextCore>();
            var watch = new Stopwatch();
            watch.Start();
            dbContext.Get<Log>(m => m.EnabledMark);
            watch.Stop();
            Console.WriteLine($"Get --> {watch.ElapsedMilliseconds} ms.");
            watch.Restart();
            dbContext.GetByCompileQuery<Log>(m => m.EnabledMark);
            watch.Stop();
            Console.WriteLine($"GetByCompileQuery --> {watch.ElapsedMilliseconds} ms.");
        }

        #region public methods

        public void BuildServiceForSqlServer()
        {
            IServiceCollection services = new ServiceCollection();
            //IoCContainer.Register(cacheProvider);//注册缓存配置
            //IoCContainer.Register(Configuration);//注册配置
            //IoCContainer.Register(jwtOption);//注册配置
            IoCContainer.Register("Yuebon.Commons");
            IoCContainer.Register("Yuebon.AspNetCore");
            IoCContainer.Register("Yuebon.Security.Core");
            IoCContainer.RegisterNew("Yuebon.Security.Core", "Yuebon.Security");
            //IoCContainer.Register("Yuebon.Messages.Core");
            //IoCContainer.RegisterNew("Yuebon.Messages.Core", "Yuebon.Messages");
            List<Assembly> myAssembly = new List<Assembly>();
            myAssembly.Add(Assembly.Load("Yuebon.Security.Core"));
            services.AddAutoMapper(myAssembly);
            services.AddScoped<IMapper, Mapper>();

            //在这里注册EF上下文
            services = RegisterSqlServerContext(services);

            services.AddOptions(); 
            services.BuildServiceProvider();
            IoCContainer.Build(services);
        }

        /// <summary>
        /// 注册SQLServer上下文
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceCollection RegisterSqlServerContext(IServiceCollection services)
        {
            services.Configure<DbContextOption>(options =>
            {
                options.ConnectionString =
                    "initial catalog=NetCoreDemo;data source=.;password=admin123!@#;User id=sa;MultipleActiveResultSets=True;";
                options.ModelAssemblyName = "Zxw.Framework.UnitTest";
                options.IsOutputSql = false;
            });
            services.AddScoped<IDbContextCore, SqlServerDbContext>(); //注入EF上下文
            return services;
        }
        #endregion

    }
}
