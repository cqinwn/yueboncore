namespace Yuebon.Security.Models;

/// <summary>
/// 数据字典选项主表，数据实体对象
/// </summary>
[SugarTable("Sys_Items","数据字典选项主表")]
[Serializable]
public class Items : BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
{ 
    /// <summary>
    /// 默认构造函数（需要初始化属性的在此处理）
    /// </summary>
	    public Items()
		{
       
		}

    #region Property Members


    /// <summary>
    /// 父级
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "父级ID")]
    [Required]
    public virtual long ParentId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "编码")]
    [Required]
    public virtual string EnCode { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "名称")]
    [Required]
    public virtual string FullName { get; set; }

    /// <summary>
    /// 是否是树型
    /// </summary>
    [SugarColumn(ColumnDescription= "是否是树型")]
    public virtual bool IsTree { get; set; }

    /// <summary>
    /// 层次
    /// </summary>
    [SugarColumn(ColumnDescription= "层次")]
    public virtual int? Layers { get; set; }

    /// <summary>
    /// 排序码
    /// </summary>
    [SugarColumn(ColumnDescription= "排序码")]
    public virtual int? SortCode { get; set; }


    /// <summary>
    /// 描述
    /// </summary>
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "创建用户主键")]
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



    /// <summary>
    /// 子级
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public virtual List<Items> Children { get; set; }
    #endregion

}