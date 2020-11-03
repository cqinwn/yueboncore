using System.Threading.Tasks;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class ItemsRepository : BaseRepository<Items, string>, IItemsRepository
    {
        public ItemsRepository()
        {
        }

        public ItemsRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据编码查询字典分类
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public async Task<Items> GetByEnCodAsynce(string enCode)
        {
            return await DbContext.GetSingleOrDefaultAsync<Items>(u => u.EnCode == enCode);
        }
    }
}