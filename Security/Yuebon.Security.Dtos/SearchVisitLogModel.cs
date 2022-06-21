namespace Yuebon.Security.Application.Dtos;

public class SearchVisitLogModel : SearchInputDto<VisitLog>
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
