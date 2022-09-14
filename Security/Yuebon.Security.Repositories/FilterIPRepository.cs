using Yuebon.Commons.Extensions;

namespace Yuebon.Security.Repositories
{
    public class FilterIPRepository : BaseRepository<FilterIP>, IFilterIPRepository
    {
        public FilterIPRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 验证IP地址是否被拒绝
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