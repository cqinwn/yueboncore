namespace Yuebon.Security.Models;

/// <summary>
/// 系统应用表，数据实体对象
/// </summary>
[SugarTable("Sys_APP","系统应用表")]
[Serializable]
public class APP :TenantEntity, ICreationAudited, IModificationAudited, IDeleteAudited
{

    #region Property APP

    /// <summary>
    /// 获取或设置 编号
    /// </summary>
    [DisplayName("编号")]
    [SugarColumn(IsPrimaryKey = true, ColumnDescription = "编号,主键")]
    public override long Id { get; set; }
    /// <summary>
    /// 应用Id
    /// </summary>
    [MaxLength(50)]
    [SugarColumn(ColumnDescription= "应用Id")]
    [Description("应用Id")]
    public virtual string? AppId { get; set; }

    /// <summary>
    /// 应用密钥
    /// </summary>
    [MaxLength(256)]
    [Description("应用密钥")]
    [SugarColumn(ColumnDescription= "应用密钥",Length =64)]
    public virtual string? AppSecret { get; set; }

    /// <summary>
    /// 消息加解密密钥
    /// </summary>
    [MaxLength(256)]
    [Description("消息加解密密钥")]
    [SugarColumn(ColumnDescription= "消息加解密密钥",Length =256)]
    public virtual string? EncodingAESKey { get; set; }

    /// <summary>
    /// 授权请求地址url
    /// </summary>
    [MaxLength(512)]
    [Description("授权请求地址url")]
    [SugarColumn(ColumnDescription= "授权请求地址url")]
    public virtual string? RequestUrl { get; set; }

    /// <summary>
    /// Token令牌
    /// </summary>
    [Display(Name = "Token令牌")]
    [MaxLength(64)]
    [Description("Token令牌")]
    [SugarColumn(ColumnDescription= "Token令牌",Length =64)]
    public virtual string? Token { get; set; }
    /// <summary>
    /// 是否开启消息加解密
    /// </summary>
    [Display(Name = "是否开启消息加解密")]
    [Description("是否开启消息加解密")]
    [SugarColumn(ColumnDescription= "是否开启消息加解密")]
    public virtual bool IsOpenAEKey { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    [Display(Name = "描述")]
    [Description("描述")]
    [MaxLength(500)]
    [SugarColumn(ColumnDescription= "描述",Length =500)]
    public virtual string? Description { get; set; }

    /// <summary>
    /// 有效标志
    /// </summary>
    [SugarColumn(ColumnDescription= "有效标志")]
    public virtual bool? EnabledMark { get; set; }
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

    /// <summary>
    /// 最后修改时间
    /// </summary>
    [SugarColumn(ColumnDescription = "最后修改时间")]
    public virtual DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 最后修改用户
    /// </summary>
    [SugarColumn(ColumnDescription = "最后修改用户")]
    public virtual long? LastModifyUserId { get; set; }

    /// <summary>
    /// 删除标志
    /// </summary>
    [SugarColumn(ColumnDescription = "删除标志")]
    public virtual bool? DeleteMark { get; set; }
    /// <summary>
    /// 删除时间
    /// </summary>
    [SugarColumn(ColumnDescription = "删除时间")]
    public virtual DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 删除用户
    /// </summary>
    [SugarColumn(ColumnDescription = "删除用户")]
    public virtual long? DeleteUserId { get; set; }
    #endregion

}