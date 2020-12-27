using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Cache;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.Security.Application
{
    public class FunctionApp
    {

        IFunctionRepository service = IoCContainer.Resolve<IFunctionRepository>();
        ISystemTypeRepository serviceSystemType = IoCContainer.Resolve<ISystemTypeRepository>();
        IRoleRepository serviceRole = IoCContainer.Resolve<IRoleRepository>();
        IUserRepository serviceUser = IoCContainer.Resolve<IUserRepository>();

        /// <summary>
        /// 根据用户ID，获取对应的功能列表
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="typeID">系统类别ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsByUser(string userID, string typeID)
        {
            string where = string.Format("");
            string roleId = serviceUser.Get(userID).RoleId;
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            string roleIDsStr = string.Format("'{0}'",roleId.Replace(",","','"));
            if (roleIDsStr != "")
            {
                functions = service.GetFunctions(roleIDsStr, typeID).ToList().MapTo<FunctionOutputDto>();
            }
            return functions;
        }
        /// <summary>
        /// 根据用户角色IDs，获取对应的功能列表
        /// </summary>
        /// <param name="roleIds">用户角色ID</param>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsByRole(string roleIds, string systemId)
        {
            string where = string.Format("");
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            string roleIDsStr = string.Format("'{0}'", roleIds.Replace(",", "','"));
            if (roleIDsStr != "")
            {
                functions = service.GetFunctions(roleIDsStr, systemId).ToList().MapTo<FunctionOutputDto>();
            }
            return functions;
        }

        /// <summary>
        /// 根据用户角色IDs，获取对应的功能列表
        /// </summary>
        /// <param name="systemId">系统类型ID/子系统ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsBySystem(string systemId)
        {
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            functions = service.GetFunctions(systemId).ToList().MapTo<FunctionOutputDto>();
            return functions;
        }
        /// <summary>
        ///获取超级管理员操作所有功能，
        /// </summary>
        /// <param name="typeID">系统类别ID</param>
        /// <returns></returns>
        public List<FunctionOutputDto> GetFunctionsByAdmin(string typeID)
        {
            List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            functions = service.GetAll().ToList().MapTo<FunctionOutputDto>();
               
            return functions;
        }

    }
}
