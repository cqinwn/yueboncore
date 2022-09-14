using Yuebon.CodeGenerator.IRepositories;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.Repositories
{
    /// <summary>
    /// 表信息仓储接口的实现
    /// </summary>
    public class CodeTableRepository : BaseRepository<CodeTable>, ICodeTableRepository
    {

        public CodeTableRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

    }
}