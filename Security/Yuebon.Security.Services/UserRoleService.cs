namespace Yuebon.Security.Services
{
    /// <summary>
    /// 系统用户角色表服务接口实现
    /// </summary>
    public partial class UserRoleService: BaseService<UserRole,UserRoleOutputDto>, IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        public UserRoleService(IRepository<UserRole> _repository,IUserRoleRepository userRoleRepository)
        {
			repository=_repository;
            _userRoleRepository= userRoleRepository;
        }
        /// <summary>
        /// 根据用户Id获取角色Id集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<long>> GetUserRoleIdList(long userId)
        {
            return await _userRoleRepository.GetUserRoleIdList(userId);
        }
    }
}