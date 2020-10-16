using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Commons.IRepositories
{
    /// <summary>
    /// Defines the interface(s) for unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns>/returns>
        int SaveChanges();

        /// <summary>
        /// 异步保存数据
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. The task result contains the number of state entities written to database.</returns>
        Task<int> SaveChangesAsync();

        #region command sql

        /// <summary>
        /// 异步查询
        /// ag:await _unitOfWork.QueryAsync`Demo`("select id,name from school where id = @id", new { id = 1 });
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param = null, IDbTransaction trans = null) where TEntity : class;

        /// <summary>
        /// 异步执行sql，用于插入、更新、删除数据
        /// ag:await _unitOfWork.ExecuteAsync("update school set name =@name where id =@id", new { name = "", id=1 });
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string sql, object param, IDbTransaction trans = null);

        #endregion

        #region Transaction
        /// <summary>
        /// BeginTransaction
        /// </summary>
        /// <returns></returns>
        IDbContextTransaction BeginTransaction();

        #endregion
        /// <summary>
        /// get connection
        /// </summary>
        /// <returns></returns>
        IDbConnection OpenSharedConnection();
    }
}
