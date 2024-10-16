namespace Yuebon.Security.Repositories
{
    public class OrganizeRepository : BaseRepository<Organize>, IOrganizeRepository
    {
        public OrganizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        public Organize GetRootOrganize(long? id)
        {
            return Db.Queryable<Organize>().ToParentList(it => it.ParentId, id).FindLast(o=>o.Layers==1);
        }
        /// <summary>
        /// 树型查询递归查询
        /// </summary>
        /// <returns></returns>
        public async Task<List<Organize>> GetAllOrganizeTreeTable()
        {
            return await Db.Queryable<Organize>().ToTreeAsync(t=>t.Child,t=>t.ParentId,0);
        }
    }
}