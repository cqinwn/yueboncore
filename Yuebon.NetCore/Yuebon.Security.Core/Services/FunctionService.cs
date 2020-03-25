using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class FunctionService: BaseService<Function, FunctionOutputDto, string>, IFunctionService
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

        /// <summary>
        /// 根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限
        /// </summary>
        /// <param name="enCode">菜单功能编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<FunctionOutputDto>> GetListByParentEnCode(string enCode)
        {
            string where = string.Format("EnCode='{0}'",enCode);
            Function function = await functionRepository.GetWhereAsync(where);
            where = string.Format("ParentId='{0}'", function.ParentId);
            IEnumerable<Function> list = await functionRepository.GetAllByIsNotEnabledMarkAsync(where);
            return list.MapTo<FunctionOutputDto>().ToList();
        }
    }
}