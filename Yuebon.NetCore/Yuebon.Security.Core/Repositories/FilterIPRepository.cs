using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class FilterIPRepository : BaseRepository<FilterIP>, IFilterIPRepository
    {
        public FilterIPRepository()
        {
        }

        public FilterIPRepository(IDbContextCore dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// ��֤IP��ַ�Ƿ񱻾ܾ�
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool ValidateIP(string ip)
        {
            long ipv = ip.Replace(".", "").ToLong();
            string where = " replace(StartIP,'.','')>=" + ipv + " and replace(EndIP,'.','')<=" + ipv + " and FilterType=0 and EnabledMark=1";
            int count = GetCountByWhere(where);
            return count > 0 ? true : false;
        }
    }
}