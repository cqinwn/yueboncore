namespace Yuebon.Security.Dtos;

/// <summary>
/// 输出对象模型
/// </summary>
[Serializable]
public class ItemsDetailOutputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long ItemId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long ParentId { get; set; }


    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string ParentName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string ItemCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string ItemName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(500)]
    public string SimpleSpelling { get; set; }

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
    public bool? DeleteMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? EnabledMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(500)]
    public string Description { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? CreatorTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long CreatorUserId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? LastModifyTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long LastModifyUserId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public DateTime? DeleteTime { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public long DeleteUserId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<ItemsDetailOutputDto> Children { get; set; }
}
