namespace Yuebon.SecurityApi.Areas.Security.Controllers;

/// <summary>
/// SQL日志接口
/// </summary>
[ApiController]
[Route("api/Security/[controller]")]
public class SqlLogController : AreaApiController<SqlLog, SqlLogOutputDto,SqlLogInputDto,ISqlLogService>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_iService"></param>
    public SqlLogController(ISqlLogService _iService) : base(_iService)
    {
        iService = _iService;
    }
    /// <summary>
    /// 新增前处理数据
    /// </summary>
    /// <param name="info"></param>
    protected override void OnBeforeInsert(SqlLog info)
    {
        info.Id = IdGeneratorHelper.IdSnowflake();
        info.CreatorTime = DateTime.Now;
        info.CreatorUserId = CurrentUser.UserId;
    }
    
    /// <summary>
    /// 在更新数据前对数据的修改操作
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    protected override void OnBeforeUpdate(SqlLog info)
    {
    }
}