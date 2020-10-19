using AutoMapper;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Senparc.CO2NET;
using Senparc.CO2NET.AspNet;
using Senparc.CO2NET.Cache;
using Senparc.CO2NET.Cache.Memcached;
using Senparc.CO2NET.RegisterServices;
using Senparc.Weixin;
using Senparc.Weixin.Cache.Redis;
using Senparc.Weixin.Entities;
using Senparc.Weixin.RegisterServices;
using Senparc.Weixin.WxOpen;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons;
using Yuebon.Commons.Cache;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Log;
using Yuebon.Commons.Module;
using Yuebon.Commons.Options;
using Yuebon.Quartz.Jobs;

namespace Yuebon.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public static ILoggerRepository loggerRepository { get; set; }
        string targetPath = string.Empty;
        IMvcBuilder mvcBuilder;
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //初始化log4net
            loggerRepository = LogManager.CreateRepository("NETCoreRepository");
            Log4NetHelper.SetConfig(loggerRepository, "log4net.config");
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            //如果部署在linux系统上，需要加上下面的配置：
            //services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            //如果部署在IIS上，需要加上下面的配置：
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
            services.AddSwaggerGen(options =>
            {
                string contactName = Configuration.GetSection("SwaggerDoc:ContactName").Value;
                string contactNameEmail = Configuration.GetSection("SwaggerDoc:ContactEmail").Value;
                string contactUrl = Configuration.GetSection("SwaggerDoc:ContactUrl").Value;
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    
                    Version = Configuration.GetSection("SwaggerDoc:Version").Value,
                    Title = Configuration.GetSection("SwaggerDoc:Title").Value,
                    Description = Configuration.GetSection("SwaggerDoc:Description").Value,
                    Contact = new OpenApiContact { Name = contactName, Email = contactNameEmail, Url = new Uri(contactUrl) },
                    License = new OpenApiLicense { Name = contactName, Url = new Uri(contactUrl) }
                });
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
                {
                    options.IncludeXmlComments(file);
                });
                options.DocumentFilter<HiddenApiFilter>(); // 在接口类、方法标记属性 [HiddenApi]，可以阻止【Swagger文档】生成
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                options.OperationFilter<SwaggerFileUploadFilter>();
                //给api添加token令牌证书
                options.AddSecurityDefinition("CoreApi", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
            });
            //全局设置跨域访问
            services.AddCors(options => options.AddPolicy("yuebonCors",
                policy => policy.WithOrigins(Configuration.GetSection("AppSetting:AllowOrigins").Value.Split(',', StringSplitOptions.RemoveEmptyEntries)).AllowAnyHeader().AllowAnyMethod()));
            services.AddControllers().AddJsonOptions(options =>
            {
                //设置时间格式
                options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
                //设置bool获取格式
                options.JsonSerializerOptions.Converters.Add(new BooleanJsonConverter());
                //设置数字
                options.JsonSerializerOptions.Converters.Add(new IntJsonConverter());
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });

            services.AddSignalR();//使用 SignalR
            mvcBuilder = services.AddMvc(option =>
            {
                option.Filters.Add<YuebonAuthorizationFilter>();
                option.Filters.Add(new ExceptionHandlingAttribute());
            }).SetCompatibilityVersion(CompatibilityVersion.Latest).AddRazorRuntimeCompilation();

            services.AddMvcCore()
                .AddAuthorization().AddApiExplorer();

            // Api配置版本信息
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            

            services.AddSenparcGlobalServices(Configuration)
                .AddSenparcWeixinServices(Configuration); //Senparc.Weixin 注册（必须）;
            return InitIoC(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="senparcSetting"></param>
        /// <param name="senparcWeixinSetting"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            if (app != null)
            {
                IServiceProvider provider = app.ApplicationServices;
                AutoMapperService.UsePack(provider);
                //IRegisterService register = RegisterService.Start(env, senparcSetting.Value).UseSenparcGlobal();// 启动 CO2NET 全局注册，必须！
                //加载插件应用
                LoadMoudleApps(env);
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseStaticFiles();
                app.UseRouting();

                var registerService = app.UseSenparcGlobal(env, senparcSetting.Value, globalRegister =>
                {
                    globalRegister.ChangeDefaultCacheNamespace("DefaultCO2NETCache");

                }).UseSenparcWeixin(senparcWeixinSetting.Value, weixinRegister =>
                {
                    //微信的 Redis 缓存，如果不使用则注释掉（开启前必须保证配置有效，否则会抛错）         -- DPBMARK Redis

                    //weixinRegister.UseSenparcWeixinCacheCsRedis();//CsRedis，两选一
                    weixinRegister.UseSenparcWeixinCacheRedis();//StackExchange.Redis，两选一

                    //注册多个公众号或小程序（可注册多个）                                        -- DPBMARK MiniProgram
                    weixinRegister
                            .RegisterWxOpenAccount(senparcWeixinSetting.Value, "东方快车");// DPBMARK_END
                });
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseMiddleware<CorsMiddleware>();
                app.UseCors("yuebonCors");
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
                });
                app.UseStatusCodePages();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Yuebon System API V1");
                    options.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
                });
            }

            //定时任务调度
            // YuebonScheduler.Start().GetAwaiter().GetResult();
        }



        /// <summary>
        /// IoC初始化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider InitIoC(IServiceCollection services)
        {
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

                Senparc.CO2NET.Cache.Redis.Register.SetConfigurationOption(cacheProvider.ConnectionString);
                Senparc.CO2NET.Cache.Redis.Register.UseKeyValueRedisNow();//键值对缓存策略（推荐）
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
                string memcachedConfigurationStr = "";
                /* 说明：
                        * 1、Memcached 的连接字符串信息会从 Config.SenparcSetting.Cache_Memcached_Configuration 自动获取并注册，如不需要修改，下方方法可以忽略
                    /* 2、如需手动修改，可以通过下方 SetConfigurationOption 方法手动设置 Memcached 链接信息（仅修改配置，不立即启用）
                        */
                Senparc.CO2NET.Cache.Memcached.Register.SetConfigurationOption(memcachedConfigurationStr);

                //以下会立即将全局缓存设置为 Memcached
                Senparc.CO2NET.Cache.Memcached.Register.UseMemcachedNow();

                //也可以通过以下方式自定义当前需要启用的缓存策略
                CacheStrategyFactory.RegisterObjectCacheStrategy(() => MemcachedObjectCacheStrategy.Instance);

            }
            services.AddDbContext<BaseDbContext>(options =>
                   options.UseSqlServer(Configs.GetConnectionString("MsSqlServer")));

            var jwtConfig = Configuration.GetSection("Jwt");
            var jwtOption = new JwtOption
            {
                Issuer = jwtConfig["Issuer"],
                Expiration = Convert.ToInt16(jwtConfig["Expiration"]),
                Secret = jwtConfig["Secret"],
                Audience = jwtConfig["Audience"],
                refreshJwtTime = Convert.ToInt16(jwtConfig["refreshJwtTime"])
            };

            var senparcSettingConfig = Configuration.GetSection("SenparcSetting");
            var senparcSetting = new SenparcSetting
            {
                IsDebug = senparcSettingConfig["IsDebug"].ToBool(),
                DefaultCacheNamespace = senparcSettingConfig["DefaultCacheNamespace"],
                Cache_Redis_Configuration = cacheProvider.ConnectionString,
                Cache_Memcached_Configuration = senparcSettingConfig["Cache_Memcached_Configuration"],
                SenparcUnionAgentKey = senparcSettingConfig["SenparcUnionAgentKey"]
            };
            var weixinConfig = Configuration.GetSection("SenparcWeixinSetting");
            var senparcWeixinSettingItem = new SenparcWeixinSettingItem
            {
                Component_Appid = weixinConfig["OpenWebsiteAppId"],
                Component_Secret = weixinConfig["OpenWebsiteAppSecret"]
            };
            SenparcWeixinSettingItemCollection items = new SenparcWeixinSettingItemCollection();
            items.Add("OpenWebAdmin", senparcWeixinSettingItem);
            var senparcWeixinSetting = new SenparcWeixinSetting
            {
                WxOpenAppId = weixinConfig["WxOpenAppId"],
                WxOpenAppSecret = weixinConfig["WxOpenAppSecret"],
                WxOpenToken = weixinConfig["WxOpenToken"],
                WxOpenEncodingAESKey = weixinConfig["WxOpenEncodingAESKey"],
                Items = items
            };
            Senparc.CO2NET.Config.SenparcSetting = senparcSetting;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; ;

            }).AddJwtBearer(jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtOption.Secret)),//秘钥
                    ValidateIssuer = true,
                    ValidIssuer = jwtOption.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtOption.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };
            });
            services.AddScoped(typeof(SSOAuthHelper));
            services.AddTransient<HttpResultfulJob>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            IoCContainer.Register(cacheProvider);//注册缓存配置
            IoCContainer.Register(Configuration);//注册配置
            IoCContainer.Register(jwtOption);//注册配置
            IoCContainer.Register(typeof(SenparcWeixinSetting));//注册配置
            IoCContainer.Register("Yuebon.Commons");
            IoCContainer.Register("Yuebon.AspNetCore");
            IoCContainer.Register("Yuebon.Security.Core");
            IoCContainer.RegisterNew("Yuebon.Security.Core", "Yuebon.Security");
            IoCContainer.Register("Yuebon.Messages.Core");
            IoCContainer.RegisterNew("Yuebon.Messages.Core", "Yuebon.Messages");
            List<Assembly> myAssembly = new List<Assembly>();
            myAssembly.Add(Assembly.Load("Yuebon.Security.Core"));
            services.AddAutoMapper(myAssembly);
            services.AddScoped<IMapper, Mapper>();

            ////注册数据库基础操作和工作单元
            //services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
            //设置定时启动的任务
            services.AddHostedService<QuartzService>();

            //开始注册微信信息，必须！

            //IRegisterService registerService = RegisterService.Start(senparcSetting).UseSenparcGlobal();
            //registerService.UseSenparcWeixin(senparcWeixinSetting, senparcSetting)
            //    .RegisterWxOpenAccount(senparcWeixinSetting, "东方快车");
            return IoCContainer.Build(services);
        }

        /// <summary>
        /// 加载模块应用
        /// </summary>
        /// <param name="env"></param>
        private void LoadMoudleApps(IWebHostEnvironment env)
        {
            // 定位到插件应用目录 Apps
            var apps = env.ContentRootFileProvider.GetFileInfo("Apps");
            if (!Directory.Exists(apps.PhysicalPath))
            {
                return;
            }

            // 把 Apps 下的动态库拷贝一份来运行，
            // 使 Apps 中的动态库不会在运行时被占用（以便重新编译）
            var shadows = targetPath = PrepareShadowCopies();
            // 从 Shadow Copy 目录加载 Assembly 并注册到 Mvc 中
            LoadFromShadowCopies(shadows);

            string PrepareShadowCopies()
            {
                // 准备 Shadow Copy 的目标目录
                var target = Path.Combine(env.ContentRootPath, "app_data", "apps-cache");
                Directory.CreateDirectory(target);

                // 找到插件目录下 bin 目录中的 .dll，拷贝
                Directory.EnumerateDirectories(apps.PhysicalPath)
                    .Select(path => Path.Combine(path, "bin"))
                    .Where(Directory.Exists)
                    .SelectMany(bin => Directory.EnumerateFiles(bin, "*.dll"))
                    .ForEach(dll => File.Copy(dll, Path.Combine(target, Path.GetFileName(dll)), true));

                return target;
            }

            void LoadFromShadowCopies(string targetPath)
            {
                foreach (string dll in Directory.GetFiles(targetPath, "*.dll"))
                {
                    try
                    {
                        //解决插件还引用其他主程序没有引用的第三方dll问题System.IO.FileNotFoundException
                        AssemblyLoadContext.Default.LoadFromAssemblyPath(dll);
                    }
                    catch (Exception ex)
                    {
                        //非.net程序集类型的dll关联load时会报错，这里忽略就可以
                       Log4NetHelper.Error(ex.Message);
                    }
                }
                // 从 Shadow Copy 目录加载 Assembly 并注册到 Mvc 中
                var groups = Directory.EnumerateFiles(targetPath, "Yuebon.*App.Api.dll").Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);

                // 直接加载到为 ApplicationPart
                groups.ForEach(mvcBuilder.AddApplicationPart);
            }
        }
    }
}
