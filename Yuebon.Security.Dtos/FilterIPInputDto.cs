namespace Yuebon.Security.Dtos;

/// <summary>
/// 输入对象模型
/// </summary>
[AutoMap(typeof(FilterIP))]
[Serializable]
public class FilterIPInputDto: IInputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? FilterType { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string StartIP { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string EndIP { get; set; }

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
