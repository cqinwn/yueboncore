namespace Yuebon.Security.Dtos;

/// <summary>
/// 日志搜索条件
/// </summary>
public class SearchLogModel : SearchInputDto<Log>
{
    /// <summary>
    /// 添加开始时间 
    /// </summary>
    public string? CreatorTime1
    {
        get; set;
    }
    /// <summary>
    /// 添加结束时间 
    /// </summary>
    public string? CreatorTime2
    {
        get; set;
    }
}
