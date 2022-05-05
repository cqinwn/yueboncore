using System.Threading.Tasks;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class ItemsRepository : BaseRepository<Items>, IItemsRepository
    {
        public ItemsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 根据编码查询字典分类
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public async Task<Items> GetByEnCodAsynce(string enCode)
        {
            return await Db.Queryable<Items>().FirstAsync(u => u.EnCode == enCode);
        }


        /// <summary>
        /// 更新时判断分类编码是否存在（排除自己）
        /// </summary>
        /// <param name="enCode">分类编码</param
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public async Task<Items> GetByEnCodAsynce(string enCode,string id)
        {
            return await Db.Queryable<Items>().FirstAsync(u => u.EnCode == enCode&&u.Id!=id);
        }
    }
}