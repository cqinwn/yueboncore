using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.DataManager;
using Yuebon.Commons.DbContextCore;

namespace Yuebon.Commons.IDbContext
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDbContextFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writeAndRead">指定读、写操作</param>
        /// <returns></returns>
        BaseDbContext CreateContext(WriteAndReadEnum writeAndRead);
    }
}
