using System;
using System.Collections.Generic;
using Yuebon.Commons.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IMenuService:IService<Menu, string>
    {

        /// <summary>
        /// 根据用户获取功能菜单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        List<Menu> GetMenuByUser(string userId);
    }
}
