using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.CodeGenerator.IRepositories;
using Yuebon.CodeGenerator.IServices;
using Yuebon.CodeGenerator.Dtos;
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