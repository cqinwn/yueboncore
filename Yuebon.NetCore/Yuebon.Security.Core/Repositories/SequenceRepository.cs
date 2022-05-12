using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 单据编码仓储接口的实现
    /// </summary>
    public class SequenceRepository : BaseRepository<Sequence>, ISequenceRepository
    {
        public SequenceRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}