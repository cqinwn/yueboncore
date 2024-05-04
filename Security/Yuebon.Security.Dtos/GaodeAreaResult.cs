namespace Yuebon.Security.Dtos;

/// <summary>
/// 高德地图行政区域查询返回结果
/// </summary>
public class GaodeAreaResult
{
    /// <summary>
    /// 返回结果状态值
    /// </summary>
    public string status{get;set;}
    /// <summary>
    /// 返回状态说明
    /// </summary>
    public string info { get;set; }
    /// <summary>
    /// 状态码
    /// </summary>
    public string infocode { get; set; }
    public GaodeAreaSuggestion suggestion { get; set; }
    public GaodeAreaDistrict[] districts { get; set; }
}
/// <summary>
/// 行政区域查询
/// </summary>
public class GaodeAreaSuggestion
{
    public string[] keywords { get; set; }
    public string[] cites { get; set; }
}
/// <summary>
/// 行政区信息
/// </summary>
public class GaodeAreaDistrict
{
    public object citycode { get; set; }
    public string adcode { get; set; }
    public string name { get; set; }
    public string polyline { get; set; }
    public string center { get; set; }
    public string level { get; set; }
    public GaodeAreaDistrict[] districts { get; set; }
}