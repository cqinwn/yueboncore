# 数据库实体

## 实体基类Entity

::: warning 重要提示
所有数据库实体必须继承Entity实体基类，BaseEntity实体是预定义实体，默认主键Id。
:::

```cs
namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// 判断主键是否为空
        /// </summary>
        /// <returns></returns>
        public abstract bool KeyIsNull();

        /// <summary>
        /// 创建默认的主键值
        /// </summary>
        public abstract void GenerateDefaultKeyVal();

        /// <summary>
        /// 构造函数
        /// </summary>
        public Entity()
        {
            if (KeyIsNull())
            {
                GenerateDefaultKeyVal();
            }
        }
    }
}
```

## 默认主键Id

系统默认的主键是以Id命名，业务实体中将继承BaseEntity基类即可，如下：

```cs
/// <summary>
/// 定义领域对象框架实体类的基类，系统默认主键为Id
/// </summary>
/// <typeparam name="TKey">实体主键类型</typeparam>

[Serializable]
public abstract class BaseEntity<TKey> :Entity
{
    /// <summary>
    /// 
    /// </summary>
    protected BaseEntity()
    {
    }

    /// <summary>
    /// 获取或设置 编号
    /// </summary>
    [DisplayName("编号")]
    [Key]
    public  TKey Id { get; set; }


    /// <summary>
    /// 判断主键是否为空
    /// </summary>
    /// <returns></returns>
    public override bool KeyIsNull()
    {
        if (Id == null)
        {
            return true;
        }
        else
        {
            return string.IsNullOrEmpty(Id.ToString());
        }
    }

    /// <summary>
    /// 创建默认的主键值
    /// </summary>
    public override void GenerateDefaultKeyVal()
    {
        Id = GuidUtils.CreateNo().CastTo<TKey>();
    }
}
```

## 添加非统一主键

如果是非Id作为主键，可以自定义类一个基类，继承Entity实体即可，如下实现int型TId为主键：

```cs
/// <summary>
/// 模拟一个实体IntEntity，主键名称为IdName，类型为Int
/// </summary>
public class IntEntity : Entity
{
    /// <summary>
    /// 获取或设置 编号
    /// </summary>
    [DisplayName("编号")]
    [Key]
    public int TId { get; set; }
    
    //其他字段略
    
    /// <summary>
    /// 判断主键是否为空
    /// </summary>
    /// <returns></returns>
    public override bool KeyIsNull()
    {
        return TId == 0;
    }

    /// <summary>
    /// 创建默认的主键值
    /// </summary>
    public override void GenerateDefaultKeyVal()
    {
        TId= RandomInt();
    }
}
```

说明：[Key]识别主键属性

## 数据审计

### ICreationAudited
定义创建审计信息：给实体添加创建时的 创建人CreatorUserId，创建时间CreatorTime 的审计信息，这些值将在数据层执行 创建Insert 时自动赋值。实体实现接口ICreationAudited

```cs
/// <summary>
/// 定义创建审计信息：给实体添加创建时的 创建人CreatorUserId，创建时间CreatorTime 的审计信息，这些值将在数据层执行 创建Insert 时自动赋值。
/// </summary>
public interface ICreationAudited
{

    /// <summary>
    /// 获取或设置 创建日期
    /// </summary>
    DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 获取或设置 创建用户主键
    /// </summary>
    string CreatorUserId { get; set; }
}
```
### IModificationAudited
定义更新审计的信息：给实体更新时的 修改人LastModifyUserId，修改时间LastModifyTime 的审计信息，这些值将在数据层执行 更新Update 时自动赋值。实体实现接口IModificationAudited

```cs
/// <summary>
/// 定义更新审计的信息
/// </summary>
public interface IModificationAudited
{
    /// <summary>
    /// 获取或设置 最后修改用户
    /// </summary>
    string LastModifyUserId { get; set; }
    /// <summary>
    /// 获取或设置 最后修改时间
    /// </summary>
    DateTime? LastModifyTime { get; set; }
}
```
### IDeleteAudited

定义逻辑删除功能审计信息：给实体做逻辑删除时的 删除人CreatorUserId，删除时间CreatorTime 的审计信息，这些值将在数据层执行 执行DeleteSoft 时自动赋值。实体实现接口IDeleteAudited

```cs
/// <summary>
///  定义逻辑删除功能审计信息
/// </summary>
public interface IDeleteAudited 
{
    /// <summary>
    /// 获取或设置 逻辑删除标记
    /// </summary>
    bool? DeleteMark { get; set; }

    /// <summary>
    /// 获取或设置 删除实体的用户
    /// </summary>
    string DeleteUserId { get; set; }

    /// <summary>
    /// 获取或设置 删除实体时间
    /// </summary>
    DateTime? DeleteTime { get; set; } 
}
```
### IExpirable
定义可过期性，包含生效时间和过期时间：给实体添加 生效时间BeginTime，过期时间EndTime 的属性
```cs
/// <summary>
/// 定义可过期性，包含生效时间和过期时间：给实体添加 生效时间BeginTime，过期时间EndTime 的属性
/// </summary>
public interface IExpirable
{
    /// <summary>
    /// 获取或设置 生效时间
    /// </summary>
    DateTime? BeginTime { get; set; }

    /// <summary>
    /// 获取或设置 过期时间
    /// </summary>
    DateTime? EndTime { get; set; }
}
```

### IMustHaveTenant
定义多租户,包含租户Id,要实现的租户的业务实体都必须实现该接口。

```cs
/// <summary>
/// 定义多租户实体信息
/// </summary>
public interface IMustHaveTenant
{
    /// <summary>
    /// 租户Id
    /// </summary>
    string TenantId {
        get;
        set;
    }
}
```


## 实体与数据库

每个数据实体对应一个数据库，通过`[AppDBContext("xxx")]`属性进行注释标识，即可实现EF和dapper自动识别数据库连接,不指定时按设置的默认数据库访问。

## 实体与数据库表

每个实体名称可以与数据库表名称不一致，通过`Table`标签属性进行注释标识，即可实现EF和dapper自动识别表名称，必须指定。

## 例子

如：定时任务数据库实体

```cs
    /// <summary>
    /// 定时任务，数据实体对象
    /// </summary>
    [AppDBContext("MsSqlServerCode")]
    [Table("Sys_TaskManager")]
    [Serializable]
    public class TaskManager:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TaskManager()
        {
            this.RunCount = 0;
            this.ErrorCount = 0;
            this.NextRunTime = DateTime.Now;
            this.LastRunTime = DateTime.Now;
            this.JobCallParams = string.Empty;
            this.Cron = string.Empty;
            this.Status = 0;
            this.CompanyId = "";
            this.DeptId = "";
            this.DeleteUserId = "";
        }
        /// <summary>
        /// 设置或获取任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 设置或获取任务分组
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 设置或获取结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 设置或获取开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 设置或获取CRON表达式
        /// </summary>
        public string Cron { get; set; }

        /// <summary>
        /// 设置或获取是否是本地任务1：本地任务；0：外部接口任务
        /// </summary>
        public bool IsLocal { get; set; }

        /// <summary>
        /// 设置或获取远程调用接口url
        /// </summary>
        public string JobCallAddress { get; set; }

        /// <summary>
        /// 设置或获取任务参数，JSON格式
        /// </summary>
        public string JobCallParams { get; set; }

        /// <summary>
        /// 设置或获取最后一次执行时间
        /// </summary>
        public DateTime? LastRunTime { get; set; }

        /// <summary>
        /// 设置或获取最后一次失败时间
        /// </summary>
        public DateTime? LastErrorTime { get; set; }

        /// <summary>
        /// 设置或获取下次执行时间
        /// </summary>
        public DateTime? NextRunTime { get; set; }

        /// <summary>
        /// 设置或获取执行次数
        /// </summary>
        public int RunCount { get; set; }

        /// <summary>
        /// 设置或获取异常次数
        /// </summary>
        public int ErrorCount { get; set; }

        /// <summary>
        /// 设置或获取描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取状态，0-暂停，1-启用
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 设置或获取是否邮件通知
        /// </summary>
        public int SendMail { get; set; }
        /// <summary>
        /// 设置或获取接受邮件地址
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人
        /// </summary>
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取修改人
        /// </summary>
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        public string DeleteUserId { get; set; }
    }
```


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈