namespace Yuebon.Core.Dtos;

/// <summary>
/// 用户可以使用模块菜单
/// </summary>
public class UserVisitMenus
{
    /// <summary>
    /// 设置或获取 主键Id
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 所属系统
    /// </summary>
    public string SystemTypeId { get; set; }

    /// <summary>
    /// 设置或获取 上级模块Id
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    /// 设置或获取 层级
    /// </summary>
    public int? Layers { get; set; }

    /// <summary>
    /// 设置或获取 编码
    /// </summary>
    public string EnCode { get; set; }

    /// <summary>
    /// 设置或获取 名称 
    /// </summary>
    public string FullName { get; set; }
}
