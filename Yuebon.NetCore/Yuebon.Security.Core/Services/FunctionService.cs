using System;
using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class FunctionService: BaseService<Function, string>, IFunctionService
    {
        private readonly IFunctionRepository functionRepository;
        private readonly ILogService _logService;
        public FunctionService(IFunctionRepository repository, ILogService logService) : base(repository)
        {
            functionRepository = repository;
            _logService = logService;
            functionRepository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据角色ID字符串（逗号分开)和系统类型ID，获取对应的操作功能列表
        /// </summary>
        /// <param name="roleIDs">角色ID</param>
        /// <param name="typeID">系统类型ID</param>
        /// <returns></returns>
        public IEnumerable<Function> GetFunctions(string roleIDs, string typeID)
        {
            return functionRepository.GetFunctions(roleIDs, typeID);
        }
    }
}