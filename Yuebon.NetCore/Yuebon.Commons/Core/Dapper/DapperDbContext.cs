using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Text;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Log;

namespace Yuebon.Commons.Core.Dapper
{
    /// <summary>
    /// 注册的时候 InstancePerLifetimeScope
    /// 线程内唯一（也就是单个请求内唯一）
    /// </summary>
    public class DapperDbContext
    {

        private IDbConnection dbConnection { get; set; }

        /// <summary>
        /// 获取的数据库连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="masterDb"></param>
        /// <returns></returns>
        public IDbConnection GetConnection<T>(bool masterDb = true) where T : class
        {
            if (dbConnection == null || dbConnection.State == ConnectionState.Closed)
            {
                dbConnection = DBServerProvider.GetDBConnection<T>(masterDb);

                if (MiniProfiler.Current != null)
                {
                    dbConnection = new StackExchange.Profiling.Data.ProfiledDbConnection((DbConnection)dbConnection, MiniProfiler.Current);
                }
            }
            return dbConnection;
        }

        /// <summary>
        /// 事务
        /// </summary>
        public IDbTransaction DbTransaction { get; set; }

        /// <summary>
        /// 是否已被提交
        /// </summary>
        public bool Committed { get; private set; } = true;

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            Committed = false;
            bool isClosed = dbConnection.State == ConnectionState.Closed;
            if (isClosed) dbConnection.Open();
            DbTransaction = dbConnection?.BeginTransaction();
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void CommitTransaction()
        {
            DbTransaction?.Commit();
            Committed = true;
            Dispose();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollBackTransaction()
        {
            DbTransaction?.Rollback();
            Committed = true;
            Dispose();
        }


        #region Dispose实现
        private bool disposedValue = false; // 要检测冗余调用



        /// <summary>
        /// 释放
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。

                disposedValue = true;
            }
            if (dbConnection != null)
            {
                DbTransaction.Dispose();
                dbConnection.Dispose();
            }
        }
        /// <summary>
        /// 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);

            DbTransaction?.Dispose();
            if (dbConnection.State == ConnectionState.Open)
                dbConnection?.Close();
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion

    }
}
