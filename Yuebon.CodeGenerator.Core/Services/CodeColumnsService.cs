using Yuebon.CodeGenerator.Dtos;
using Yuebon.CodeGenerator.IRepositories;
using Yuebon.CodeGenerator.IServices;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.Services
{
    /// <summary>
    /// 表字段服务接口实现
    /// </summary>
    public class CodeColumnsService: BaseService<CodeColumns,CodeColumnsOutputDto>, ICodeColumnsService
    {
        public CodeColumnsService(ICodeColumnsRepository _repository)
        {
			repository=_repository;
        }
    }
}