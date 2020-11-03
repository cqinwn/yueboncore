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
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="error"></param>
        void BeginTransaction(Func<ISqlDapper, bool> action, Action<Exception> error);
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
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
        /// <param name="trans">是否开启事务</param>
        /// <returns></returns>
        long AddRange<T>(List<T> entities, Expression<Func<T, object>> updateFileds = null, IDbTransaction trans = null);

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        bool Update<T>(T entity, IDbTransaction trans = null) where T : Entity;
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Update<T>(List<T> entities, IDbTransaction trans = null);
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        Task<bool> UpdateAsync<T>(List<T> entities, IDbTransaction trans = null);

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool Delete<T>(T entity, IDbTransaction trans = null) where T : Entity;

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        Task<bool> DeleteAsync<T>(T entity, IDbTransaction trans = null) where T : Entity;

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids">主键Id List集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool DeleteBatc<T>(IList<dynamic> ids, IDbTransaction trans = null);


    }
}
