using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizeApp
    {
        /// <summary>
        /// 根据用户名获取用户及用户可访问的所有资源
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserWithAccessedCtrls GetAccessedControls(string username)
        {
            User userInfo = new User();
            userInfo = new UserApp().GetByUserName(username);
            //取得用户可使用的授权功能信息，并存储在缓存中
            FunctionApp functionApp = new FunctionApp();
            List<FunctionOutputDto> listFunction = functionApp.GetFunctionsByUser(userInfo.Id, "");
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            yuebonCacheHelper.Add("User_Function_" + userInfo.Id, listFunction);

            string roleIDsStr = string.Format("'{0}'", userInfo.RoleId.Replace(",", "','"));
            string sqlWhere = string.Format("Id in({0})",roleIDsStr);
            List<Role> listRoles = new RoleApp().GetListWhere(sqlWhere);
            List<RoleData> roleDataList = new RoleDataApp().FindByUser(userInfo.Id);
            UserWithAccessedCtrls userCtrls = new UserWithAccessedCtrls();
            UserLoginDto userLoginDto = userInfo.MapTo<UserLoginDto>();
            userLoginDto.Role = new RoleApp().GetRoleEnCode(userInfo.RoleId);
            var user = new UserWithAccessedCtrls
            {
                User = userLoginDto,
                Modules = listFunction,
                Roles = listRoles,
                RoleDatas=roleDataList
            };

            return user;
        }
    }
}
