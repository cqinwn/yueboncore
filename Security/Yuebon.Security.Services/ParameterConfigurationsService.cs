namespace Yuebon.Security.Services
{
    /// <summary>
    /// 系统参数配置服务接口实现
    /// </summary>
    public partial class ParameterConfigurationsService: BaseService<ParameterConfigurations,ParameterConfigurationsOutputDto>, IParameterConfigurationsService
    {
        public ParameterConfigurationsService(IParameterConfigurationsRepository _repository)
        {
			repository=_repository;
        }
    }
}