# 常见问题

## node-sass安装失败

Windows 用户若安装不成功，很大概率是node-sass安装失败。解决node-sass安装不成功的问题

```sh
npm i node-sass --sass_binary_site=https://npm.taobao.org/mirrors/node-sass
```
## Module build failed 错误
启动后出现如错误：Module build failed (from ./node_modules/babel-loader/lib/index.js):

解决方法：进入当前项目目录 npm install @babel/core @babel/preset-env 命令

## 获取当前用户

1、在业务服务Service模块中需要获取当前登陆用户信息的获取方法如下:

``` cs
var identities =HttpContextHelper.HttpContext.User.Identities;
var claimsIdentity = identities.First<ClaimsIdentity>();
List<Claim> claimlist = claimsIdentity.Claims as List<Claim>;
```
claimlist[0].Vaule是用户Id UserId；

claimlist[1].Vaule是用户账号Account；

claimlist[2].Vaule是用户角色Role；

claimlist[3].Vaule是用户所属租户TenantId；

以上内容在`YuebonAuthorizationFilter`过滤器中进行封装赋值。

2、在Controler控制器中获取当前用户

我们在ApiController基础控制器中定义了当前登录的用户属性CurrentUser，如下：
``` cs
/// <summary>
/// 当前登录的用户属性
/// </summary>
public YuebonCurrentUser CurrentUser;

```
同时在OnActionExecuting方法中进行赋值。如下：

``` cs
......
var identities = filterContext.HttpContext.User.Identities;
var claimsIdentity = identities.First<ClaimsIdentity>();
if (claimsIdentity != null)
{
    List<Claim> claimlist= claimsIdentity.Claims as List<Claim>;
    if (claimlist.Count > 0)
    {
        string userId = claimlist[0].Value;
        YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
        var user = JsonSerializer.Deserialize<YuebonCurrentUser>(yuebonCacheHelper.Get("login_user_" + userId).ToJson());
        if (user != null)
        {
            CurrentUser = user;
        }
    }
}
......
```
你在需要时直接通过CurrentUser即可获取当前登陆用户信息。具体有哪些信息请参考代码。

## sql server 2008数据库问题
系统默认支持sql server 2012版，我们也推荐使用sql server 2012。主要是我们分页使用With Paging。如果您使用了sql server 2008版本数据，请设置`PagerHelper.cs`中的`GetSqlServerSql`方法中的`isSql2008`修改为`true`即可。
``` cs
/// <summary>
/// 不依赖于存储过程的分页(SqlServer)
/// </summary>
/// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
/// <param name="isSql2008">是否是Sql server2008及低版本，默认为false</param>
/// <returns></returns>
private string GetSqlServerSql(bool isDoCount,bool isSql2008=false)
{
    string sql = "";
    if (string.IsNullOrEmpty(this.strwhere))
    {
        this.strwhere = " (1=1) ";
    }

    if (isDoCount)//执行总数统计
    {
        sql = string.Format("select count(*) as Total from {0} Where {1} ", this.TableOrSqlWrapper, this.strwhere);
    }
    else
    {
        string strOrder = string.Format(" order by {0} {1}", this.fieldNameToSort, this.isDescending ? "DESC" : "ASC");
        int minRow = pageSize * (pageIndex - 1) + 1;
        int maxRow = pageSize * pageIndex;
        if (isSql2008)
        {
            sql = string.Format("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by {0}) AS rows ,{1} FROM {2} where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, fieldsToReturn, TableOrSqlWrapper, strwhere, minRow, maxRow);
        }
        else
        {
            sql = string.Format(@"With Paging AS
        ( SELECT ROW_NUMBER() OVER ({0}) as RowNumber, {1} FROM {2} Where {3})
        SELECT * FROM Paging WHERE RowNumber Between {4} and {5}", strOrder, this.fieldsToReturn, this.TableOrSqlWrapper, this.strwhere,
            minRow, maxRow);
        }
    }

    return sql;
}

```

## syscall spawn git

前端在安装依赖时提示：npm报错syscall spawn git
报错：
```
3656 error code ENOENT
3657 error syscall spawn git
3658 error path git
3659 error errno ENOENT
3660 error enoent Error while executing:
3660 error enoent undefined ls-remote -h -t ssh://git@github.com/sohee-lee7/Squire.git
3660 error enoent
3660 error enoent
3660 error enoent spawn git ENOENT
3661 error enoent This is related to npm not being able to find a file.
```
原因：

1、部分安装依赖须从git上下载下来的，其中会隐藏一些git的东西，导致安装出现问题。

2、没有配置git环境变量

解决办法：

1、安装git，可以到群`90311523`获取下载或者git国内下载地址：https://github.com/waylau/git-for-win

2、配置git环境变量，将`C:\Program Files\Git\cmd;C:\Program Files\Git\bin;`（具体根据git安装目录）添加到系统变量path中。


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈