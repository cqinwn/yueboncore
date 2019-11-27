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
using Yuebon.WebApp.ViewModels;

namespace Yuebon.WebApp.Commons
{
    public class Permission
    {

        private AuthHelper authHelper = IoCContainer.Resolve<AuthHelper>();
        /// <summary>
        /// 判断当前用户是否拥有某功能点的权限
        /// </summary>
        /// <param name="functionCode">功能编码code</param>
        /// <returns></returns>
        public  bool HasFunction(string functionCode)
        {
            UserLoginDto CurrentUser = SessionHelper.GetSession<UserLoginDto>("CurrentUser");
            //UserWithAccessedCtrls userWithAccessedCtrls = authHelper.GetCurrentUser();
            //User CurrentUser = userWithAccessedCtrls.User;
            bool hasFunction = false;
            if (CurrentUser != null && CurrentUser.Account == "admin")
            {
                hasFunction = true;
            }
            else
            {
                if (string.IsNullOrEmpty(functionCode))
                {
                    hasFunction = true;
                }
                else
                {
                    List<FunctionOutputDto> listFunction = JsonConvert.DeserializeObject<List<FunctionOutputDto>>(new YuebonCacheHelper().Get("User_Function_" +CurrentUser.UserId).ToJson());
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
        public  bool IsAdmin()
        {
            bool blnIsAdmin = false;
            UserLoginDto CurrentUser = SessionHelper.GetSession<UserLoginDto>("CurrentUser");
            //UserWithAccessedCtrls userWithAccessedCtrls = authHelper.GetCurrentUser();
            //User CurrentUser = userWithAccessedCtrls.User;
            if (CurrentUser != null)
            {
                string[] roleIds = CurrentUser.RoleId.Split(",");
                string where = string.Format("Id in('{0}')", CurrentUser.RoleId.Replace(",","','"));
                List<Role> listRole = new RoleApp().GetListWhere(where);
                foreach (Role item in listRole)
                {
                    if(item.FullName== "系统管理员" || item.FullName == "超级管理员")
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
