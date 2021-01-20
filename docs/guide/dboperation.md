# 数据操作
## 简要

系统集成目前集成了Dapper和EF ORM进行数据操作。常用数据操作方法已在仓储基类BaseRepository提供。在BaseRepository我们提供EF上下文操作数据库`DbContext`、
Dapper操作`DapperContext`和`DapperConn`。究竟是选择EF还是Dapper可以参考后面性能测试情况选择，下面介绍各种数据操作。

::: warning 重要提示
BaseRepository是仓储实现基类，所有业务模块的仓储类都继承该基类。目前该类刚实现EF和Dapper的集成，有很多方法要做调整，建议开发者在各业务模块仓储实现自己的业务功能，方便平滑更新升级。
:::

## dapper操作数据

Dapper操作数据库目前提供两种方式：

1）DapperConn：使用Dapper原生方法及扩展方法；更多Dapper使用方法参考[Dapper](https://github.com/StackExchange/Dapper)

2）DapperContext：提供对Dapper方法的封装方法，所有方法在SqlDapper实现。

## EF操作数据

EF操作数据库在BaseRepository我们提供DbContext进行操作。EF的常用方法在IDbContextCore定义，并在BaseDbContext进行了通用方法的实现。
同时针对各类型数据库特性自实现了一些方法。

## 数据库连接配置

支持多类型、多个数据库访问。数据库连接配置在ConnectionStrings中，前面属性名称要包含数据库类型名称，系统会根据这个名称区分数据库类型。具体类型如下：

| 数据库类型  | 属性必含字符 | 举例        |
| ----------- | ------------ | ----------- |
| Mssqlserver | MSSQL        | MsSqlServer |
| MySql       | MySql        | MySqlCrm    |
| ORACLE      | ORACLE       | ORACLEERP   |
| SQLITE      | SQLITE       | SQLITETest  |

数据库连接名称规则：

1、总原则：业务_数据库类型_读(read)/写(write),如果不去却分读写分离可以不需要后面读写部分。

2、例子：base_MsSqlServer_read,base_MsSqlServer_write,

```json
"ConnectionStrings": {
    "MySql": "server=localhost;port=3306;database=jcrm;user=root;CharSet=utf8;password=root;",
    "MsSqlServer": "Server=192.168.1.105;Database=YuebonFW;User id=sa; password=Yuebon!23;MultipleActiveResultSets=True;",
    "MsSqlServerCode": "Server=192.168.1.105;Database=YuebonFW;User id=sa; password=Yuebon!23;MultipleActiveResultSets=True;"
  },
  "AppSetting": {
    "SoftName": "YueBonCore Framework",
    "CertificatedCompany": "Yuebon",
    "ConStringEncrypt": "false",
    "DefaultDataBase": "MsSqlServer",
  },
```
其中：

1、ConStringEncrypt配置数据库连接字符串是否加密，加密设置为true，否则设置false。数据库连接字符加密请用系统集成工具，在“开发者-数据库连接”模块操作

2、DefaultDataBase设置默认数据库连接

## 多数据库配置

在项目中常常会使用到多个不同类型数据库，我们需要在对应的实体指定该实体对应哪个数据库。采用`[AppDBContext("xxx")]`属性进行标记。xxx即为数据库配置连接字符串名称。

``` cs
/// <summary>
/// 系统日志，数据实体对象
/// </summary>
[AppDBContext("MsSqlServerCode")]
[Table("Sys_Log")]
[Serializable]
public class Log: BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
{ 
    /// <summary>
    /// 默认构造函数（需要初始化属性的在此处理）
    /// </summary>
    public Log()
    {
        this.Id = GuidUtils.CreateNo();
    }
}
```
## 内置仓储

YuebonCore框架内置了一个数据库操作的仓储，方便大家拓展和集成：

IRepository：默认非泛型仓储接口，支持切换到任何仓储；
BaseRepository：默认非泛型仓储实现。

每个业务模块仓储都将继承BaseRepository类。如下：

```cs
/// <summary>
/// 定时任务仓储接口的实现
/// </summary>
public class TaskManagerRepository : BaseRepository<TaskManager, string>, ITaskManagerRepository
{
    public TaskManagerRepository()
    {
    }
   
    /// <summary>
    /// EF 数据操作注入
    /// </summary>
    /// <param name="context"></param>
    public TaskManagerRepository(IDbContextCore context) : base(context)
    {
    }

}
```


## 多事务处理

### 单表批量操作

单表批量操作建议使用`BulkInsert`方法

### 多表批量操作

多表数据操作推荐使用`ExecuteTransaction()`或`ExecuteTransactionAsync()`方法。

## EF 与Dapper性能测试

操作EF与dapper选择时推荐如下：

1）单条数据插入推荐使用EF`Add`方法；

2）单条数据更新推荐使用EF`Update`方法；

3) 单表分页推荐使用EFGetByPagination方法，复杂方法使用sql语句；

4）单个实体获取推荐使用Dapper的`Get`方法；

5）MS Sql Server和Mysql批量插入推荐使用`BulkInsert`方法，该方法目前是现在EF中DbContext调用。

6）在非MS sql sever数据库时，推荐Dapper。

欢迎更多开发者测试纠正。

题外话：

无论使用EF还是Dapper，对批量数据处理或复杂处理建议写原生Sql。

测试方法如下：
```cs

  /// <summary>
  /// 测试性能，建议删除
  /// </summary>
  /// <param name="len"></param>
  /// <returns></returns>
  public void InsertTset(int len)
  {
      
      int n = 0;

      var sb = new StringBuilder(" EF 与Dapper常用方法性能分析 ： \n");
      Log logEntity1 = new Log()
      {
          Id = GuidUtils.GuId(),
          Date = DateTime.Now,
          Account = "admin",
          NickName = "超级管理员",
          OrganizeId = "2020101619392209546893",
          Type = "SQL",
          IPAddress = "171.110.40.191",
          IPAddressName = "中国广西壮族自治区玉林市",
          ModuleName = "Log",
          Result = true,
          Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
          DeleteMark = false,
          EnabledMark = true,
          CreatorTime = DateTime.Now,
          CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
      };
      Log logEntity2 = new Log()
      {
          Id = GuidUtils.GuId(),
          Date = DateTime.Now,
          Account = "admin",
          NickName = "超级管理员",
          OrganizeId = "2020101619392209546893",
          Type = "SQL",
          IPAddress = "171.110.40.191",
          IPAddressName = "中国广西壮族自治区玉林市",
          ModuleName = "Log",
          Result = true,
          Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
          DeleteMark = false,
          EnabledMark = true,
          CreatorTime = DateTime.Now,
          CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
      };
      Stopwatch stopwatch = new Stopwatch();
      Stopwatch stopwatch1 = new Stopwatch();
      Stopwatch stopwatch2 = new Stopwatch();
      Stopwatch stopwatch3 = new Stopwatch();
      Stopwatch stopwatch4 = new Stopwatch();
      Stopwatch stopwatch5 = new Stopwatch();
      Stopwatch stopwatch6 = new Stopwatch();
      Stopwatch stopwatch7 = new Stopwatch();
      Stopwatch stopwatch8 = new Stopwatch();
      Stopwatch stopwatch9 = new Stopwatch();
      Stopwatch stopwatch10 = new Stopwatch();
      Stopwatch stopwatch11 = new Stopwatch();
      Stopwatch stopwatch12 = new Stopwatch();
      Stopwatch stopwatch13 = new Stopwatch();
      Stopwatch stopwatch14 = new Stopwatch();

      stopwatch.Start();
      DapperContext.Add<Log>(logEntity1);
      stopwatch.Stop();
      sb.Append("Dapper 单条数据插入Insert耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
      stopwatch1.Start();
      Add(logEntity2);
      stopwatch1.Stop();
      sb.Append("EF  单条数据插入Add耗时:" + (stopwatch1.ElapsedMilliseconds + "  毫秒\n"));

      logEntity1.DeleteMark = false;
      logEntity1.LastModifyTime = DateTime.Now;

      logEntity2.DeleteMark = false;
      logEntity2.LastModifyTime = DateTime.Now;
      stopwatch2.Start();
      Update(logEntity1);
      stopwatch2.Stop();
      sb.Append("Dapper  单条数据更新Update耗时:" + (stopwatch2.ElapsedMilliseconds + "  毫秒\n"));
      stopwatch3.Start();
      Edit(logEntity2);
      stopwatch3.Stop();
      sb.Append("EF 单条数据更新Edit耗时:" + (stopwatch3.ElapsedMilliseconds + "  毫秒\n"));

      List<Log> logList = new List<Log>();

      List<Log> logList2 = new List<Log>();
      List<Log> logList3 = new List<Log>();
      List<Log> logList4 = new List<Log>();
      List<Log> logList5 = new List<Log>();
      while (n < len.ToInt())
      {
          Log logEntity = new Log()
          {
              Id = GuidUtils.GuId(),
              Date = DateTime.Now,
              Account = "admin",
              NickName = "超级管理员",
              OrganizeId = "2020101619392209546893",
              Type = "SQL",
              IPAddress = "171.110.40.191",
              IPAddressName = "中国广西壮族自治区玉林市",
              ModuleName = "Log",
              Result = true,
              Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
              DeleteMark = false,
              EnabledMark = true,
              CreatorTime = DateTime.Now,
              CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
          };
          logList.Add(logEntity);
          Log logEntity3 = new Log()
          {
              Id = GuidUtils.GuId(),
              Date = DateTime.Now,
              Account = "admin",
              NickName = "超级管理员",
              OrganizeId = "2020101619392209546893",
              Type = "SQL",
              IPAddress = "171.110.40.191",
              IPAddressName = "中国广西壮族自治区玉林市",
              ModuleName = "Log",
              Result = true,
              Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
              DeleteMark = false,
              EnabledMark = true,
              CreatorTime = DateTime.Now,
              CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
          };
          logList2.Add(logEntity3);
          Log logEntity4 = new Log()
          {
              Id = GuidUtils.GuId(),
              Date = DateTime.Now,
              Account = "admin",
              NickName = "超级管理员",
              OrganizeId = "2020101619392209546893",
              Type = "SQL",
              IPAddress = "171.110.40.191",
              IPAddressName = "中国广西壮族自治区玉林市",
              ModuleName = "Log",
              Result = true,
              Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
              DeleteMark = false,
              EnabledMark = true,
              CreatorTime = DateTime.Now,
              CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
          };
          logList3.Add(logEntity4);
          Log logEntity5 = new Log()
          {
              Id = GuidUtils.GuId(),
              Date = DateTime.Now,
              Account = "admin",
              NickName = "超级管理员",
              OrganizeId = "2020101619392209546893",
              Type = "SQL",
              IPAddress = "171.110.40.191",
              IPAddressName = "中国广西壮族自治区玉林市",
              ModuleName = "Log",
              Result = true,
              Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
              DeleteMark = false,
              EnabledMark = true,
              CreatorTime = DateTime.Now,
              CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
          };
          logList4.Add(logEntity5);
          Log logEntity6 = new Log()
          {
              Id = GuidUtils.GuId(),
              Date = DateTime.Now,
              Account = "admin",
              NickName = "超级管理员",
              OrganizeId = "2020101619392209546893",
              Type = "SQL",
              IPAddress = "171.110.40.191",
              IPAddressName = "中国广西壮族自治区玉林市",
              ModuleName = "Log",
              Result = true,
              Description = "SQL语句:update Sys_Role set EnabledMark=1 ,LastModifyUserId='2020100517554098226223',LastModifyTime=@LastModifyTime where id in ('2019091721053342871332')",
              DeleteMark = false,
              EnabledMark = true,
              CreatorTime = DateTime.Now,
              CreatorUserId = "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba"
          };
          logList5.Add(logEntity6);
          n++;
      }

      string sql = "insert into Sys_Log ([Date], [Account], [NickName], [OrganizeId], [Type], [IPAddress], [IPAddressName], [ModuleId], [ModuleName], [Result], [Description], [DeleteMark], [EnabledMark], [CreatorTime], [CreatorUserId], [LastModifyTime], [LastModifyUserId], [DeleteTime], [DeleteUserId], [Id]) values (@Date, @Account, @NickName, @OrganizeId, @Type, @IPAddress, @IPAddressName, @ModuleId, @ModuleName, @Result, @Description, @DeleteMark, @EnabledMark, @CreatorTime, @CreatorUserId, @LastModifyTime, @LastModifyUserId, @DeleteTime, @DeleteUserId, @Id)";

      stopwatch4.Start();
      DbContext.BulkInsert<Log>(logList);
      stopwatch4.Stop();
      sb.Append("使用BulkInsert批量插入"+n+"条数据耗时:" + (stopwatch4.ElapsedMilliseconds + "  毫秒\n"));

      stopwatch5.Start();
      DbContext.AddRange<Log>(logList3);
      stopwatch5.Stop();
      sb.Append("EF 批量插入" + n + "条数据AddRange耗时:" + (stopwatch5.ElapsedMilliseconds + "  毫秒\n"));
      using (IDbConnection conn = OpenSharedConnection())
      {
          stopwatch7.Start();
          conn.Execute(sql, logList5);
          stopwatch7.Stop();
          sb.Append("Dapper 批量插入" + n + "条数据ExecuteAsync耗时:" + (stopwatch7.ElapsedMilliseconds + "  毫秒\n"));
      }
      List<Log> newlogList = new List<Log>();
      foreach(Log item in logList)
      {
          Log info = new Log();
          info = item;
          info.LastModifyTime = DateTime.Now;
          info.Description += item.Description + item.Description +"更新数据";
          newlogList.Add(info);
      }
      Stopwatch stopwatch15 = new Stopwatch();
      stopwatch15.Start();
      Update(newlogList);
      stopwatch15.Stop();
      sb.Append("Dapper批量更新" + n + "条数据Update耗时:" + (stopwatch15.ElapsedMilliseconds + "  毫秒\n"));
      stopwatch8.Start();
      DbContext.EditRange<Log>(newlogList);
      stopwatch8.Stop();
      sb.Append("EF 批量更新" + n + "条数据EditRange耗时:" + (stopwatch8.ElapsedMilliseconds + "  毫秒\n"));
      stopwatch9.Start();
      Get(logEntity1.Id);
      stopwatch9.Stop();
      sb.Append("Dapper 查询单个实体Get耗时:" + (stopwatch9.ElapsedMilliseconds + "  毫秒\n"));
      stopwatch10.Start();
      DbContext.GetDbSet<Log>().Find(logEntity1.Id);
      stopwatch10.Stop();
      sb.Append("Ef查询单个实体Find耗时:" + (stopwatch10.ElapsedMilliseconds + "  毫秒\n"));
      sql = $"select * from sys_Log where Id='" + logEntity1.Id + "'";
      stopwatch11.Start();
      DbContext.GetDbSet<Log>().FromSqlRaw<Log>(sql).FirstOrDefaultAsync<Log>();
      stopwatch11.Stop();
      sb.Append("Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:" + (stopwatch11.ElapsedMilliseconds + "  毫秒\n"));
      PagerInfo pagerInfo = new PagerInfo
      {
          CurrenetPageIndex = 1,
          PageSize = 50
      };
      stopwatch12.Start();
      List<Log> list = FindWithPager("", pagerInfo, "CreatorTime", true);
      PageResult<LogOutputDto> pageResult = new PageResult<LogOutputDto>
      {
          CurrentPage = pagerInfo.CurrenetPageIndex,
          Items = list.MapTo<LogOutputDto>(),
          ItemsPerPage = pagerInfo.PageSize,
          TotalItems = pagerInfo.RecordCount
      };
      stopwatch12.Stop();
      sb.Append("Dapper 分页查询耗时:" + (stopwatch12.ElapsedMilliseconds + "  毫秒\n"));
      stopwatch13.Start();

      List<Log> list2 = GetByPagination(m => true, pagerInfo, true).ToList<Log>();
      PageResult<LogOutputDto> pageResult2 = new PageResult<LogOutputDto>
      {
          CurrentPage = pagerInfo.CurrenetPageIndex,
          Items = list2.MapTo<LogOutputDto>(),
          ItemsPerPage = pagerInfo.PageSize,
          TotalItems = pagerInfo.RecordCount
      };
      stopwatch13.Stop();
      sb.Append("EF 分页查询耗时:" + (stopwatch13.ElapsedMilliseconds + "  毫秒\n")); stopwatch.Start();

      sql = $"select * from Sys_log";
      string[] orderBys = { "CreatorTime desc" };
      stopwatch14.Start();
      PageResult<Log> list3 =DbContext.SqlQueryByPagination<Log>(sql, orderBys, 1,50);
      stopwatch14.Stop();
      sb.Append("EF 分页查询耗时:" + (stopwatch14.ElapsedMilliseconds + "  毫秒\n"));
      Log4NetHelper.Info(sb.ToString());
  }
```

测试结果如下：


[11:14:13] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:126  毫秒

EF  单条数据插入Add耗时:33  毫秒

Dapper  单条数据更新Update耗时:242  毫秒

EF 单条数据更新Edit耗时:184  毫秒

使用BulkInsert批量插入10条数据耗时:33  毫秒

EF 批量插入10条数据AddRange耗时:40  毫秒

Dapper 批量插入10条数据Insert批量耗时:823  毫秒

Dapper 批量插入10条数据ExecuteAsync耗时:1325  毫秒

Dapper批量更新10条数据Update耗时:2727  毫秒

EF 批量更新10条数据EditRange耗时:1  毫秒

Dapper 查询单个实体Get耗时:1004  毫秒

Ef查询单个实体Find耗时:157  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:12  毫秒

Dapper 分页查询耗时:1476  毫秒

EF 分页查询耗时:13  毫秒

EF 分页查询耗时:1320  毫秒

[11:15:08] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:61  毫秒

EF  单条数据插入Add耗时:29  毫秒

Dapper  单条数据更新Update耗时:197  毫秒

EF 单条数据更新Edit耗时:211  毫秒

使用BulkInsert批量插入10条数据耗时:35  毫秒

EF 批量插入10条数据AddRange耗时:43  毫秒

Dapper 批量插入10条数据Insert批量耗时:577  毫秒

Dapper 批量插入10条数据ExecuteAsync耗时:755  毫秒

Dapper批量更新10条数据Update耗时:2389  毫秒

EF 批量更新10条数据EditRange耗时:0  毫秒

Dapper 查询单个实体Get耗时:185  毫秒

Ef查询单个实体Find耗时:182  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:9  毫秒

Dapper 分页查询耗时:1439  毫秒

EF 分页查询耗时:14  毫秒

EF 分页查询耗时:1311  毫秒

[11:16:45] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:64  毫秒

EF  单条数据插入Add耗时:30  毫秒

Dapper  单条数据更新Update耗时:245  毫秒

EF 单条数据更新Edit耗时:201  毫秒

使用BulkInsert批量插入10条数据耗时:33  毫秒

EF 批量插入10条数据AddRange耗时:35  毫秒

Dapper 批量插入10条数据Insert批量耗时:982  毫秒

Dapper 批量插入10条数据ExecuteAsync耗时:636  毫秒

Dapper批量更新10条数据Update耗时:2091  毫秒

EF 批量更新10条数据EditRange耗时:0  毫秒

Dapper 查询单个实体Get耗时:167  毫秒

Ef查询单个实体Find耗时:186  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:11  毫秒

Dapper 分页查询耗时:3453  毫秒

EF 分页查询耗时:13  毫秒

EF 分页查询耗时:1576  毫秒


[11:18:16] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:275  毫秒

EF  单条数据插入Add耗时:1373  毫秒

Dapper  单条数据更新Update耗时:258  毫秒

EF 单条数据更新Edit耗时:497  毫秒

使用BulkInsert批量插入50条数据耗时:119  毫秒

EF 批量插入50条数据AddRange耗时:243  毫秒

Dapper 批量插入50条数据Insert批量耗时:4699  毫秒

Dapper 批量插入50条数据ExecuteAsync耗时:3690  毫秒

Dapper批量更新50条数据Update耗时:10699  毫秒

EF 批量更新50条数据EditRange耗时:2  毫秒

Dapper 查询单个实体Get耗时:177  毫秒

Ef查询单个实体Find耗时:146  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:5  毫秒

Dapper 分页查询耗时:1621  毫秒

EF 分页查询耗时:22  毫秒

EF 分页查询耗时:1386  毫秒

[11:19:54] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:55  毫秒

EF  单条数据插入Add耗时:35  毫秒

Dapper  单条数据更新Update耗时:254  毫秒

EF 单条数据更新Edit耗时:168  毫秒

使用BulkInsert批量插入50条数据耗时:33  毫秒

EF 批量插入50条数据AddRange耗时:120  毫秒

Dapper 批量插入50条数据Insert批量耗时:3805  毫秒

Dapper 批量插入50条数据ExecuteAsync耗时:3220  毫秒

Dapper批量更新50条数据Update耗时:11072  毫秒

EF 批量更新50条数据EditRange耗时:2  毫秒

Dapper 查询单个实体Get耗时:211  毫秒

Ef查询单个实体Find耗时:282  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:6  毫秒

Dapper 分页查询耗时:1450  毫秒

EF 分页查询耗时:13  毫秒

EF 分页查询耗时:1316  毫秒

[11:21:19] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:184  毫秒

EF  单条数据插入Add耗时:37  毫秒

Dapper  单条数据更新Update耗时:258  毫秒

EF 单条数据更新Edit耗时:253  毫秒

使用BulkInsert批量插入50条数据耗时:34  毫秒

EF 批量插入50条数据AddRange耗时:157  毫秒

Dapper 批量插入50条数据Insert批量耗时:7365  毫秒

Dapper 批量插入50条数据ExecuteAsync耗时:4021  毫秒

Dapper批量更新50条数据Update耗时:11607  毫秒

EF 批量更新50条数据EditRange耗时:49  毫秒

Dapper 查询单个实体Get耗时:155  毫秒

Ef查询单个实体Find耗时:185  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:244  毫秒

Dapper 分页查询耗时:1383  毫秒

EF 分页查询耗时:58  毫秒

EF 分页查询耗时:1759  毫秒

[11:21:40] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:128  毫秒

EF  单条数据插入Add耗时:72  毫秒

Dapper  单条数据更新Update耗时:215  毫秒

EF 单条数据更新Edit耗时:254  毫秒

使用BulkInsert批量插入50条数据耗时:402  毫秒

EF 批量插入50条数据AddRange耗时:333  毫秒

Dapper 批量插入50条数据Insert批量耗时:17727  毫秒

Dapper 批量插入50条数据ExecuteAsync耗时:4437  毫秒

Dapper批量更新50条数据Update耗时:10654  毫秒

EF 批量更新50条数据EditRange耗时:5  毫秒

Dapper 查询单个实体Get耗时:156  毫秒

Ef查询单个实体Find耗时:170  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:9  毫秒

Dapper 分页查询耗时:1464  毫秒

EF 分页查询耗时:16  毫秒

EF 分页查询耗时:1451  毫秒

[12:14:42] (Info) 方法名称：InsertTset

日志内容： EF 与Dapper常用方法性能分析 ： 

Dapper 单条数据插入Insert耗时:141  毫秒

EF  单条数据插入Add耗时:30  毫秒

Dapper  单条数据更新Update耗时:236  毫秒

EF 单条数据更新Edit耗时:184  毫秒

使用BulkInsert批量插入10条数据耗时:36  毫秒

EF 批量插入10条数据AddRange耗时:37  毫秒

Dapper 批量插入10条数据Insert批量耗时:578  毫秒

Dapper 批量插入10条数据ExecuteAsync耗时:605  毫秒

Dapper批量更新10条数据Update耗时:2157  毫秒

EF 批量更新10条数据EditRange耗时:0  毫秒

Dapper 查询单个实体Get耗时:162  毫秒

Ef查询单个实体Find耗时:164  毫秒

Ef查询单个实体FromSqlRaw FirstOrDefaultAsync耗时:5  毫秒

Dapper 分页查询耗时:1438  毫秒

EF 分页查询耗时:18  毫秒

EF 分页查询耗时:1295  毫秒

## 读写分离

目前还未实现，已列入开发计划。

### 反馈与建议
与我们交流
给 `YuebonCore` 提 [Issue](https://gitee.com/yuebon/YuebonNetCore/issues)。
