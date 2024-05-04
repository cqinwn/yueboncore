namespace Yuebon.Security.Models;

[SugarTable("Sys_Login_Log", "登录日志")]
[Serializable]
public class LoginLog : TenantEntity,ICreationAudited, IOrgIdFilter
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
    public virtual string? NickName { get; set; }

    /// <summary>
    /// 组织主键
    /// </summary>
    [SugarColumn(ColumnDescription = "组织主键")]
    public virtual long? OrganizeId { get; set; }

    /// <summary>
    /// IP地址
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "IP地址")]
    public virtual string? IPAddress { get; set; }

    /// <summary>
    /// IP所在城市
    /// </summary
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "IP所在城市")]
    public virtual string? IPAddressName { get; set; }

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
    public virtual long? CreateOrgId { get; set; }
    
    #endregion


}
