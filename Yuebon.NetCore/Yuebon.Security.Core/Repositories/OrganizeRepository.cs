using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

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
    }
}