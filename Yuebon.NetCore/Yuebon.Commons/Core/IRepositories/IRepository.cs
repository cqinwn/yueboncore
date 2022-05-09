using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.Commons.Pages;
namespace Yuebon.Commons.IRepositories
{
    /// <summary>
    /// 定义泛型接口,实体仓储模型的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IRepository<TEntity> :IDisposable where TEntity : class, new()
    {

        /// <summary>
        /// SqlsugarClient实体
        /// </summary>
        ISqlSugarClient Db { get; }

        #region 新增
        /// <summary>
        /// 同步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>

        /// <returns></returns>
        int Insert(TEntity entity);

        /// <summary>
        /// 异步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        
        /// <returns></returns>
        Task<int> InsertAsync(TEntity entity);

        /// <summary>
        /// 同步批量新增实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        void  Insert(List<TEntity> entities);

        /// <summary>
        /// 新增或更新
        /// </summary>
        /// <param name="entities">数据集合</param>
        /// <param name="insertNum">返回新增数量</param>
        /// <param name="updateNum">返回更新数量</param>
        void InsertOrUpdate(List<TEntity> entities, out int insertNum, out int updateNum);
        #endregion

        #region 删除
        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Delete(TEntity entity);

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        bool Delete(object primaryKey);

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(object primaryKey);

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool DeleteBatch(IList<dynamic> ids);

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        bool DeleteBatchWhere(string where);
        /// <summary>
        /// 异步按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        Task<bool> DeleteBatchWhereAsync(string where);

        #endregion

        #region 更新操作

        #region 更新实体或批量更新

        /// <summary>
        /// 同步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Update(TEntity entity);
        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity);
        /// <summary>
        /// 同步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        bool Update(TEntity entity, string strWhere);

        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(TEntity entity, string strWhere);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns">更新字段</param>
        /// <param name="lstIgnoreColumns">字段值</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        Task<bool> Update(TEntity entity,List<string> lstColumns = null,List<string> lstIgnoreColumns = null,string strWhere = "");
        #endregion

        #region 更新某一字段值
        /// <summary>
        /// 更新某一字段值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns></returns>
        bool UpdateTableField(string strField, string fieldValue, string where);

        /// <summary>
        /// 异步更新某一字段值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns></returns>
        Task<bool> UpdateTableFieldAsync(string strField, string fieldValue, string where);
        /// <summary>
        /// 更新某一字段值，字段值为数字
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值数字</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        bool UpdateTableField(string strField, int fieldValue, string where);
        /// <summary>
        /// 更新某一字段值，字段值为数字
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值数字</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        Task<bool> UpdateTableFieldAsync(string strField, int fieldValue, string where);
        #endregion

        #region 逻辑删除
        /// <summary>
        /// 同步软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        bool DeleteSoft(bool bl, object primaryKey, long userId);

        /// <summary>
        /// 异步软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        Task<bool> DeleteSoftAsync(bool bl, object primaryKey, long userId);

        /// <summary>
        /// 异步批量软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        Task<bool> DeleteSoftBatchAsync(bool bl, string where, long userId);

        #endregion
        
        #region 数据有效性
        /// <summary>
        /// 设置数据有效性，将EnabledMark设置为1-有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        bool SetEnabledMark(bool bl, object primaryKey, long userId);

        /// <summary>
        /// 异步设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        Task<bool> SetEnabledMarkAsync(bool bl, object primaryKey, long userId);


        /// <summary>
        /// 异步按条件设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, long userId);
        /// <summary>
        /// 异步按条件设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="where">条件</param>
        /// <param name="paramparameters">参数</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, long userId, object paramparameters = null);

        #endregion

        #endregion

        #region 查询


        #region 单个实体
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        TEntity Get(long primaryKey);

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(long primaryKey);

        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        TEntity GetWhere(string where);

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<TEntity> GetWhereAsync(string where);

        #endregion

        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();


        /// <summary>
        /// 根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        
        /// <returns></returns>
        IEnumerable<TEntity> GetListWhere(string where = null);
        /// <summary>
        /// 异步根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListWhereAsync(string where = null);
        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        IEnumerable<TEntity> GetListTopWhere(int top, string where = null);
        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetListTopWhereAsync(int top, string where = null);

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByIsDeleteMark(string where = null);
       
        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByIsNotDeleteMark(string where = null);

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByIsEnabledMark(string where = null);
        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByIsNotEnabledMark(string where = null);
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAllByIsNotDeleteAndEnabledMark(string where = null);

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllByIsDeleteMarkAsync(string where = null);

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllByIsNotDeleteMarkAsync(string where = null);
        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllByIsEnabledMarkAsync(string where = null);

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllByIsNotEnabledMarkAsync(string where = null);
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <returns>指定对象的集合</returns>
        Task<List<TEntity>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort, bool desc);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <returns>指定对象的集合</returns>
        List<TEntity> FindWithPager(string condition, PagerInfo info, string fieldToSort, bool desc);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <returns>指定对象的集合</returns>
        Task<List<TEntity>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <returns>指定对象的集合</returns>
        List<TEntity> FindWithPager(string condition, PagerInfo info, string fieldToSort);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        Task<List<TEntity>> FindWithPagerAsync(string condition, PagerInfo info);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        List<TEntity> FindWithPager(string condition, PagerInfo info);


        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="fieldName">统计字段名称</param>
        /// <returns></returns>
        int GetCountByWhere(string condition, string fieldName = "*");
        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="fieldName">统计字段名称</param>
        /// <returns></returns>
        Task<int> GetCountByWhereAsync(string condition, string fieldName = "*");

        /// <summary>
        /// 根据条件查询获取某个字段的最大值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <returns>返回字段的最大值</returns>
        Task<decimal> GetMaxValueByFieldAsync(string strField, string where);

        /// <summary>
        /// 根据条件统计某个字段之和,sum(字段)
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <returns>返回字段求和后的值</returns>
        Task<decimal> GetSumValueByFieldAsync(string strField, string where);

        #endregion

        #region 多表批量操作，支持事务

        /// <summary>
        /// 多表操作--事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        Task<Tuple<bool, string>> ExecuteTransactionAsync(List<Tuple<string, object>> trans, int? commandTimeout = null);
        /// <summary>
        /// 多表操作--事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        Tuple<bool, string> ExecuteTransaction(List<Tuple<string, object>> trans, int? commandTimeout = null);

        #endregion
    }
}
