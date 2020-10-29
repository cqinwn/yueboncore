using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleRepository : BaseRepository<Role, string>, IRoleRepository
    {
        public RoleRepository()
        {
        }

        public RoleRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        //public IEnumerable<Role> GetWhere()
        //{
        //    _dbContext.Set<Role>().fr().Where()
        //}
    }
}