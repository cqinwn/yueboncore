using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.IoC;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Application
{
    public class RoleApp
    {
        IRoleService service = IoCContainer.Resolve<IRoleService>();

       public List<Role> GetListWhere(string where)
        {
           return service.GetListWhere(where).ToList();
        }

        /// <summary>
        /// 根据ID获取角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role GetRole(string id)
        {
            return service.Get(id);
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
            List<Role> listRoles = new RoleApp().GetListWhere(sqlWhere);
            string strEnCode = string.Empty;
            foreach(Role item in listRoles)
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
            List<Role> listRoles = new RoleApp().GetListWhere(sqlWhere);
            string strEnCode = string.Empty;
            foreach (Role item in listRoles)
            {
                strEnCode += item.FullName + ",";
            }
            return strEnCode;

        }
    }
}
