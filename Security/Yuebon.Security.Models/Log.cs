using Yuebon.Commons.Core.DataManager;


namespace Yuebon.Security.Models;

/// <summary>
/// 系统日志，数据实体对象
/// </summary>
[AppDBContext("DefaultDb")]
[SugarTable("Sys_Log", "系统异常日志")]
[Serializable]
public class Log: LongEntity, ICreationAudited, IDeleteAudited
{ 
    /// <summary>
    /// 默认构造函数（需要初始化属性的在此处理）
    /// </summary>
	    public Log()
		{
        this.Id = IdGeneratorHelper.IdSnowflake();
        this.DeleteMark = false;
        this.CreatorTime = DateTime.Now;
		}


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
    /// 异常类型
    /// </summary>
    [SugarColumn(ColumnDescription = "异常类型", Length = 200)]
    public virtual string? ExceptionType { get; set; }
    /// <summary>
    /// 描述
    /// </summary>
    [SugarColumn(ColumnDescription = "描述", ColumnDataType = "varchar(max)")]
    public virtual string? Description { get; set; }


    /// <summary>
    /// 删除标志
    /// </summary>
    [SugarColumn(ColumnDescription = "删除标志")]
    public virtual bool? DeleteMark { get; set; }


    /// <summary>
    /// 创建日期
    /// </summary>
    [SugarColumn(ColumnDescription = "创建日期")]
    public virtual DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 创建用户主键
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "创建用户主键")]
    public virtual long? CreatorUserId { get; set; }


    /// <summary>
    /// 删除时间
    /// </summary>
    [SugarColumn(ColumnDescription = "删除时间")]
    public virtual DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除用户
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "删除用户")]
    public virtual long? DeleteUserId { get; set; }
    #endregion
}