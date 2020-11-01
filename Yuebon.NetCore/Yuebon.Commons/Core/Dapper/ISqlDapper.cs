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
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="error"></param>
        void BeginTransaction(Func<ISqlDapper, bool> action, Action<Exception> error);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        long Add<T>(T entity, IDbTransaction trans = null) where T : Entity;


        /// <summary>
        /// 异步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        Task<long> AddAsync<T>(T entity, IDbTransaction trans = null) where T : Entity;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="updateFileds">指定插入的字段</param>
        /// <param name="beginTransaction">是否开启事务</param>
        /// <returns></returns>
        int AddRange<T>(IEnumerable<T> entities, Expression<Func<T, object>> updateFileds = null, bool beginTransaction = false);
    }
}
