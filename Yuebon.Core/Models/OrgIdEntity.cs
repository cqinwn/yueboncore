using SqlSugar;

namespace Yuebon.Core.Models;
/// <summary>
/// 创建者部门Id
/// </summary>
public abstract class OrgIdEntity : IOrgIdFilter
{

    /// <summary>
    /// 设置或获取 创建者部门Id
    /// </summary>
    [SugarColumn(ColumnDescription = "创建者部门Id",IsOnlyIgnoreUpdate =true)]
    public long? CreateOrgId { get; set; }
}
