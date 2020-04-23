using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yuebon.Commons.Models;
using Yuebon.Commons.IRepositories;
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
        public void BeginOrUseTransaction()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task BeginOrUseTransactionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Commit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public IDbContext GetDbContext<TEntity, TKey>() where TEntity : IBaseEntity<TKey>
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public IDbContext GetDbContext(Type entityType)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Rollback()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        IDbContext IUnitOfWork.GetDbContext<TEntity, TKey>()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        IDbContext IUnitOfWork.GetDbContext(Type entityType)
        {
            throw new NotImplementedException();
        }
    }
}
