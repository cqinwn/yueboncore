namespace Yuebon.TMS.Repositories
{
    /// <summary>
    /// 运输计划仓储接口的实现
    /// </summary>
    public partial class TransportplanRepository : BaseRepository<Transportplan>, ITransportplanRepository
    {

        public TransportplanRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}