using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Security.Dtos;

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
                if(currentUser.Account == "admin"|| currentUser.Role.Contains("administrators",StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return blnIsAdmin;
        }
    }
}
