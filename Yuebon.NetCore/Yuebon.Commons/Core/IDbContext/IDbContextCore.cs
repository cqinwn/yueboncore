using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.IDbContext
{
    /// <summary>
    /// 上下文基础接口
    /// </summary>
    public interface IDbContextCore: IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        DatabaseFacade GetDatabase();

        #region 新增
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add<T>(T entity) where T : class;
        /// <summary>
        /// 异步新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync<T>(T entity) where T : class;
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        int AddRange<T>(ICollection<T> entities) where T : class;
        /// <summary>
        /// 异步批量新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync<T>(ICollection<T> entities) where T : class;
        #endregion

        #region 删除
        /// <summary>
        /// 物理删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键</param>
        /// <returns></returns>
        int Delete<T,TKey>(TKey key) where T : Entity;

        /// <summary>
        /// 根据条件删除一个实体，返回影响记录行数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <returns></returns>
        ////int Delete<T>(Expression<Func<T, bool>> @where) where T : class;
        /// <summary>
        /// 根据条件删除一个实体，返回影响记录行数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <returns></returns>
        //Task<int> DeleteAsync<T>(Expression<Func<T, bool>> @where) where T : class;
        #endregion

        /// <summary>
        /// 创建数据表
        /// </summary>
        /// <returns></returns>
        bool EnsureCreated();
        /// <summary>
        /// 异步创建数据表
        /// </summary>
        /// <returns></returns>
        Task<bool> EnsureCreatedAsync();
        /// <summary>
        /// 执行Sql语句，返回影响记录行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlWithNonQuery(string sql, params object[] parameters);
        /// <summary>
        /// 执行Sql，返回影响记录行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<int> ExecuteSqlWithNonQueryAsync(string sql, params object[] parameters);

        #region 更新
        /// <summary>
        /// 更新保存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Edit<T>(T entity) where T : class;
        /// <summary>
        /// 批量更新保存实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        int EditRange<T>(ICollection<T> entities) where T : class;

        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">数据实体</param>
        /// <param name="updateColumns">指定字段</param>
        /// <returns></returns>
        int Update<T>(T model, params string[] updateColumns) where T : class;

        /// <summary>
        /// 按条件更新，
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <param name="updateFactory"></param>
        /// <returns></returns>
        //int Update<T>(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateFactory) where T : class;

        /// <summary>
        /// 按条件更新，
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">条件</param>
        /// <param name="updateFactory"></param>
        /// <returns></returns>
       // Task<int> UpdateAsync<T>(Expression<Func<T, bool>> @where, Expression<Func<T, T>> updateFactory)
        //    where T : class;
        #endregion

        #region 查询
        /// <summary>
        /// 根据条件统计数量Count()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        int Count<T>(Expression<Func<T, bool>> @where = null) where T : class;
        /// <summary>
        /// 根据条件异步统计数量Count()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<int> CountAsync<T>(Expression<Func<T, bool>> @where = null) where T : class;
        /// <summary>
        /// 是否存在,存在返回true，不存在返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        bool Exist<T>(Expression<Func<T, bool>> @where = null) where T : class;
        /// <summary>
        /// 是否存在,存在返回true，不存在返回false
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<bool> ExistAsync<T>(Expression<Func<T, bool>> @where = null) where T : class;
        /// <summary>
        /// 根据条件进行查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="include"></param>
        /// <param name="where">查询数据</param>
        /// <returns></returns>
        IQueryable<T> FilterWithInclude<T>(Func<IQueryable<T>, IQueryable<T>> include, Expression<Func<T, bool>> where) where T : class;
       
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        T Find<T>(object key) where T : class;

        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        T Find<T>(string key) where T : class;
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        T Find<T, TKey>(TKey key) where T : Entity;
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        Task<T> FindAsync<T>(object key) where T : class;
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="key">主键值</param>
        /// <returns></returns>
        Task<T> FindAsync<T,TKey>(TKey key) where T : Entity;
        /// <summary>
        /// 根据条件查询实体，返回实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <param name="asNoTracking">是否启用模型跟踪，默认为false不跟踪</param>
        /// <returns></returns>
        IQueryable<T> Get<T>(Expression<Func<T, bool>> @where = null, bool asNoTracking = false) where T : class;
        /// <summary>
        /// 获取所有实体类型
        /// </summary>
        /// <returns></returns>
        List<IEntityType> GetAllEntityTypes();
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        DbSet<T> GetDbSet<T>() where T : class;

        /// <summary>
        /// 根据条件查询一个实体，
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        T GetSingleOrDefault<T>(Expression<Func<T, bool>> @where = null) where T : class;

        /// <summary>
        /// 根据条件查询一个实体，
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<T> GetSingleOrDefaultAsync<T>(Expression<Func<T, bool>> @where = null) where T : class;
        #endregion

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities">数据实体集合</param>
        /// <param name="destinationTableName">数据库表名称，默认为实体名称</param>
        /// <returns></returns>
        void BulkInsert<T>(IList<T> entities, string destinationTableName = null)
            where T : class ;
        /// <summary>
        /// Sql查询，并返回实体集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        List<TView> SqlQuery<T, TView>(string sql, params object[] parameters) 
            where T : class;
        /// <summary>
        /// Sql查询，并返回实体集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns></returns>
        Task<List<TView>> SqlQueryAsync<T, TView>(string sql, params object[] parameters)
            where T : class
            where TView : class;
        /// <summary>
        /// 分页查询，SQL语句查询，返回指定输出对象集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <typeparam name="TView">返回/输出实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="orderBys">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="eachAction"></param>
        /// <returns></returns>
        PageResult<T> SqlQueryByPagination<T, TView>(string sql, string[] orderBys, int pageIndex, int pageSize, Action<TView> eachAction = null)
            where T : class
            where TView : class;
        /// <summary>
        /// 分页查询，SQL语句查询，返回数据实体集合
        /// </summary>
        /// <typeparam name="T">查询对象实体</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="orderBys">排序条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="parameters">查询SQL参数</param>
        /// <returns></returns>
        PageResult<T> SqlQueryByPagination<T>(string sql, string[] orderBys, int pageIndex, int pageSize,
            params DbParameter[] parameters) where T : class, new();
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">更改成功发送到数据库后是否调用AcceptAllChanges()</param>
        /// <returns></returns>
        int SaveChanges(bool acceptAllChangesOnSuccess);
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="cancellationToken">是否等待任务完成时要观察</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">是否更改成功发送到数据库后是否调用AcceptAllChanges()</param>
        /// <param name="cancellationToken">是否等待任务完成时要观察</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 根据sql语句返回DataTable数据
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="cmdTimeout">执行超时时间，默认30毫秒</param>
        /// <param name="parameters">DbParameter[]参数</param>
        /// <returns></returns>
        DataTable GetDataTable(string sql, int cmdTimeout = 30, params DbParameter[] parameters);

        /// <summary>
        /// 根据sql语句返回List集合数据
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="cmdTimeout">执行超时时间，默认30毫秒</param>
        /// <param name="parameters">DbParameter[]参数</param>
        /// <returns></returns>
        List<DataTable> GetDataTables(string sql, int cmdTimeout=30, params DbParameter[] parameters);

        #region 显式编译的查询,提高查询性能
        /// <summary>
        /// 根据主键查询返回一个实体，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        T GetByCompileQuery<T,TKey>(TKey id) where T : Entity;
        /// <summary>
        /// 根据主键查询返回一个实体，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">主键类型</typeparam>
        /// <param name="id">主键值</param>
        /// <returns></returns>
        Task<T> GetByCompileQueryAsync<T, TKey>(TKey id) where T : Entity;
        /// <summary>
        /// 根据条件查询返回实体集合，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        IList<T> GetByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 根据条件查询返回实体集合，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        Task<List<T>> GetByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 根据条件查询一个实体，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        T FirstOrDefaultByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 根据条件查询一个实体，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        Task<T> FirstOrDefaultByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 根据条件查询一个实体，启用模型跟踪，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        T FirstOrDefaultWithTrackingByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 根据条件查询一个实体，启用模型跟踪，该方法是显式编译的查询
        /// 检验序列中是否包含有元素。引用类型的默认值default(T)为null，表示在序列中没有找到元素。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        Task<T> FirstOrDefaultWithTrackingByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 统计数量Count()，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        int CountByCompileQuery<T>(Expression<Func<T, bool>> filter) where T : class;
        /// <summary>
        /// 统计数量Count()，该方法是显式编译的查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        Task<int> CountByCompileQueryAsync<T>(Expression<Func<T, bool>> filter) where T : class;
        #endregion
    }
}