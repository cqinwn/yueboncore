# 缓存机制

系统支持Redis和MemoryCache两种缓存方式，根据配置自动识别。

##  缓存设置

在appsettings.json添加配置
```json
"CacheProvider": {
    "UseRedis": true,
    "Redis_ConnectionString": "127.0.0.1:6379,allowAdmin=true,password=123456,defaultdatabase=0",
    "Redis_InstanceName": "yuebon_redis_"
  }
```
我们写一个类，来获取配置，CacheProvider说明：

1）、UseRedis：是否使用Redis缓存，不使用设置false即可；

2）、Redis_ConnectionString：Redis连接，按示例参数进行配置，allowadmin、password、defaultdatabase都需要，其他配置参数请查阅相关文档；

3）、Redis_InstanceName：Redis实例名称

## 添加缓存服务

在startup添加缓存服务，需要引用Microsoft.Extensions.Caching.Redis和StackExchange.Redis两个Redis包。

```csharp
//获取缓存配置
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
```

## 具体实现

* 1、缓存提供模式

``` cs
/// <summary>
/// 缓存提供模式，使用Redis或MemoryCache
/// </summary>
public class CacheProvider
{
    private bool _isUseRedis;
    
    private string _connectionString;
    private string _instanceName;
    /// <summary>
    /// 是否使用Redis
    /// </summary>
    public bool IsUseRedis { get => _isUseRedis; set => _isUseRedis = value; }
    /// <summary>
    /// Redis连接
    /// </summary>
    public string ConnectionString { get => _connectionString; set => _connectionString = value; }
    /// <summary>
    /// Redis实例名称
    /// </summary>
    public string InstanceName { get => _instanceName; set => _instanceName = value; }
}
```

* 2、缓存接口 ICacheService

不论使用Redis还是MemoryCache都需要实现该接口的方法。具体代码参考项目中的`ICacheService.cs`

* 3、Redis实现ICacheService

具体代码参考项目中的`RedisCacheService.cs`

* 4、MemoryCache实现ICacheService

具体代码参考项目中的`MemoryCacheService.cs`

* 5、缓存使用工具类`YuebonCacheHelper.cs`

## 如何使用

在使用的时候只需要YuebonCacheHelper进行使用即可，如下面例子：

1、登录是缓存用户可以用功能菜单
``` cs
YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
yuebonCacheHelper.Add("User_Function_" + user.Id, listFunction);
currentSession.Modules = listFunction;
TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
```

## 缓存时间

在缓存时设置缓存时长

```csharp
TimeSpan expiresSliding = DateTime.Now.AddMinutes(120) - DateTime.Now;
yuebonCacheHelper.Add("login_user_" + user.Id, currentSession, expiresSliding, true);
```

::: warning 注意
默认使用的是.net的内存Cache，在用IIS发布后，由于IIS本身存在自动回收的机制，会导致系统缓存20分钟就会失效。
:::


