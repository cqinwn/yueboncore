using Yuebon.CodeGenerator.Dtos;
using Yuebon.CodeGenerator.IRepositories;
using Yuebon.CodeGenerator.IServices;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.Services
{
    /// <summary>
    /// 表信息服务接口实现
    /// </summary>
    public class CodeTableService : BaseService<CodeTable, CodeTableOutputDto>, ICodeTableService
    {
        public CodeTableService(ICodeTableRepository _repository)
        {
			repository=_repository;
        }
    }
}