namespace Yuebon.Security.Repositories
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// ���Ͳ�ѯ�ݹ��ѯ
        /// </summary>
        /// <returns></returns>
        public async Task<List<Area>> GetAllAreaTreeTable()
        {
            return await Db.Queryable<Area>().ToTreeAsync(t => t.Child, t => t.ParentId, 0);
        }
    }
}