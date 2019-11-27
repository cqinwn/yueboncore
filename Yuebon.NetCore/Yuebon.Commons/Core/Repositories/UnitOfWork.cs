using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yuebon.Commons.Models;
using Yuebon.Commons.Entity;

namespace Yuebon.Commons.Repositories
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //private DbTransaction _transaction;
        //private DbConnection _dbConnection;
        //private bool _disposed;
        /// <summary>
        /// 获取 事务是否已提交
        /// </summary>
        public bool HasCommitted { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
