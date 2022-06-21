namespace Yuebon.Security.Services.CommandHandlers;

/// <summary>
/// 登录日志处理命令
/// </summary>
public class LogInLogCommandHandler : IRequestHandler<LogInLogCommand,bool>
{
    private readonly ILoginLogService _loginLogService;

    public LogInLogCommandHandler(ILoginLogService loginLogService)
    {
        _loginLogService = loginLogService;
    }

    public async Task<bool> Handle(LogInLogCommand request, CancellationToken cancellationToken)
    {
        LoginLog loginLog = request.LoginLogInputDto;
        int row = await _loginLogService.InsertAsync(loginLog);
        return row > 0;
    }
}
