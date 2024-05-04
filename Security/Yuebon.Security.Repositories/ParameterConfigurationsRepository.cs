namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 系统参数配置仓储接口的实现
    /// </summary>
    public partial class ParameterConfigurationsRepository : BaseRepository<ParameterConfigurations>, IParameterConfigurationsRepository
    {

        public ParameterConfigurationsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}