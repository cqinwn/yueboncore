using AutoMapper;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using UEditorNetCore;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Module;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Filters;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Log;
using Yuebon.Commons.Options;
//using Yuebon.Quartz;

namespace Yuebon.WebApp
{
    public class Startup
    {
        public static ILoggerRepository Logrepository { get; set; }
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //初始化log4net
            Logrepository = LogManager.CreateRepository("NETCoreRepository");
            Log4NetHelper.SetConfig(Logrepository, "log4net.config");
            //定时任务调度
            //YuebonScheduler.Start().GetAwaiter().GetResult();
            //初始化映射关系
            //SecurityMapper.Initialize();
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
            });
            //UEditor富文本编辑器
            services.AddUEditorService();
            //AutoMapper
            //services.AddAutoMapper();
            services.AddControllersWithViews().AddRazorRuntimeCompilation()
                .AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddMvc(option =>
            {
                option.Filters.Add(new GlobalExceptionFilter());
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //Session 过期时长分钟
            var sessionOutTime = Configuration.GetValue<int>("AppSetting:SessionTimeOut", 30);
            //Session服务
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(sessionOutTime);
            });
            services.AddDataProtection().SetDefaultKeyLifetime(TimeSpan.FromDays(14));

            ////进行cookie的依赖注入
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {//自定义登陆地址，不配置的话则默认为http://localhost:5000/Account/Login
            //        options.LoginPath = "/Login/GetCheckUser";
            //    });
            return InitIoC(services);
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {
            IServiceProvider provider = app.ApplicationServices;
            AutoMapperService.UsePack(provider);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            //Session,必须在 UseMvc 之前调用
            app.UseSession();
            //app.UseAuthentication();
            //将 对象 IHttpContextAccessor 注入 HttpContextHelper 静态对象中
            HttpContextHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute("default", "{controller=Login}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(name: "areas", "areas",pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            #region 解决Ubuntu Nginx 代理不能获取IP问题
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion
        }


        /// <summary>
        /// IoC初始化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider InitIoC(IServiceCollection services)
        {
             
            //数据连接
            //var connectionString = Configuration.GetConnectionString("MsSqlServer");

            var codeGenerateOption = new CodeGenerateOption
            {
                ModelsNamespace = "Yuebon.CMS.Models",
                IRepositoriesNamespace = "Yuebon.CMS.IRepositories",
                RepositoriesNamespace = "Yuebon.CMS.Repositories",
                IServicsNamespace = "Yuebon.CMS.IServices",
                ServicesNamespace = "Yuebon.CMS.Services"
            };

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();

            CacheProvider cacheProvider = new CacheProvider
            {
                IsUseRedis = Configuration.GetSection("CacheProvider:UseRedis").Value.ToBool(false),
                ConnectionString = Configuration.GetSection("CacheProvider:Redis_ConnectionString").Value,
                InstanceName = Configuration.GetSection("CacheProvider:Redis_InstanceName").Value
            };
            //判断是否使用Redis，如果不使用 Redis就默认使用 MemoryCache
            if (cacheProvider.IsUseRedis)
            {
                //Use Redis
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = cacheProvider.ConnectionString;
                    options.InstanceName = cacheProvider.InstanceName;
                });
                services.AddSingleton(typeof(ICacheService), new RedisCacheService(new RedisCacheOptions
                {
                    Configuration = cacheProvider.ConnectionString,
                    InstanceName = cacheProvider.InstanceName
                }, 0));
            }
            else
            {
                //Use MemoryCache
                services.AddSingleton<IMemoryCache>(factory =>
                {
                    var cache = new MemoryCache(new MemoryCacheOptions());
                    return cache;
                });
                services.AddSingleton<ICacheService, MemoryCacheService>();
            }
            services.AddScoped(typeof(SSOAuthHelper));
            services.AddScoped(typeof(AuthHelper));
            IoCContainer.Register(cacheProvider);//注册缓存配置
            IoCContainer.Register(Configuration);//注册配置
            IoCContainer.Register(codeGenerateOption);//注册代码生成器相关配置信息
            IoCContainer.Register("Yuebon.Commons");
            IoCContainer.Register("Yuebon.AspNetCore");
            IoCContainer.Register("Yuebon.Security.Core");
            IoCContainer.Register("Yuebon.CMS.Core");
            IoCContainer.RegisterNew("Yuebon.Security.Core", "Yuebon.Security");
            IoCContainer.RegisterNew("Yuebon.CMS.Core", "Yuebon.CMS");

            List<Assembly> myAssembly = new List<Assembly>();
            myAssembly.Add(Assembly.Load("Yuebon.CMS.Core"));
            myAssembly.Add(Assembly.Load("Yuebon.Security.Core"));
            services.AddAutoMapper(myAssembly);
            services.AddScoped<IMapper, Mapper>();
            return MoudleService.LoaderMoudleService(services);
        }
    }
}
