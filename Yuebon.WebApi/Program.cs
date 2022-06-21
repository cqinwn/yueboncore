using Quartz;
using Yuebon.Extensions.Middlewares;
using Yuebon.Quartz.Jobs;
using static Yuebon.Extensions.ServiceExtensions.SwaggerVersions;
var builder = WebApplication.CreateBuilder(args);

#region 1、配置host与容器
builder.Host
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModuleRegister());
})
.ConfigureLogging((hostingContext, builder) =>
{
    builder.AddFilter("System", LogLevel.Error);
    builder.AddFilter("Microsoft", LogLevel.Error);
    builder.SetMinimumLevel(LogLevel.Error);
    builder.AddLog4Net(Path.Combine(Directory.GetCurrentDirectory(), "log4net.config"));
})
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.Sources.Clear();
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
});

ILoggerRepository loggerRepository = LogManager.CreateRepository("NETCoreRepository");
Log4NetHelper.SetConfig(loggerRepository, "log4net.config");
#endregion

#region 2、配置服务

builder.Services.AddSingleton(new Appsettings(builder.Configuration));
builder.Services.AddUiFilesZipSetup(builder.Environment);
builder.Services.AddRedisCacheSetup();
builder.Services.AddMiniProfilerSetup();
builder.Services.AddSqlSugarSetup();
builder.Services.AddHttpContextSetup();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerSetup();

builder.Services.AddRabbitMQSetup();

builder.Services.AddAuthorizationSetup();
builder.Services.Configure<KestrelServerOptions>(x => x.AllowSynchronousIO = true).Configure<IISServerOptions>(x => x.AllowSynchronousIO = true);

#region 全局设置跨域访问
//允许所有跨域访问，测试用
builder.Services.AddCors(options => options.AddPolicy("yuebonCors",policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
// 跨域设置 建议正式环境
//services.AddCors(options => options.AddPolicy("yuebonCors",
//    policy => policy.WithOrigins(Configuration.GetSection("AppSetting:AllowOrigins").Value.Split(',', StringSplitOptions.RemoveEmptyEntries)).AllowAnyHeader().AllowAnyMethod()));
#endregion

#region 健康检查
builder.Services.AddHealthChecks();
#endregion

#region 控制器
builder.Services.AddControllers(c =>
{
    c.Filters.Add(typeof(GlobalExceptionsFilter));
    c.Filters.Add(typeof(RequestActionFilter));
    c.Conventions.Add(new GlobalRoutePrefixFilter(new RouteAttribute("")));
}).AddJsonOptions(options =>
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
    options.JsonSerializerOptions.Converters.Add(new LongJsonConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = new UpperFirstCaseNamingPolicy();
    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
});


builder.Services.AddMvcCore().AddApiExplorer();
builder.Services.AddEndpointsApiExplorer();

#endregion


#region automapper
List<Assembly> myAssembly = RuntimeHelper.GetAllYuebonAssemblies().ToList();
builder.Services.AddAutoMapper(myAssembly);
builder.Services.AddTransient<IMapper, Mapper>();
#endregion

builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

#region 事件总线
builder.Services.AddEventBusSetup();
#endregion

builder.Services.AddJobSetup();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
Appsettings.Services = builder.Services;
//雪花算法配置
YitIdHelper.SetIdGenerator(new IdGeneratorOptions()
{
    WorkerId = 1,
    WorkerIdBitLength = 10,
    SeqBitLength = 6,
    DataCenterIdBitLength = 1,
    TopOverCostCount = 2000,
    //TimestampType = 1,
    // MinSeqNumber = 1,
    // MaxSeqNumber = 200,
    // BaseTime = DateTime.Now.AddYears(-10),
});


#endregion


#region 3、配置中间件
var app = builder.Build();

AutoMapperService.UsePack(app.Services);
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    //app.UseHsts();
}
//开启性能分析
app.UseMiniProfiler();
app.UseApiVersioning();
#region 启用swaggerUI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DocumentTitle = Appsettings.Configuration.GetSection("SwaggerDoc:Title").Value;
    typeof(ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
    {
        options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{Appsettings.Configuration.GetSection("SwaggerDoc:Title").Value + version.ToUpperInvariant()}");
        options.RoutePrefix = string.Empty;//这里主要是不需要再输入swagger这个默认前缀
    });
    options.HeadContent = "<script async id=\"mini-profiler\" src=\"/mini-profiler-resources/includes.min.js?v=4.2.22+b27bea37e9\" data-version=\"4.2.22+b27bea37e9\" data-path=\"/mini-profiler-resources/\" data-current-id=\"144b1192-acd3-4fe2-bbc5-6f1e1c6d53df\" data-ids=\"87a1341b-995d-4d1d-aaba-8f2bfcfc9ca9,144b1192-acd3-4fe2-bbc5-6f1e1c6d53df\" data-position=\"Left\" data-scheme=\"Light\" data-authorized=\"true\" data-max-traces=\"15\" data-toggle-shortcut=\"Alt+P\" data-trivial-milliseconds=\"2.0\" data-ignored-duplicate-execute-types=\"Open,OpenAsync,Close,CloseAsync\"></script>";
});
#endregion
app.UseHealthChecks("/Health");
app.UseStaticHttpContextAccessor();

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

#region 解决 Nginx 代理不能获取IP问题
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
#endregion
app.UseStatusCodePages();

app.MapControllers();
#endregion

#region 初始化
if (Appsettings.GetValue("AppSetting:SeedDBEnabled").ObjToBool() || Appsettings.GetValue("AppSetting:SeedDBDataEnabled").ObjToBool())
{
   await DBSeedService.SeedAsync(new List<string> { "Yuebon.Security.Models.dll", "Yuebon.Security.SeedData.dll", "Yuebon.CMS.Models.dll", "Yuebon.CodeGenerator.Core.dll" });
}

app.ConfigureEventBus();

var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
var tasksQzServices = scope.ServiceProvider.GetRequiredService<ITaskManagerService>();
var schedulerCenter = scope.ServiceProvider.GetRequiredService<ISchedulerCenter>();
app.UseQuartzJobMiddleware(tasksQzServices, schedulerCenter);
#endregion

// 4、运行
app.Run();
