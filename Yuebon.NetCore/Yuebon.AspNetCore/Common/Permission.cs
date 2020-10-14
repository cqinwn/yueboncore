using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.SSO;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Json;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Common
{
    /// <summary>
    /// 权限控制
    /// </summary>
    public static class Permission
    {
        /// <summary>
        /// 判断当前用户是否拥有某功能点的权限
        /// </summary>
        /// <param name="functionCode">功能编码code</param>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        public static bool HasFunction(string functionCode, string userId)
        {            
            bool hasFunction = false;
            if (!string.IsNullOrEmpty(userId)) { 
                if (string.IsNullOrEmpty(functionCode))
                {
                    hasFunction = true;
                }
                else
                {
                    List<FunctionOutputDto> listFunction = JsonConvert.DeserializeObject<List<FunctionOutputDto>>(new YuebonCacheHelper().Get("User_Function_" + userId).ToJson());
                    if (listFunction != null && listFunction.Count(t => t.EnCode == functionCode) > 0)
                    {
                        hasFunction = true;
                    }
                }
            }
            return hasFunction;
        }

        /// <summary>
        /// 判断是否为系统管理员或超级管理员
        /// </summary>
        /// <returns>true:系统管理员或超级管理员,false:不是系统管理员或超级管理员</returns>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public static bool IsAdmin(YuebonCurrentUser currentUser)
        {
            bool blnIsAdmin = false;
            if (currentUser != null)
            {
                string[] roleIds = currentUser.Role.Split(",");
                string where = string.Format("Id in('{0}')", currentUser.Role.Replace(",", "','"));
                List<Role> listRole = new RoleApp().GetListWhere(where);
                foreach (Role item in listRole)
                {
                    if (item.FullName == "系统管理员" || item.FullName == "超级管理员")
                    {
                        blnIsAdmin = true;
                        continue;
                    }
                }
            }
            return blnIsAdmin;
        }
    }
}
