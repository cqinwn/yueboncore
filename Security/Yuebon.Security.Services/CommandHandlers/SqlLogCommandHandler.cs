namespace Yuebon.Security.Services.CommandHandlers;

/// <summary>
/// 访问日志
/// </summary>
public class SqlLogCommandHandler : IRequestHandler<SqlLogCommand, bool>
{
    private readonly ISqlLogService _SqlLogService;

    public SqlLogCommandHandler(ISqlLogService SqlLogService)
    {
        _SqlLogService = SqlLogService;
    }

    public async Task<bool> Handle(SqlLogCommand request, CancellationToken cancellationToken)
    {
        List<SqlLog> sqlLogs = request.SqlLogInputs;
        int row = await _SqlLogService.InsertAsync(sqlLogs);
        return row > 0;
    }
}
