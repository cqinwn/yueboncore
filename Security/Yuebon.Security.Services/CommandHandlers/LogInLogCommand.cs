namespace Yuebon.Security.Services.CommandHandlers;

/// <summary>
/// 登录日志
/// </summary>
public class LogInLogCommand :IRequest<bool>
{

    private LoginLog _loginLogInputDto;

    public LoginLog LoginLogInputDto { get => _loginLogInputDto; set => _loginLogInputDto = value; }
}
