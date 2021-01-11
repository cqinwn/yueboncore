using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public interface IOrganizeService:IService<Organize, OrganizeOutputDto, string>
    {

        /// <summary>
        /// 获取组织机构适用于Vue 树形列表
        /// </summary>
        /// <returns></returns>
        Task<List<OrganizeOutputDto>> GetAllOrganizeTreeTable();

        /// <summary>
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(string id);


        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        CommonResult DeleteBatchWhere(DeletesInputDto ids, IDbTransaction trans = null);
        /// <summary>
        /// 异步按条件批量删除
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids, IDbTransaction trans = null);
    }
}
