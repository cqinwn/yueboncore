using SqlSugar;

namespace Yuebon.Core.Models;

/// <summary>
/// 租户实体
/// </summary>
public abstract class TenantEntity: BaseEntity,IMustHaveTenant
{
    /// <summary>
    /// 设置或获取 租户
    /// </summary>
    [SugarColumn(ColumnDescription = "租户", IsOnlyIgnoreUpdate = true)]
    public virtual long TenantId { get; set; }
}
