namespace Yuebon.Security.Repositories
{
    public class RoleDataRepository : BaseRepository<RoleData>, IRoleDataRepository
    {
        public RoleDataRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// ���ݽ�ɫ������Ȩ���ʲ�������
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