using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    public interface IRoleService:IService<Role, string>
    {
        /// <summary>
        /// 根据角色编码获取角色
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public Role GetRole(string enCode);
    }
}
