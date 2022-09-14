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
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        Organize GetRootOrganize(long? id);


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
    }
}
