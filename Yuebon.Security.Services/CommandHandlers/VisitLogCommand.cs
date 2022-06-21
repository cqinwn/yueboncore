namespace Yuebon.Security.Services.CommandHandlers;

/// <summary>
/// 访问日志
/// </summary>
public class VisitLogCommand : IRequest<bool>
{
    
    /// <summary>
    /// 访问日志
    /// </summary>
    private VisitLog visitLogInput;

    public VisitLog VisitLogInput { get => visitLogInput; set => visitLogInput = value; }
}
