using Yuebon.Commons.Enums;

namespace Yuebon.Security.Dtos;

/// <summary>
/// 输入对象模型
/// </summary>
[AutoMap(typeof(Role))]
[Serializable]
public class RoleInputDto: IInputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long OrganizeId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? Category { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string EnCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// 数据范围（1全部数据 2本部门及以下数据 3本部门数据 4仅本人数据 5自定义数据）
    /// </summary>
    public RoleDataScopeEnum DataScope { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? AllowEdit { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? AllowDelete { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? SortCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool EnabledMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string? Description { get; set; }


}
