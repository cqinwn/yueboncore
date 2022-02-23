using System;
using Yuebon.Commons.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 组织仓储接口
    /// 这里用到的Organize业务对象，是领域对象
    /// </summary>
    public interface IOrganizeRepository:IRepository<Organize>
    {
        /// <summary>
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(string id);
    }
}