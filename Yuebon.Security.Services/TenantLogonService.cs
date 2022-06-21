namespace Yuebon.Security.Services;

/// <summary>
/// 用户登录信息服务接口实现
/// </summary>
public class TenantLogonService : BaseService<TenantLogon,TenantLogonOutputDto>, ITenantLogonService
{
		private readonly ITenantLogonRepository _repository;
    public TenantLogonService(ITenantLogonRepository trepository)
    {
        repository = trepository;
        _repository = trepository;
    }
}