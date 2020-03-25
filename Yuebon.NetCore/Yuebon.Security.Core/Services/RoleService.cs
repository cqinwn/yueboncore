using System;
using System.Collections.Generic;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class RoleService: BaseService<Role, RoleOutputDto, string>, IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly ILogService _logService;
        public RoleService(IRoleRepository repository, ILogService logService) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _repository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据角色编码获取角色
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public Role GetRole(string enCode)
        {
            string where = string.Format("EnCode='{0}'",enCode);
            return _repository.GetWhere(where);
        }


        /// <summary>
        /// 根据用户角色ID获取角色编码
        /// </summary>
        /// <param name="ids">角色ID字符串，用“,”分格</param>
        /// <returns></returns>
        public string GetRoleEnCode(string ids)
        {
            string roleIDsStr = string.Format("'{0}'", ids.Replace(",", "','"));
            string sqlWhere = string.Format("Id in({0})", roleIDsStr);
            IEnumerable<Role> listRoles = _repository.GetListWhere(sqlWhere);
            string strEnCode = string.Empty;
            foreach (Role item in listRoles)
            {
                strEnCode += item.EnCode + ",";
            }
            return strEnCode;

        }


        /// <summary>
        /// 根据用户角色ID获取角色编码
        /// </summary>
        /// <param name="ids">角色ID字符串，用“,”分格</param>
        /// <returns></returns>
        public string GetRoleNameStr(string ids)
        {
            string roleIDsStr = string.Format("'{0}'", ids.Replace(",", "','"));
            string sqlWhere = string.Format("Id in({0})", roleIDsStr);
            IEnumerable<Role> listRoles = _repository.GetListWhere(sqlWhere);
            string strEnCode = string.Empty;
            foreach (Role item in listRoles)
            {
                strEnCode += item.FullName + ",";
            }
            return strEnCode;

        }
    }
}