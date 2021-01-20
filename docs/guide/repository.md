# 业务数据层

## 概述

一个模块的数据层，主要包括如下几个方面：

* 数据实体：数据实体是服务层向数据库进行数据持久化的数据载体，也是数据层进行业务处理的数据载体，数据层与数据层的数据交换都应通过实体类来完成。
* 输入DTO：InputDto用于前端向API层输入数据，API层向服务层输入数据
* 输出DTO：OutputDto主要用于数据查询服务，是API层向前端输出数据的载体
* 数据实体映射配置：DBFirst的开发模式，数据库的设计优先完成，数据实体映射配置正是负责这项工作的，针对一个实体，可以在这里配置其在数据库中的数据表关系、数据约束及各个数据字段的每一个细节配置。

* 对象Mapper映射：数据传输对象DTO 与 实体类Entity 之间的转换与更新，如果都要通过手写代码来进行属性的一一对应赋值，是件很累人的事，通过 对象Mapper映射（例如AutoMapper）功能，只需进行一次配置，即可很方便的实现不同类型对象的数据转换与更新。

## 实体

### 实体基类Entity

所有数据库实体必须继承Entity实体基类

BaseEntity实体是预定义实体，系统默认的主键是以Id命名，业务实体中将继承BaseEntity基类即可.

### 可选接口与特性
创建审计信息ICreationAudited接口、更新审计的信息IModificationAudited接口、逻辑删除功能审计信息IDeleteAudited接口

更多关于实体的描述参见[数据库实体](/guide/entity.html)

综合代码如何：
```cs
/// <summary>
/// 单据编码，数据实体对象
/// </summary>
[Table("Sys_Sequence")]
[Serializable]
public class Sequence:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
{
    /// <summary>
    /// 设置或获取名称
    /// </summary>
    public string SequenceName { get; set; }

    /// <summary>
    /// 设置或获取分隔符
    /// </summary>
    public string SequenceDelimiter { get; set; }

    /// <summary>
    /// 设置或获取序号重置规则
    /// </summary>
    public string SequenceReset { get; set; }

    /// <summary>
    /// 设置或获取步长
    /// </summary>
    public int Step { get; set; }

    /// <summary>
    /// 设置或获取当前值
    /// </summary>
    public int CurrentNo { get; set; }

    /// <summary>
    /// 设置或获取当前编码
    /// </summary>
    public string CurrentCode { get; set; }

    /// <summary>
    /// 设置或获取当前重置依赖
    /// </summary>
    public string CurrentReset { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string Description { get; set; }

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

### 输入输出DTO
输入输出DTO：输入输出DTO主要负责各层次之间的数据传输工作，避免在外层暴露实体类。

1、输入实体：

``` cs
/// <summary>
/// 单据编码输入对象模型
/// </summary>
[AutoMap(typeof(Sequence))]
[Serializable]
public class SequenceInputDto: IInputDto<string>
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 设置或获取名称
    /// </summary>
    public string SequenceName { get; set; }

    /// <summary>
    /// 设置或获取分隔符
    /// </summary>
    public string SequenceDelimiter { get; set; }

    /// <summary>
    /// 设置或获取序号重置规则
    /// </summary>
    public string SequenceReset { get; set; }

    /// <summary>
    /// 设置或获取步长
    /// </summary>
    public int Step { get; set; }

    /// <summary>
    /// 设置或获取当前值
    /// </summary>
    public int CurrentNo { get; set; }

    /// <summary>
    /// 设置或获取当前编码
    /// </summary>
    public string CurrentCode { get; set; }

    /// <summary>
    /// 设置或获取当前重置依赖
    /// </summary>
    public string CurrentReset { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// 设置或获取是否可用
    /// </summary>
    public bool? EnabledMark { get; set; }
}
```

2、输出实体

```cs
/// <summary>
/// 单据编码输出对象模型
/// </summary>
[Serializable]
public class SequenceOutputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string Id { get; set; }

    /// <summary>
    /// 设置或获取名称
    /// </summary>
    [MaxLength(50)]
    public string SequenceName { get; set; }

    /// <summary>
    /// 设置或获取分隔符
    /// </summary>
    [MaxLength(50)]
    public string SequenceDelimiter { get; set; }

    /// <summary>
    /// 设置或获取序号重置规则
    /// </summary>
    [MaxLength(50)]
    public string SequenceReset { get; set; }

    /// <summary>
    /// 设置或获取步长
    /// </summary>
    public int Step { get; set; }

    /// <summary>
    /// 设置或获取当前值
    /// </summary>
    public int CurrentNo { get; set; }

    /// <summary>
    /// 设置或获取当前编码
    /// </summary>
    [MaxLength(200)]
    public string CurrentCode { get; set; }

    /// <summary>
    /// 设置或获取当前重置依赖
    /// </summary>
    [MaxLength(50)]
    public string CurrentReset { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(200)]
    public string Description { get; set; }

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
    [MaxLength(50)]
    public string CreatorUserId { get; set; }

    /// <summary>
    /// 设置或获取创建人组织
    /// </summary>
    [MaxLength(50)]
    public string CompanyId { get; set; }

    /// <summary>
    /// 设置或获取部门
    /// </summary>
    [MaxLength(50)]
    public string DeptId { get; set; }

    /// <summary>
    /// 设置或获取修改时间
    /// </summary>
    public DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 设置或获取修改人
    /// </summary>
    [MaxLength(50)]
    public string LastModifyUserId { get; set; }

    /// <summary>
    /// 设置或获取删除时间
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 设置或获取删除人
    /// </summary>
    [MaxLength(50)]
    public string DeleteUserId { get; set; }


}
```

## 仓储

IRepository、BaseRepository是仓储接口和实现基类，所有业务模块的仓储类都继承该基类。

1、仓储接口

必须继承IRepository基础接口

``` cs
/// <summary>
/// 定义单据编码仓储接口
/// </summary>
public interface ISequenceRepository:IRepository<Sequence, string>
{
}
```
2、仓储接口的实现

```cs
/// <summary>
/// 单据编码仓储接口的实现
/// </summary>
public class SequenceRepository : BaseRepository<Sequence, string>, ISequenceRepository
{
    public SequenceRepository()
    {
    }

    public SequenceRepository(IDbContextCore dbContext) : base(dbContext)
    {
    }
}
```


如遇到问题到[Issues](https://gitee.com/yuebon/YuebonNetCore/issues)反馈