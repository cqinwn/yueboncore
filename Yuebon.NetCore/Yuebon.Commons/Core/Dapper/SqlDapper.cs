using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.Dapper
{
    /// <summary>
    /// Dapper常用方法的实现
    /// </summary>
    public class SqlDapper : ISqlDapper
    {
        private IDbConnection dbConnection { get; set; }

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


        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="trans"></param>
        /// <returns></returns>

        public virtual long Add<T>(T entity, IDbTransaction trans) where T : Entity
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
        public virtual async Task<long> AddAsync<T>(T entity, IDbTransaction trans=null) where T : Entity
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            return await Connection.InsertAsync<T>(entity);
        }


        /// <summary>
        /// 批量添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="updateFileds"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual long AddRange<T>(List<T> entities, Expression<Func<T, object>> updateFileds = null, IDbTransaction trans = null)
        {
            try
            {
                trans = Connection.BeginTransaction();
                long row = Connection.Insert(entities, trans);
                trans.Commit();
                return row;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }

        #endregion

        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update<T>(T entity, IDbTransaction trans = null) where T : Entity
        {
            return Connection.Update(entity, trans);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateAsync<T>(T entity, IDbTransaction trans = null) where T : Entity
        {
            return await Connection.UpdateAsync<T>(entity, trans);
        }

        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update<T>(List<T> entities, IDbTransaction trans = null) 
        {
            try
            {
                trans = Connection.BeginTransaction();
                bool bl = Connection.Update(entities, trans);
                trans.Commit();
                return bl;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateAsync<T>(List<T> entities, IDbTransaction trans = null)
        {
            try
            {
                trans = Connection.BeginTransaction();
                bool bl =await Connection.UpdateAsync(entities, trans);
                trans.Commit();
                return bl;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete<T>(T entity, IDbTransaction trans = null) where T : Entity
        {
            trans = Connection.BeginTransaction();
            try
            {
                bool isSuccess = Connection.Delete<T>(entity, trans);
                trans.Commit();
                return isSuccess;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync<T>(T entity, IDbTransaction trans = null) where T : Entity
        {
            trans = Connection.BeginTransaction();
            try
            {
                bool isSuccess = await Connection.DeleteAsync<T>(entity, trans);
                trans.Commit();
                return isSuccess;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids">主键Id List集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteBatc<T>(IList<dynamic> ids, IDbTransaction trans = null)
        {
            Type entityType = typeof(T);
            var keyProperty = entityType.GetKeyProperty();
            if (keyProperty == null || ids == null || ids.Count == 0) return false;
            string tableName = entityType.GetCustomAttribute<TableAttribute>(false)?.Name;
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where PrimaryKey in (@PrimaryKey)";
           return ExcuteNonQuery(sql, null, CommandType.Text, true)>0;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <param name="beginTransaction"></param>
        /// <returns></returns>
        public virtual int ExcuteNonQuery(string cmd, object param, CommandType? commandType = null, bool beginTransaction = false)
        {
            return Execute<int>((conn, dbTransaction) =>
            {
                return conn.Execute(cmd, param, dbTransaction, commandType: commandType ?? CommandType.Text);
            }, beginTransaction);
        }


        #region 辅助类方法


        /// <summary>
        /// 验证是否存在注入代码(条件语句）
        /// </summary>
        /// <param name="inputData"></param>
        public virtual bool HasInjectionData(string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
                return false;

            //里面定义恶意字符集合
            //验证inputData是否包含恶意集合
            if (Regex.IsMatch(inputData.ToLower(), GetRegexString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取正则表达式
        /// </summary>
        /// <returns></returns>
        private string GetRegexString()
        {
            //构造SQL的注入关键字符
            string[] strBadChar =
            {
                "select\\s",
                "from\\s",
                "insert\\s",
                "delete\\s",
                "update\\s",
                "drop\\s",
                "truncate\\s",
                "exec\\s",
                "count\\(",
                "declare\\s",
                "asc\\(",
                "mid\\(",
                //"char\\(",
                "net user",
                "xp_cmdshell",
                "/add\\s",
                "exec master.dbo.xp_cmdshell",
                "net localgroup administrators"
            };

            //构造正则表达式
            string str_Regex = ".*(";
            for (int i = 0; i < strBadChar.Length - 1; i++)
            {
                str_Regex += strBadChar[i] + "|";
            }
            str_Regex += strBadChar[strBadChar.Length - 1] + ").*";

            return str_Regex;
        }


        #endregion
    }
}
