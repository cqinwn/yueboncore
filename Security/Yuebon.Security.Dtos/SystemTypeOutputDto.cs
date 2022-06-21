namespace Yuebon.Security.Dtos;

/// <summary>
/// 输出对象模型
/// </summary>
[Serializable]
public class SystemTypeOutputDto
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
    public string EnCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(50)]
    public string FullName { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    [MaxLength(250)]
    public string Url { get; set; }

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


}
