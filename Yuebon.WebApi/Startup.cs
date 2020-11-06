using Autofac;
using AutoMapper;
using log4net;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
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
using Senparc.Weixin.Entities;
using Swashbuckle.AspNetCore.Filters;
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
using Yuebon.Commons.Attributes;
using Yuebon.Commons.Cache;
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IDbContext;
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

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddSingleton(Configuration);
            //如果部署在linux系统上，需要加上下面的配置：
            //services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            //如果部署在IIS上，需要加上下面的配置：
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);


            #region Swagger Api文档
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
                    options.IncludeXmlComments(file,true);
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


            // Api配置版本信息
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
            #endregion

            #region 全局设置跨域访问
            services.AddCors(options => options.AddPolicy("yuebonCors",
                policy => policy.WithOrigins(Configuration.GetSection("AppSetting:AllowOrigins").Value.Split(',', StringSplitOptions.RemoveEmptyEntries)).AllowAnyHeader().AllowAnyMethod()));
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
                //设置数字
                options.JsonSerializerOptions.Converters.Add(new IntJsonConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });

            mvcBuilder = services.AddMvc(option =>
            {
                option.Filters.Add<YuebonAuthorizationFilter>();
                option.Filters.Add(new ExceptionHandlingAttribute());
                option.Filters.Add<ActionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Latest).AddRazorRuntimeCompilation();

            services.AddMvcCore()
                .AddAuthorization().AddApiExplorer();
            #endregion
            services.AddMiniProfiler().AddEntityFramework();
            services.AddSignalR();//使用 SignalR
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
                app.UseStaticHttpContextAccessor();
                IServiceProvider provider = app.ApplicationServices;
                AutoMapperService.UsePack(provider);
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
                app.UseMiniProfiler();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Yuebon System API V1");
                    options.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
                });
            }
        }



        /// <summary>
        /// IoC初始化
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private IServiceProvider InitIoC(IServiceCollection services)
        {
            #region 缓存

            services.AddMemoryCache();// 启用MemoryCache
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
            #endregion


            #region 身份认证授权

            var jwtConfig = Configuration.GetSection("Jwt");
            var jwtOption = new JwtOption
            {
                Issuer = jwtConfig["Issuer"],
                Expiration = Convert.ToInt16(jwtConfig["Expiration"]),
                Secret = jwtConfig["Secret"],
                Audience = jwtConfig["Audience"],
                refreshJwtTime = Convert.ToInt16(jwtConfig["refreshJwtTime"])
            };
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
            #endregion
            services.AddTransient<IDbContextCore, SqlServerDbContext>(); //注入EF上下文
            IoCContainer.Register(cacheProvider);//注册缓存配置
            IoCContainer.Register(Configuration);//注册配置
            IoCContainer.Register(jwtOption);//注册配置
            var codeGenerateOption = new CodeGenerateOption
            {
                ModelsNamespace = "",
                IRepositoriesNamespace = "",
                RepositoriesNamespace = "",
                IServicsNamespace = "",
                ServicesNamespace = ""
            };
            IoCContainer.Register(codeGenerateOption);//注册代码生成器相关配置信息
            IoCContainer.Register("Yuebon.Commons");
            IoCContainer.Register("Yuebon.AspNetCore");
            IoCContainer.Register("Yuebon.Security.Core");
            IoCContainer.RegisterNew("Yuebon.Security.Core", "Yuebon.Security");
            IoCContainer.Register("Yuebon.Messages.Core");
            IoCContainer.RegisterNew("Yuebon.Messages.Core", "Yuebon.Messages");
            IoCContainer.Register("Yuebon.Tenants.Core");
            IoCContainer.RegisterNew("Yuebon.Tenants.Core", "Yuebon.Tenants");
            List<Assembly> myAssembly = new List<Assembly>();
            myAssembly.Add(Assembly.Load("Yuebon.Security.Core"));
            myAssembly.Add(Assembly.Load("Yuebon.Tenants.Core"));
            services.AddAutoMapper(myAssembly);
            services.AddScoped<IMapper, Mapper>();

            #region 定时任务
            services.AddTransient<HttpResultfulJob>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            //设置定时启动的任务
            services.AddHostedService<QuartzService>();
            #endregion

            return IoCContainer.Build(services);
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region AutoFac IOC容器
            try
            {
                #region SingleInstance
                //无接口注入单例

                //有接口注入单例
                #endregion

                #region Aop
                var interceptorServiceTypes = new List<Type>();
                builder.RegisterType<UnitOfWorkIInterceptor>();
                interceptorServiceTypes.Add(typeof(UnitOfWorkIInterceptor));
                #endregion

                #region Repository
                #endregion

                #region Service
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
            #endregion
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
