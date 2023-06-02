namespace Yuebon.TMS.Services
{
    /// <summary>
    /// 运输计划服务接口实现
    /// </summary>
    public partial class TransportplanService: BaseService<Transportplan,TransportplanOutputDto>, ITransportplanService
    {
        public TransportplanService(ITransportplanRepository _repository)
        {
			repository=_repository;
        }

        /// <summary>
        /// 根据运输计划单号查询
        /// </summary>
        /// <param name="transportNo">运输计划单号</param>
        /// <returns></returns>
        public async Task<Transportplan> GetByTransportNo(string transportNo) { 
            return await repository.GetWhereAsync(string.Format("TransportNo='{0}'", transportNo));
        }
    }
}