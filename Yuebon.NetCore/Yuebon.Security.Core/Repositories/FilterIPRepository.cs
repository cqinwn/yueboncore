using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Options;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class FilterIPRepository : BaseRepository<FilterIP, string>, IFilterIPRepository
    {
        public FilterIPRepository()
        {
            this.tableName = "Sys_FilterIP";
            this.primaryKey = "Id";
        }

        /// <summary>
        /// 验证IP地址是否被拒绝
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool ValidateIP(string ip)
        {
            long ipv = ip.Replace(".", "").ToLong();
            string where = " (cast(replace(StartIP,'.','') as bigint)>=" + ipv + " and cast(replace(EndIP,'.','') as bigint)<=" + ipv + ") and FilterType=0 and EnabledMark=1";
            int count = GetCountByWhere(where);
            return count > 0 ? true : false;
        }
    }
}