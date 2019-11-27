using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Yuebon.Commons.Entity
{
    /// <summary>
    /// 定义数据上下文接口
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// 提交数据上下文的变更
        /// </summary>
        /// <returns>操作影响的记录数</returns>
        int SaveChanges();

        /// <summary>
        /// 异步方式提交数据上下文的所有变更
        /// </summary>
        /// <param name="cancelToken">任务取消标识</param>
        /// <returns>操作影响的行数</returns>
        Task<int> SaveChangesAsync(CancellationToken cancelToken = default(CancellationToken));
    }
}
