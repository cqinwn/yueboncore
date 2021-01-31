using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.DependencyInjection;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.IServices;
using Yuebon.Commons.Json;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TODto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseService<T, TODto,TKey> : IService<T, TODto, TKey>, ITransientDependency
        where T: Entity
        where TODto : class
        where TKey : IEquatable<TKey>
    {
        private IHttpContextAccessor _accessor;
        /// <summary>
        /// 
        /// </summary>
        protected IRepository<T,TKey> repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRepository"></param>
        protected BaseService(IRepository<T, TKey> iRepository)
        {
            repository = iRepository ?? throw new ArgumentNullException(nameof(repository));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRepository"></param>
        /// <param name="accessor"></param>
        protected BaseService(IRepository<T, TKey> iRepository, IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            repository = iRepository ?? throw new ArgumentNullException(nameof(repository));

        }
        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual bool Delete(T entity,IDbTransaction trans=null)
        {
          return repository.Delete(entity);
        }
        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual bool Delete(TKey id, IDbTransaction trans = null)
        {
            return repository.Delete(id,trans);
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual Task<bool> DeleteAsync(TKey id, IDbTransaction trans = null)
        {
            return repository.DeleteAsync(id, trans);
        }


        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual Task<bool> DeleteAsync(T entity, IDbTransaction trans = null)
        {
            return repository.DeleteAsync(entity, trans);
        }

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual bool DeleteBatch(IList<dynamic> ids, IDbTransaction trans = null)
        {
            return repository.DeleteBatch(ids, trans);
        }


        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual bool DeleteBatchWhere(string where, IDbTransaction trans = null)
        {
            return repository.DeleteBatchWhere(where, trans);
        }

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteBatchWhereAsync(string where, IDbTransaction trans = null)
        {
            return await repository.DeleteBatchWhereAsync(where, trans);
        }
        /// <summary>
        /// 软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual bool DeleteSoft(bool bl, TKey id,string userId, IDbTransaction trans = null)
        {
            return repository.DeleteSoft(bl,id,userId, trans);
        }

        /// <summary>
        /// 异步软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteSoftAsync(bool bl, TKey id, string userId, IDbTransaction trans = null)
        {
            return await repository.DeleteSoftAsync(bl,id,userId, trans);
        }
        /// <summary>
        /// 异步批量软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteSoftBatchAsync(bool bl, string where, string userId = null, IDbTransaction trans = null)
        {
            return await repository.DeleteSoftBatchAsync(bl, where, userId, trans);
        }
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual T Get(TKey id)
        {
            return repository.Get(id);
        }

        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public virtual TODto GetOutDto(TKey id)
        {
            return repository.Get(id).MapTo<TODto>();
        }

        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual T GetWhere(string where, IDbTransaction trans = null)
        {
            return repository.GetWhere(where);
        }
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual TODto GetOutDtoWhere(string where, IDbTransaction trans = null)
        {
            return repository.GetWhere(where).MapTo<TODto>();
        }

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<T> GetWhereAsync(string where, IDbTransaction trans = null)
        {
            return await repository.GetWhereAsync(where);
        }

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<TODto> GetOutDtoWhereAsync(string where, IDbTransaction trans = null)
        {
            T info = await repository.GetWhereAsync(where);
            return info.MapTo<TODto>();
        }
        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetListTopWhere(int top, string where = null, IDbTransaction trans = null)
        {
            return repository.GetListTopWhere(top, where);
        }

        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListTopWhereAsync(int top, string where = null, IDbTransaction trans = null)
        {
            return await repository.GetListTopWhereAsync(top, where);
        }
        /// <summary>
        /// 同步查询所有实体。
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(IDbTransaction trans = null)
        {
            return repository.GetAll(trans);
        }

        /// <summary>
        /// 异步步查询所有实体。
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual Task<IEnumerable<T>> GetAllAsync(IDbTransaction trans = null)
        {
            return  repository.GetAllAsync(trans);
        }

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync(TKey id)
        {
            return await repository.GetAsync(id);
        }
        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<TODto> GetOutDtoAsync(TKey id)
        {
            T info=await repository.GetAsync(id);
            return info.MapTo<TODto>();
        }
        ///<summary>
        /// 根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>

        public virtual IEnumerable<T> GetListWhere(string where = null, IDbTransaction trans = null)
        {
            return repository.GetListWhere(where, trans);
        }
        ///<summary>
        /// 异步根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListWhereAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetListWhereAsync(where, trans);
        }
        /// <summary>
        /// 同步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual long Insert(T entity, IDbTransaction trans = null)
        {
            return repository.Insert(entity, trans);
        }

        /// <summary>
        /// 异步步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual Task<long> InsertAsync(T entity, IDbTransaction trans = null)
        {
            return repository.InsertAsync(entity, trans);
        }
        /// <summary>
        /// 同步批量新增实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns></returns>
        public virtual void Insert(List<T> entities)
        {
            repository.Insert(entities);
        }
        /// <summary>
        /// 同步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="id">主键ID</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual bool Update(T entity, TKey id, IDbTransaction trans = null)
        {
            return repository.Update(entity,id,trans);
        }


        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="id">主键ID</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual Task<bool> UpdateAsync(T entity, TKey id, IDbTransaction trans = null)
        {
            return repository.UpdateAsync(entity,id, trans);
        }


        /// <summary>
        /// 更新某一字段值,字段值字符类型
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值字符类型</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool UpdateTableField(string strField, string fieldValue, string where, IDbTransaction trans = null)
        {

            return repository.UpdateTableField(strField, fieldValue, where, trans);
        }
        /// <summary>
        /// 更新某一字段值,字段值字符类型
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值字符类型</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateTableFieldAsync(string strField, string fieldValue, string where, IDbTransaction trans = null)
        {
            return await repository.UpdateTableFieldAsync(strField, fieldValue, where, trans);
        }
        /// <summary>
        /// 更新某一字段值,字段值数字类型
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值数字</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool UpdateTableField(string strField, int fieldValue, string where, IDbTransaction trans = null)
        {
            return repository.UpdateTableField(strField, fieldValue, where, trans);
        }

        /// <summary>
        /// 更新某一字段值,字段值数字类型
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值数字</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateTableFieldAsync(string strField, int fieldValue, string where, IDbTransaction trans = null)
        {
            return await repository.UpdateTableFieldAsync(strField, fieldValue, where, trans);
        }
        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsDeleteMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsDeleteMark(where, trans);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsNotDeleteMark(where, trans);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsEnabledMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsEnabledMark(where, trans);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotEnabledMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsNotEnabledMark(where, trans);
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteAndEnabledMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsNotDeleteAndEnabledMark(where, trans);
        }

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsDeleteMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsDeleteMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsNotDeleteMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsEnabledMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsEnabledMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotEnabledMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsNotEnabledMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsNotDeleteAndEnabledMarkAsync(where, trans);
        }


        /// <summary>
        /// 设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual bool SetEnabledMark(bool bl, TKey id,string userId=null, IDbTransaction trans = null)
        {
            return repository.SetEnabledMark(bl, id, userId, trans);
        }

        /// <summary>
        /// 异步设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<bool> SetEnabledMarkAsync(bool bl, TKey id, string userId = null, IDbTransaction trans = null)
        {
            return await repository.SetEnabledMarkAsync(bl, id,userId, trans);
        }


        /// <summary>
        /// 异步按条件设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, string userId = null, IDbTransaction trans = null)
        {
            return await this.repository.SetEnabledMarkByWhereAsync(bl, where, userId, trans);
        }
        public virtual async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, object paramparameters = null, string userId = null, IDbTransaction trans = null)
        {
            return await this.repository.SetEnabledMarkByWhereAsync(bl, where, paramparameters, userId, trans);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info, IDbTransaction trans = null)
        {
            return repository.FindWithPager(condition, info, trans);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort, IDbTransaction trans = null)
        {
            return repository.FindWithPager(condition, info, fieldToSort, trans);
        }
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">是否降序</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
        {
            return repository.FindWithPager(condition, info, fieldToSort, desc, trans);
        }

        /// <summary>
        /// 分页查询，自行封装sql语句(仅支持sql server)
        /// 非常复杂的查询，可在具体业务模块重写该方法
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="info">分页信息</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">排序方式 true为desc，false为asc</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual List<T> FindWithPagerSql(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
        {
            return repository.FindWithPagerSql(condition, info, fieldToSort, desc,  trans);
        }


        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">排序方式</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
        {
            return await repository.FindWithPagerAsync(condition, info, fieldToSort, desc, trans);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// 查询条件变换时请重写该方法。
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public virtual PageResult<TODto> FindWithPager(SearchInputDto<T> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege();
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<T> list =repository.FindWithPager(where, pagerInfo, search.Sort, order);
            PageResult<TODto> pageResult = new PageResult<TODto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<TODto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }


        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// 查询条件变换时请重写该方法。
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<PageResult<TODto>> FindWithPagerAsync(SearchInputDto<T> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege();
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<T> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<TODto> pageResult = new PageResult<TODto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<TODto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort, IDbTransaction trans = null)
        {
            return await repository.FindWithPagerAsync(condition, info, fieldToSort,trans);
        }


        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, IDbTransaction trans = null)
        {
            return await repository.FindWithPagerAsync(condition, info, trans);
        }

        /// <summary>
        /// 分页查询，自行封装sql语句(仅支持sql server)
        /// 非常复杂的查询，可在具体业务模块重写该方法
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="info">分页信息</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">排序方式 true为desc，false为asc</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> FindWithPagerSqlAsync(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
        {
            return await repository.FindWithPagerAsync(condition, info,fieldToSort,desc, trans);
        }

        /// <summary>
        /// 分页查询包含用户信息(仅支持sql server)
        /// 查询主表别名为t1,用户表别名为t2，在查询字段需要注意使用t1.xxx格式，xx表示主表字段
        /// 用户信息主要有用户账号：Account、昵称：NickName、真实姓名：RealName、头像：HeadIcon、手机号：MobilePhone
        /// 输出对象请在Dtos中进行自行封装，不能是使用实体Model类
        /// </summary>
        /// <param name="condition">查询条件字段需要加表别名</param>
        /// <param name="info">分页信息</param>
        /// <param name="fieldToSort">排序字段，也需要加表别名</param>
        /// <param name="desc">排序方式</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual async Task<List<object>> FindWithPagerRelationUserAsync(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
        {
            return await repository.FindWithPagerRelationUserAsync(condition, info, fieldToSort, desc, trans);
        }

        /// <summary>
        /// 分页查询包含用户信息(仅支持sql server)
        /// 查询主表别名为t1,用户表别名为t2，在查询字段需要注意使用t1.xxx格式，xx表示主表字段
        /// 用户信息主要有用户账号：Account、昵称：NickName、真实姓名：RealName、头像：HeadIcon、手机号：MobilePhone
        /// 输出对象请在Dtos中进行自行封装，不能是使用实体Model类
        /// </summary>
        /// <param name="condition">查询条件字段需要加表别名</param>
        /// <param name="info">分页信息</param>
        /// <param name="fieldToSort">排序字段，也需要加表别名</param>
        /// <param name="desc">排序方式</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual  List<object> FindWithPagerRelationUser(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
        {
            return repository.FindWithPagerRelationUser(condition, info, fieldToSort, desc, trans);
        }
        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="fieldName">统计字段名称</param>
        /// <returns></returns>
        public virtual int GetCountByWhere(string condition, string fieldName = "*")
        {
            return repository.GetCountByWhere(condition, fieldName);
        }

        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="fieldName">统计字段名称</param>
        /// <returns></returns>
        public virtual async Task<int> GetCountByWhereAsync(string condition, string fieldName = "*")
        {
            return await repository.GetCountByWhereAsync(condition, fieldName);
        }

        /// <summary>
        /// 根据条件查询获取某个字段的最大值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <param name="trans">事务</param>
        /// <returns>返回字段的最大值</returns>
        public virtual async Task<dynamic> GetMaxValueByFieldAsync(string strField, string where, IDbTransaction trans = null)
        {
            return await repository.GetMaxValueByFieldAsync(strField,where);
        }

        /// <summary>
        /// 根据条件统计某个字段之和,sum(字段)
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <param name="trans">事务</param>
        /// <returns>返回字段求和后的值</returns>
        public virtual async Task<dynamic> GetSumValueByFieldAsync(string strField, string where, IDbTransaction trans = null)
        {
            return await repository.GetSumValueByFieldAsync(strField, where);
        }

        /// <summary>
        /// 多表操作--事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        public virtual async Task<Tuple<bool, string>> ExecuteTransactionAsync(List<Tuple<string, object>> trans, int? commandTimeout = null)
        {
            return await repository.ExecuteTransactionAsync(trans, commandTimeout);
        }
        /// <summary>
        /// 多表操作--事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        public virtual Tuple<bool, string> ExecuteTransaction(List<Tuple<string, object>> trans, int? commandTimeout = null)
        {
            return  repository.ExecuteTransaction(trans, commandTimeout);
        }
        /// <summary>
        /// 获取当前登录用户的数据访问权限
        /// </summary>
        /// <param name="blDeptCondition">是否开启，默认开启</param>
        /// <returns></returns>
        protected virtual string GetDataPrivilege(bool blDeptCondition=true)
        {
            string where = "1=1";
            //开权限数据过滤
            if (blDeptCondition)
            {
                var identities =HttpContextHelper.HttpContext.User.Identities;
                var claimsIdentity = identities.First<ClaimsIdentity>();
                List<Claim> claimlist = claimsIdentity.Claims as List<Claim>;
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                if (claimlist[1].Value != "admin")
                {
                    //如果公司过滤条件不为空，那么需要进行过滤
                    List<String> list = JsonSerializer.Deserialize<List<String>>(yuebonCacheHelper.Get("User_RoleData_" + claimlist[0].Value).ToJson());
                    string DataFilterCondition = String.Join(",", list.ToArray());
                    if (!string.IsNullOrEmpty(DataFilterCondition))
                    {
                        where += string.Format(" and (DeptId in ('{0}') or CreatorUserId='{1}')", DataFilterCondition.Replace(",", "','"), claimlist[0].Value);
                    }
                    bool isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
                    if (isMultiTenant)
                    {
                        where += string.Format(" and TenantId='{0}'", claimlist[3].Value);
                    }
                }
            }
            return where;
        }
        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用
        /// <summary>
        /// 
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
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BaseService() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        /// <summary>
        /// 添加此代码以正确实现可处置模式
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }




        #endregion
    }
}
