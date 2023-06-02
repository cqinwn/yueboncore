

namespace Yuebon.TMS.IServices
{
    /// <summary>
    /// 定义运输计划服务接口
    /// </summary>
    public partial interface ITransportplanService:IService<Transportplan,TransportplanOutputDto>
    {
        /// <summary>
        /// 根据运输计划单号查询
        /// </summary>
        /// <param name="transportNo">运输计划单号</param>
        /// <returns></returns>
        Task<Transportplan> GetByTransportNo(string transportNo);
    }
}
