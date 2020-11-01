using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Models;

namespace Yuebon.Commons.Dapper
{
    /// <summary>
    /// Dapper常用方法的实现
    /// </summary>
    public class SqlDapper : ISqlDapper
    {
        public IDbConnection dbConnection { get; set; }

        IDbTransaction dbTransaction = null;
        /// <summary>
        /// 
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (dbConnection == null || dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection = DBServerProvider.GetDBConnection();
                }
                if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                return dbConnection;
            }
        }

        public SqlDapper()
        {
            DBServerProvider.GetConnectionString();
        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connKeyName"></param>
        public SqlDapper(string connKeyName)
        {
           DBServerProvider.GetConnectionString(connKeyName);
        }
        private bool _transaction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="error"></param>
        public void BeginTransaction(Func<ISqlDapper, bool> action, Action<Exception> error)
        {
            _transaction = true;
            try
            {
                dbTransaction = Connection.BeginTransaction();
                bool result = action(this);
                if (result)
                {
                    dbTransaction?.Commit();
                }
                else
                {
                    dbTransaction?.Rollback();
                }
            }
            catch (Exception ex)
            {
                dbTransaction?.Rollback();
                error(ex);
            }
            finally
            {
                Connection?.Dispose();
                dbTransaction?.Dispose();
                _transaction = false;
            }
        }


        private T Execute<T>(Func<IDbConnection, IDbTransaction, T> func, bool beginTransaction = false, bool disposeConn = true)
        {
            if (beginTransaction && !_transaction)
            {
                dbTransaction = Connection.BeginTransaction();
            }
            try
            {
                T reslutT = func(Connection, dbTransaction);
                if (!_transaction && dbTransaction != null)
                {
                    dbTransaction.Commit();
                }
                return reslutT;
            }
            catch (Exception ex)
            {
                if (!_transaction && dbTransaction != null)
                {
                    dbTransaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (!_transaction)
                {
                    if (disposeConn)
                    {
                        Connection.Dispose();
                    }
                    dbTransaction?.Dispose();
                }
            }
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="trans"></param>
        /// <returns></returns>

        public long Add<T>(T entity, IDbTransaction trans) where T : Entity
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            return Connection.Insert<T>(entity);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<long> AddAsync<T>(T entity, IDbTransaction trans) where T : Entity
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            return await Connection.InsertAsync<T>(entity);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <param name="beginTransaction"></param>
        /// <param name="disposeConn"></param>
        /// <returns></returns>
        private T ExecuteDb<T>(Func<IDbConnection, IDbTransaction, T> func, bool beginTransaction = false, bool disposeConn = true)
        {
            if (beginTransaction && !_transaction)
            {
                Connection.Open();
                dbTransaction = Connection.BeginTransaction();
            }
            try
            {
                T reslutT = func(Connection, dbTransaction);
                if (!_transaction && dbTransaction != null)
                {
                    dbTransaction.Commit();
                }
                return reslutT;
            }
            catch (Exception ex)
            {
                if (!_transaction && dbTransaction != null)
                {
                    dbTransaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (!_transaction)
                {
                    if (disposeConn)
                    {
                        Connection.Dispose();
                    }
                    dbTransaction?.Dispose();
                }
            }
        }

        public int AddRange<T>(IEnumerable<T> entities, Expression<Func<T, object>> updateFileds = null, bool beginTransaction = false)
        {
            throw new NotImplementedException();
        }
    }
}
