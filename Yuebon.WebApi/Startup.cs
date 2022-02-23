using AutoMapper;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Yuebon.AspNetCore.Common;
using Yuebon.AspNetCore.Mvc;
using Yuebon.AspNetCore.Mvc.Filter;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IDbContext;
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
        public static ILoggerRepository LoggerRepository { get; set; }
        string targetPath = string.Empty;
        IMvcBuilder mvcBuilder;
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        private IApiVersionDescriptionProvider apiVersionProvider;//api接口版本控制
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //初始化log4net
            LoggerRepository = LogManager.CreateRepository("NETCoreRepository");
            Log4NetHelper.SetConfig(LoggerRepository, "log4net.config");
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            //services.AddSingleton(Configuration);
            //如果部署在linux系统上，需要加上下面的配置：
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            //如果部署在IIS上，需要加上下面的配置：
            services.AddOptions();
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

            #region Swagger Api文档

            // Api多版本版本配置
            services.AddApiVersioning(o =>
            {
                //是否在请求头中返回受支持的版本信息。
                o.ReportApiVersions = true;
                //请求中未指定版本时默认的版本号。
                o.DefaultApiVersion = new ApiVersion(1, 0);
                //版本号以什么形式，什么字段传递？版本信息放到header ,不写在不配置路由的情况下，版本信息放到response url 中
                o.ApiVersionReader = new HeaderApiVersionReader("api-version");
                //请求没有指明版本的情况下是否使用默认的版本。
                o.AssumeDefaultVersionWhenUnspecified = true;
            }).AddVersionedApiExplorer(option =>
            {    // 版本名的格式：v+版本号
                option.GroupNameFormat = "'v'V";
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

            //获取webapi版本信息，用于swagger多版本支持 
            services.AddOptions<SwaggerGenOptions>().Configure<IApiVersionDescriptionProvider>((options, service) =>
            {
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                apiVersionProvider = service;
            });
            services.AddSwaggerGen(options =>
            {
                string contactName = Configuration.GetSection("SwaggerDoc:ContactName").Value;
                string contactNameEmail = Configuration.GetSection("SwaggerDoc:ContactEmail").Value;
                string contactUrl = Configuration.GetSection("SwaggerDoc:ContactUrl").Value;
                foreach (var description in apiVersionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName,
                        new OpenApiInfo()
                        {
                            Title = $"{Configuration.GetSection("SwaggerDoc:Title").Value}v{description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                            Description = Configuration.GetSection("SwaggerDoc:Description").Value+ (description.IsDeprecated ? " - 此版本已放弃兼容":""),//描述
                            Contact = new OpenApiContact { Name = contactName, Email = contactNameEmail, Url = new Uri(contactUrl) },
                            License = new OpenApiLicense { Name = contactName, Url = new Uri(contactUrl) }
                        });
                }

                //加载XML注释
                Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml").ToList().ForEach(file =>
                {
                    options.IncludeXmlComments(file, true);
                });
                options.DocumentFilter<HiddenApiFilter>(); // 在接口类、方法标记属性 [HiddenApi]，可以阻止【Swagger文档】生成
                //给api添加token令牌证书
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat="JWT",
                    Scheme= "Bearer"
                });
                //添加安全请求
                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement {
                        { 
                            new OpenApiSecurityScheme
                            {
                                Reference=new OpenApiReference{
                                    Type=ReferenceType.SecurityScheme,
                                    Id= "Bearer"
                                }
                            }
                            ,new string[] { }
                        }
                    }
                 );
                options.OperationFilter<AddRequiredHeaderParameter>();
                //开启加权锁
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });


            #endregion

            #region 全局设置跨域访问
            //允许所有跨域访问，测试用
            services.AddCors(options => options.AddPolicy("yuebonCors",
                policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
            // 跨域设置 建议正式环境
            //services.AddCors(options => options.AddPolicy("yuebonCors",
            //    policy => policy.WithOrigins(Configuration.GetSection("AppSetting:AllowOrigins").Value.Split(',', StringSplitOptions.RemoveEmptyEntries)).AllowAnyHeader().AllowAnyMethod()));
            #endregion

            #region MiniProfiler
            services.AddMiniProfiler(options => {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;
                options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.BottomLeft;
                options.PopupShowTimeWithChildren = true;
                options.PopupShowTrivial = true;
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
            }).AddEntityFramework();
            #endregion

            #region 控制器
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                //设置时间格式
                options.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
                options.JsonSerializerOptions.Converters.Add(new DateTimeNullableConverter());
                //设置bool获取格式
                options.JsonSerializerOptions.Converters.Add(new BooleanJsonConverter());
                //设置Decimal获取格式
                options.JsonSerializerOptions.Converters.Add(new DecimalJsonConverter());
                //设置数字
                options.JsonSerializerOptions.Converters.Add(new IntJsonConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });

            mvcBuilder = services.AddMvc(option =>
            {
                //option.Filters.Add<YuebonAuthorizationFilter>();
                option.Filters.Add(new ExceptionHandlingAttribute());
                //option.Filters.Add<ActionFilter>();
            }).AddRazorRuntimeCompilation();

            services.AddMvcCore()
                .AddAuthorization().AddApiExplorer();
            #endregion
            services.AddSignalR();//使用 SignalR
            InitIoC(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="apiVersionProvider"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionProvider)
        {
            if (app != null)
            {
                app.UseStaticHttpContextAccessor();
                IServiceProvider provider = app.ApplicationServices;
                AutoMapperService.UsePack(provider);
                //加载插件应用
                LoadMoudleApps(env);

                app.UseMiniProfiler();
                if (env.IsDevelopment())
                {
                    //开发环境时才使用SwaggerUI，生产环境一般不开启
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{Configuration.GetSection("SwaggerDoc:Title").Value + description.GroupName.ToUpperInvariant()}");
                        options.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
                    }
                });
                app.Use((context, next) =>
                {
                    context.Request.EnableBuffering();
                    return next();
                });
                app.UseStaticFiles();
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                //跨域
                app.UseMiddleware<CorsMiddleware>();
                app.UseCors("yuebonCors");
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapControllerRoute("default", "api/{controller=Home}/{action=Index}/{id?}");
                });
                app.UseStatusCodePages();
            }
        }



        /// <summary>
        /// IoC初始化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private void InitIoC(IServiceCollection services)
        {

            #region 缓存
            CacheProvider cacheProvider = new CacheProvider
            {
                IsUseRedis = Configuration.GetSection("CacheProvider:UseRedis").Value.ToBool(false),
                ConnectionString = Configuration.GetSection("CacheProvider:Redis_ConnectionString").Value,
                InstanceName = Configuration.GetSection("CacheProvider:Redis_InstanceName").Value
            };

            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            jsonOptions.WriteIndented = true;
            jsonOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            jsonOptions.AllowTrailingCommas = true;
            //设置时间格式
            jsonOptions.Converters.Add(new DateTimeJsonConverter());
            jsonOptions.Converters.Add(new DateTimeNullableConverter());
            //设置bool获取格式
            jsonOptions.Converters.Add(new BooleanJsonConverter());
            //设置数字
            jsonOptions.Converters.Add(new IntJsonConverter());
            jsonOptions.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
            jsonOptions.PropertyNameCaseInsensitive = true;                     //忽略大小写
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
                }, jsonOptions, 0));
                services.Configure<DistributedCacheEntryOptions>(option => option.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5));//设置Redis缓存有效时间为5分钟。
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
                services.Configure<MemoryCacheEntryOptions>(
                    options => options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)); //设置MemoryCache缓存有效时间为5分钟
            }
            services.AddSingleton(cacheProvider);//注册缓存配置
            services.AddTransient<MemoryCacheService>();
            services.AddMemoryCache();// 启用MemoryCache

            #endregion

            #region 身份认证授权

            var jwtConfig = Configuration.GetSection("Jwt");
            var jwtOption = new JwtOption
            {
                Issuer = jwtConfig["Issuer"],
                Audience= jwtConfig["Audience"],
                Secret = jwtConfig["Secret"],
                Expiration = Convert.ToInt16(jwtConfig["Expiration"]),
                refreshJwtTime = Convert.ToInt16(jwtConfig["refreshJwtTime"])
            };
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; ;

            });
            services.AddSingleton(jwtOption);//注册配置
            #endregion

            services.AddAutoScanInjection();//自动化注入仓储和服务
            services.AddTransient<IDbContextCore, MySqlDbContext>(); //注入EF上下文
            services.AddTransient<IDbContextFactory,DbContextFactory>();

            #region automapper
            List<Assembly> myAssembly =RuntimeHelper.GetAllYuebonAssemblies().ToList();
            services.AddAutoMapper(myAssembly);
            services.AddTransient<IMapper, Mapper>();
            #endregion

            #region 定时任务
            services.AddTransient<HttpResultfulJob>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            //设置定时启动的任务
            services.AddHostedService<QuartzService>();
            #endregion
            App.Services = services;
            new DefaultInitial().CacheAppList();
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