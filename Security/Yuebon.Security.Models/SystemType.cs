namespace Yuebon.Security.Models;

/// <summary>
/// 子系统
/// </summary>
[SugarTable("Sys_SystemType", "子系统")]
[Serializable]
public class SystemType : TenantEntity, ICreationAudited, IModificationAudited, IDeleteAudited
{
    /// <summary>
    /// 默认构造函数（需要初始化属性的在此处理）
    /// </summary>
    public SystemType()
    {
    }

    #region Property Members
    /// <summary>
    /// 系统名称
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "系统名称")]
    [Required]
    public virtual string FullName { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "编码")]
    public virtual string EnCode { get; set; }

    /// <summary>
    /// 链接
    /// </summary>
    [MaxLength(254)]
    [SugarColumn(ColumnDescription= "链接")]
    public virtual string Url { get; set; }

    /// <summary>
    /// 允许编辑
    /// </summary>
    [SugarColumn(ColumnDescription= "允许编辑")]
    public virtual bool? AllowEdit { get; set; }

    /// <summary>
    /// 允许删除
    /// </summary>
    [SugarColumn(ColumnDescription= "允许删除")]
    public virtual bool? AllowDelete { get; set; }

    /// <summary>
    /// 排序码
    /// </summary>
    [SugarColumn(ColumnDescription= "排序码")]
    public virtual int? SortCode { get; set; }



    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "描述")]
    public virtual string Description { get; set; }


    /// <summary>
    /// 删除标志
    /// </summary>
    [SugarColumn(ColumnDescription= "删除标志")]
    public virtual bool? DeleteMark { get; set; }

    /// <summary>
    /// 有效标志
    /// </summary>
    [SugarColumn(ColumnDescription= "有效标志")]
    public virtual bool EnabledMark { get; set; }

    /// <summary>
    /// 创建日期
    /// </summary>
    [SugarColumn(ColumnDescription= "创建日期")]
    public virtual DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 创建用户主键
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "创建用户主键")]
    public virtual long? CreatorUserId { get; set; }

    /// <summary>
    /// 最后修改时间
    /// </summary>
    [SugarColumn(ColumnDescription= "最后修改时间")]
    public virtual DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 最后修改用户
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "最后修改用户")]
    public virtual long? LastModifyUserId { get; set; }

    /// <summary>
    /// 删除时间
    /// </summary>
    [SugarColumn(ColumnDescription= "删除时间")]
    public virtual DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除用户
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "删除用户")]
    public virtual long? DeleteUserId { get; set; }
    #endregion

}
