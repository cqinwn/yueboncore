namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 定义系统用户角色表服务接口
    /// </summary>
    public partial interface IUserRoleService:IService<UserRole,UserRoleOutputDto>
    {
        // <summary>
        /// 根据用户Id获取角色Id集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<long>> GetUserRoleIdList(long userId);
    }
}
