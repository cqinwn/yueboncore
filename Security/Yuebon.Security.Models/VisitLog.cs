namespace Yuebon.Security.Models;

[SugarTable("Sys_Visit_Log", "访问/操作日志")]
[Serializable]
public class VisitLog : TenantEntity, ICreationAudited
{

    #region Property Members
    /// <summary>
    /// 日期
    /// </summary>
    [SugarColumn(ColumnDescription = "日期")]
    public virtual DateTime? Date { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "用户名")]
    public virtual string? Account { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "姓名")]
    public virtual string? RealName { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "IP地址", IsNullable = true)]
    public virtual string? IPAddress { get; set; }

    /// <summary>
    /// 系统模块
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription = "系统模块", Length = 100, IsNullable = true)]
    public virtual string? ModuleName { get; set; }
    /// <summary>
    /// 请求名称
    /// </summary
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "请求名称", IsNullable = true)]
    public virtual string? MethodName { get; set; }
    /// <summary>
    /// 请求方式
    /// </summary
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "请求方式", IsNullable = true)]
    public virtual string? RequestMethod { get; set; }
    /// <summary>
    /// 请求参数
    /// </summary
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "请求参数", IsNullable = true, ColumnDataType = "varchar(max)")]
    public virtual string? RequestParameter { get; set; }


    /// <summary>
    /// 请求
    /// </summary>
    [MaxLength(600)]
    [SugarColumn(ColumnDescription = "请求", Length = 600)]
    public virtual string? RequestUrl { get; set; }

    /// <summary>
    /// 浏览器
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription = "浏览器", Length = 100)]
    public virtual string? Browser { get; set; }

    /// <summary>
    /// 操作系统
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription = "操作系统", Length = 100)]
    public virtual string? OS { get; set; }
    /// <summary>
    /// 结果
    /// </summary>
    [SugarColumn(ColumnDescription = "结果")]
    public virtual bool? Result { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", ColumnDataType = "varchar(max)")]
    public virtual string? Description { get; set; }


    /// <summary>
    /// 耗时
    /// </summary>
    [SugarColumn(ColumnDescription = "耗时")]
    public virtual long? ElapsedTime { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    [SugarColumn(ColumnDescription = "创建日期")]
    public virtual DateTime? CreatorTime { get; set; }
    /// <summary>
    /// 创建用户主键
    /// </summary>
    [SugarColumn(ColumnDescription = "创建用户主键")]
    public virtual long? CreatorUserId { get; set; }

    /// <summary>
    /// 设置或获取 创建者部门Id
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者部门Id", IsOnlyIgnoreUpdate = true)]
    public long? CreateOrgId { get; set; }
    #endregion
}
