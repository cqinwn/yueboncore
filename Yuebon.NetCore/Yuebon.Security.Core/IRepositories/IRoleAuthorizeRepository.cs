using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    public interface IRoleAuthorizeRepository:IRepository<RoleAuthorize>
    {
        /// <summary>
        /// �����ɫ��Ȩ
        /// </summary>
        /// <param name="roleId">��ɫId</param>
        /// <param name="roleAuthorizesList">��ɫ����ģ��</param>
        /// <param name="roleDataList">��ɫ�ɷ�������</param>
        /// <param name="trans"></param>
        /// <returns>ִ�гɹ�����<c>true</c>������Ϊ<c>false</c>��</returns>
        Task<bool> SaveRoleAuthorize(string roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList,
           IDbTransaction trans = null);
    }
}