using SqlSugar;

namespace Yuebon.Core.Models;
/// <summary>
/// 数据权限过滤实体，包含多租户
/// </summary>
public abstract class EntityBaseData:TenantEntity, ICreationAudited, IModificationAudited, IDeleteAudited, IOrgIdFilter
{
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
    [SugarColumn(ColumnDescription = "创建者部门Id",IsOnlyIgnoreUpdate =true)]
    public virtual long? CreateOrgId { get; set; }
    /// <summary>
    /// 最后修改时间
    /// </summary>
    [SugarColumn(ColumnDescription = "最后修改时间",IsOnlyIgnoreInsert =true)]
    public virtual DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 最后修改用户
    /// </summary>
    [SugarColumn(ColumnDescription = "最后修改用户", IsOnlyIgnoreInsert = true)]
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
}
