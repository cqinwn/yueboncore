using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Log;
using Yuebon.Commons.Options;
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

        public ItemsRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// 根据编码查询字典分类
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public async Task<Items> GetByEnCodAsynce(string enCode)
        {
            return await _dbContext.Set<Items>().SingleOrDefaultAsync<Items>(u => u.EnCode == enCode);
        }
    }
}