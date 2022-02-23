using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// ��֯�ִ��ӿ�
    /// �����õ���Organizeҵ��������������
    /// </summary>
    public interface IOrganizeRepository:IRepository<Organize>
    {
        /// <summary>
        /// ��ȡ���ڵ���֯
        /// </summary>
        /// <param name="id">��֯Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(string id);
    }
}