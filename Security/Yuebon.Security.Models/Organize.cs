namespace Yuebon.Security.Models;

/// <summary>
/// 组织表，数据实体对象
/// </summary>
[SugarTable("Sys_Organize", "组织机构表")]
[Serializable]
public class Organize: TenantEntity, ICreationAudited, IModificationAudited, IDeleteAudited
{ 

    #region Property Members


    /// <summary>
    /// 父级
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "父级")]
    public virtual long ParentId { get; set; }

    /// <summary>
    /// 层次
    /// </summary>
    [SugarColumn(ColumnDescription= "层次")]
    [Required]
    public virtual int Layers { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "编码")]
    public virtual string? EnCode { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "名称")]
    public virtual string? FullName { get; set; }

    /// <summary>
    /// 简称
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "简称")]
    public virtual string? ShortName { get; set; }

    /// <summary>
    /// 组织类型
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription = "组织类型")]
    public virtual string? OrgType { get; set; }
    /// <summary>
    /// 分类
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "分类")]
    public virtual string? CategoryId { get; set; }

    /// <summary>
    /// 负责人
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "负责人")]
    public virtual string? ManagerId { get; set; }

    /// <summary>
    /// 电话
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription= "电话")]
    public virtual string? TelePhone { get; set; }

    /// <summary>
    /// 手机
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription= "手机")]
    public virtual string? MobilePhone { get; set; }

    /// <summary>
    /// 微信
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription= "微信")]
    public virtual string? WeChat { get; set; }

    /// <summary>
    /// 传真
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription= "传真")]
    public virtual string? Fax { get; set; }

    /// <summary>
    /// 邮箱
    /// </summary>
    [MaxLength(100)]
    [SugarColumn(ColumnDescription= "邮箱")]
    public virtual string? Email { get; set; }

    /// <summary>
    /// 归属区域
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "归属区域")]
    public virtual string? AreaId { get; set; }

    /// <summary>
    /// 联系地址
    /// </summary>
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "联系地址")]
    public virtual string? Address { get; set; }

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
    public virtual string? Description { get; set; }


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


    /// <summary>
    /// 子级
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<Organize> Child { get; set; }
    #endregion

}