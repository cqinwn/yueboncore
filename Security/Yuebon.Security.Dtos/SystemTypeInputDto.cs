namespace Yuebon.Security.Dtos;

/// <summary>
/// 输入对象模型
/// </summary>
[AutoMap(typeof(SystemType))]
[Serializable]
public class SystemTypeInputDto: IInputDto
{
    /// <summary>
    /// 设置或获取 
    /// </summary>
    public long Id { get; set; }

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
    public bool EnabledMark { get; set; }

    /// <summary>
    /// 设置或获取 
    /// </summary>
    public string Description { get; set; }


}
