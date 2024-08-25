namespace Yuebon.Security.Repositories
{
    public class RoleDataRepository : BaseRepository<RoleData>, IRoleDataRepository
    {
        public RoleDataRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// 根据角色返回授权访问部门数据
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public async Task<List<long>> GetListDeptByRole(List<long> roleIds)
        {
            return await Db.Queryable<RoleData>().Where(it => roleIds.Contains(it.RoleId))
                .Select<long>(it=>it.AuthorizeData).ToListAsync();
           
        }

    }
}