using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.IServices;
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
    }
}
