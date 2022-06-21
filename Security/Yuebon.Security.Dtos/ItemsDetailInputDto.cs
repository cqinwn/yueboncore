namespace Yuebon.Security.Dtos;

/// <summary>
/// 输入对象模型
/// </summary>
[AutoMap(typeof(ItemsDetail))]
[Serializable]
public class ItemsDetailInputDto: IInputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long ItemId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string ItemCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string ItemName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string? SimpleSpelling { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? IsDefault { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? Layers { get; set; }

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
