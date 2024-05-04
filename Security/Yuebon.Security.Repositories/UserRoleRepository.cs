using Yuebon.Core.IRepositories;

namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// 系统用户角色表仓储接口的实现
    /// </summary>
    public partial class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        
        public UserRoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public override async Task<int> InsertAsync(List<UserRole> entities)
        {
            if (entities != null) { 
                await Db.Deleteable<UserRole>().Where(it => it.UserId == entities[0].UserId).ExecuteCommandAsync();  
            }
            return await Db.Insertable<UserRole>(entities).ExecuteCommandAsync();
        }

        /// <summary>
        /// 根据用户Id获取角色Id集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<long>> GetUserRoleIdList(long userId)
        {
            return await Db.Queryable<UserRole>()
                .Where(u => u.UserId == userId).Select(u => u.RoleId).ToListAsync();
        }

        public async Task<List<Role>> GetUserRoleList(long userId)
        {
            var sysUserRoleList = await Db.Queryable<UserRole>()
             .Mapper(u => u.SysRole, u => u.RoleId)
             .Where(u => u.UserId == userId).ToListAsync();
            return sysUserRoleList.Where(u => u.SysRole != null).Select(u => u.SysRole).ToList();
        }
    }
}