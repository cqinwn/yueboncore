using Yuebon.Core.Dtos;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public interface IOrganizeService:IService<Organize, OrganizeOutputDto>
    {

        /// <summary>
        /// 获取组织机构适用于Vue 树形列表
        /// </summary>
        /// <returns></returns>
        Task<List<Organize>> GetAllOrganizeTreeTable();
        /// <summary>
        ///  根据节点Id获取子节点Id集合(包含自己)
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        Task<List<long>> GetChildIdListWithSelfById(long pid);
        /// <summary>
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(long? id);
        /// <summary>
        /// 根据当前登录用户获取机构Id集合
        /// </summary>
        /// <returns></returns>
        Task<List<long>> GetUserOrgIdList();
        /// <summary>
        /// 根据用户角色获取组织Id集合
        /// </summary>
        /// <param name = "userId"> 用户ID </ param >
        /// < returns ></ returns >
        Task<List<long>> GetUserRoleOrgIdList(long userId);
        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <returns></returns>
        CommonResult DeleteBatchWhere(DeletesInputDto ids);
        /// <summary>
        /// 异步按条件批量删除
        /// </summary>
        /// <param name="ids">主键Id集合</param>
        /// <returns></returns>
        Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto ids);

        /// <summary>
        /// 根据组织类型获取公司级组织
        /// </summary>
        /// <param name="orgType">组织类型</param>
        /// <returns></returns>
        Task<List<Organize>> GetOrganizesByOrgTypeAsync(string orgType);
    }
}
