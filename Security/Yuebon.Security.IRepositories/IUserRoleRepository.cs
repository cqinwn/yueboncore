using Yuebon.Core.IRepositories;

namespace Yuebon.Security.IRepositories
{
    /// <summary>
    /// 定义系统用户角色表仓储接口
    /// </summary>
    public partial interface IUserRoleRepository:IRepository<UserRole>
    {
        /// <summary>
        /// 根据用户Id获取角色Id集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<long>> GetUserRoleIdList(long userId);
        Task<List<Role>> GetUserRoleList(long userId);

    }
}