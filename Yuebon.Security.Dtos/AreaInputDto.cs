namespace Yuebon.Security.Dtos;

/// <summary>
/// 输入对象模型
/// </summary>
[AutoMap(typeof(Area))]
[Serializable]
public class AreaInputDto: IInputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long ParentId { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? Layers { get; set; }

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
    public string SimpleSpelling { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string FullIdPath { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? IsLast { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public int? SortCode { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public bool? EnabledMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string Description { get; set; }


}
