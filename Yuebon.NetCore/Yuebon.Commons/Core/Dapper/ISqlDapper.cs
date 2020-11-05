using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Models;

namespace Yuebon.Commons.Dapper
{
    /// <summary>
    /// Dapper定义接口
    /// </summary>
    public interface ISqlDapper
    {

        /// <summary>
        /// 开启事务
        /// </summary>
        void BeginTransaction();
        /// <summary>
        /// 事务提交
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 事务回滚
        /// </summary>
        void RollBackTransaction();

        T Get<T>(dynamic primaryKey) where T : class;
        Task<T> GetAsync<T>(dynamic primaryKey) where T : class;
    }
}
