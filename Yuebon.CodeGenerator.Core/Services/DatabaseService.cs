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
    /// 数据库信息服务接口实现
    /// </summary>
    public class DatabaseService: BaseService<Database,DatabaseOutputDto>, IDatabaseService
    {
        public DatabaseService(IDatabaseRepository _repository)
        {
			repository=_repository;
        }
    }
}