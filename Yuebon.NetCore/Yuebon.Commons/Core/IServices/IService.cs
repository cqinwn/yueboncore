using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.IServices
{
    /// <summary>
    /// 泛型应用服务接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TODto"></typeparam>
    public interface IService<T,TODto> : IDisposable where T : class
    {
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        T Get(long id);
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        TODto GetOutDto(long id);

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<TODto> GetOutDtoAsync(long id);

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<T> GetAsync(long id);

        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        T GetWhere(string where);
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        TODto GetOutDtoWhere(string where);

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        Task<T> GetWhereAsync(string where);

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        Task<TODto> GetOutDtoWhereAsync(string where);

        /// <summary>
        /// 同步查询所有实体。
        /// </summary>        
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// 异步查询所有实体。
        /// </summary>        
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();


        /// <summary>
        /// 根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        IEnumerable<T> GetListWhere(string where = null);
        /// <summary>
        /// 异步根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        Task<IEnumerable<T>> GetListWhereAsync(string where = null);

        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        IEnumerable<T> GetListTopWhere(int top, string where = null);

        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>        
        /// <returns></returns>
        Task<IEnumerable<T>> GetListTopWhereAsync(int top, string where = null);

        /// <summary>
        /// 同步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>        
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        /// 异步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>        
        /// <returns></returns>
        Task<int> InsertAsync(T entity);

        /// <summary>
        /// 同步批量新增实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        void Insert(List<T> entities);

        /// <summary>
        /// 新增或更新
        /// </summary>
        /// <param name="entities">数据集合</param>
        /// <param name="insertNum">返回新增数量</param>
        /// <param name="updateNum">返回更新数量</param>
        void InsertOrUpdate(List<T> entities,out int insertNum, out int updateNum);

        /// <summary>
        /// 同步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// 同步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        bool Update(T entity, string strWhere);

        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity, string strWhere);

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

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity);

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="id">主键</param>        
        /// <returns></returns>
        bool Delete(object id);

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="id">主键</param>        
        /// <returns></returns>
        Task<bool> DeleteAsync(object id);

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

        /// <summary>
        /// 同步软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>        
        /// <returns></returns>
        bool DeleteSoft(bool bl, object id, long userId);

        /// <summary>
        /// 异步软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>        
        /// <returns></returns>
        Task<bool> DeleteSoftAsync(bool bl, object id, long userId);

        /// <summary>
        /// 异步批量软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>        
        /// <returns></returns>
        Task<bool> DeleteSoftBatchAsync(bool bl, string where, long userId);

        /// <summary>
        /// 设置数据有效性，将EnabledMark设置为1-有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>        
        /// <returns></returns>
        bool SetEnabledMark(bool bl, object id, long userId);

        /// <summary>
        /// 异步设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>        
        /// <returns></returns>
        Task<bool> SetEnabledMarkAsync(bool bl, object id, long userId);

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
        /// <param name="paramparameters"></param>
        /// <param name="userId">操作用户</param>
        
        /// <returns></returns>
        Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, long userId, object paramparameters = null);

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        
        /// <returns></returns>
        IEnumerable<T> GetAllByIsDeleteMark(string where = null);

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<T> GetAllByIsNotDeleteMark(string where = null);

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<T> GetAllByIsEnabledMark(string where = null);
        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<T> GetAllByIsNotEnabledMark(string where = null);
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        IEnumerable<T> GetAllByIsNotDeleteAndEnabledMark(string where = null);

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByIsDeleteMarkAsync(string where = null);

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByIsNotDeleteMarkAsync(string where = null);
        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByIsEnabledMarkAsync(string where = null);

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByIsNotEnabledMarkAsync(string where = null);
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        
        /// <returns>指定对象的集合</returns>
        Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort, bool desc);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <returns>指定对象的集合</returns>
        List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort, bool desc);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>        
        /// <returns>指定对象的集合</returns>
        Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>        
        /// <returns>指定对象的集合</returns>
        List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>        
        /// <returns>指定对象的集合</returns>
        Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>        
        /// <returns>指定对象的集合</returns>
        List<T> FindWithPager(string condition, PagerInfo info);

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        PageResult<TODto> FindWithPager(SearchInputDto<T> search);
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        Task<PageResult<TODto>> FindWithPagerAsync(SearchInputDto<T> search);
        
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
        Task<int> GetCountByWhereAsync(string condition,string fieldName = "*");

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

        /// <summary>
        /// 多表操作--事务
        /// </summary>        
        /// <param name="trans"></param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        Task<Tuple<bool, string>> ExecuteTransactionAsync(List<Tuple<string, object>> trans, int? commandTimeout = null);
        /// <summary>
        /// 多表操作--事务
        /// </summary>        
        /// <param name="trans"></param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        Tuple<bool, string> ExecuteTransaction(List<Tuple<string, object>> trans, int? commandTimeout = null);
    }
}