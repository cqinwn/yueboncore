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
        /// ���ݱ����ѯ�ֵ����
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public async Task<Items> GetByEnCodAsynce(string enCode)
        {
            return await Db.Queryable<Items>().FirstAsync(u => u.EnCode == enCode);
        }


        /// <summary>
        /// ����ʱ�жϷ�������Ƿ���ڣ��ų��Լ���
        /// </summary>
        /// <param name="enCode">�������</param
        /// <param name="id">����Id</param>
        /// <returns></returns>
        public async Task<Items> GetByEnCodAsynce(string enCode,long id)
        {
            return await Db.Queryable<Items>().FirstAsync(u => u.EnCode == enCode&&u.Id!=id);
        }
        /// <summary>
        /// �ݹ��ѯ��
        /// </summary>
        /// <returns></returns>
        public async Task<List<Items>> GetAllItemsTreeTable()
        {
            return await Db.Queryable<Items>().ToTreeAsync(t => t.Children, t => t.ParentId, 0);
        }
    }
}