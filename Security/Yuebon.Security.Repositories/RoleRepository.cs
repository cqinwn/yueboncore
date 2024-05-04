namespace Yuebon.Security.Repositories;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    /// <summary>
    /// 根据用户ID获取角色编码
    /// </summary>
    /// <param name="userId">用户ID</param>
    /// <returns></returns>
    public async Task<List<long>> GetRoleIdsByUserId(long userId)
    {
      return await Db.Queryable<UserRole>().Where(it => it.UserId == userId).Select(it => it.RoleId).ToListAsync() ;
    }
}
