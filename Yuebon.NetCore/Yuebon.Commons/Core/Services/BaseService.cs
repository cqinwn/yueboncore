using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Yuebon.Commons.Models;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Repositories;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Models;
using System.Data;

namespace Yuebon.Commons.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Tkey"></typeparam>
    public abstract class BaseService<T,Tkey>
        where T: class, IBaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        /// <summary>
        /// 
        /// </summary>
        protected IRepository<T,Tkey> repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iRepository"></param>
        protected BaseService(IRepository<T, Tkey> iRepository)
        {
            repository = iRepository ?? throw new ArgumentNullException(nameof(repository));
        }
        /// <summary>
        /// 查询对象，并返回关联的创建用户信息，
        /// 查询表别名为s，条件要s.字段名
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public T GetByIdRelationUser(string id, IDbTransaction trans = null)
        {
            return repository.GetByIdRelationUser(id, trans);
        }
        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public bool Delete(T entity,IDbTransaction trans=null)
        {
          return repository.Delete(entity, trans);
        }
        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public bool Delete(Tkey id, IDbTransaction trans = null)
        {
            return repository.Delete(id,trans);
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Tkey id, IDbTransaction trans = null)
        {
            return repository.DeleteAsync(id, trans);
        }

        /// <summary>
        /// 同步物理删除所有实体。
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public bool DeleteAll(IDbTransaction trans = null)
        {
            return repository.DeleteAll(trans);
        }

        /// <summary>
        /// 异步物理删除所有实体。
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<bool> DeleteAllAsync(IDbTransaction trans = null)
        {
            return repository.DeleteAllAsync(trans);
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(T entity, IDbTransaction trans = null)
        {
            return repository.DeleteAsync(entity, trans);
        }

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool DeleteBatch(IList<dynamic> ids, IDbTransaction trans = null)
        {
            return repository.DeleteBatch(ids, trans);
        }


        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool DeleteBatchWhere(string where, IDbTransaction trans = null)
        {
            return repository.DeleteBatchWhere(where, trans);
        }
        /// <summary>
        /// 软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="id">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool DeleteSoft(bool bl, Tkey id,string userId, IDbTransaction trans = null)
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
        public Task<bool> DeleteSoftAsync(bool bl, Tkey id, string userId, IDbTransaction trans = null)
        {
            return repository.DeleteSoftAsync(bl,id,userId, trans);
        }
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public T Get(Tkey id, IDbTransaction trans = null)
        {
            return repository.Get(id, trans);
        }
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public T GetWhere(string where, IDbTransaction trans = null)
        {
            return repository.GetWhere(where, trans);
        }

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public async Task<T> GetWhereAsync(string where, IDbTransaction trans = null)
        {
            return await repository.GetWhereAsync(where, trans);
        }

        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public IEnumerable<T> GetListTopWhere(int top, string where = null, IDbTransaction trans = null)
        {
            return repository.GetListTopWhere(top, where);
        }
        /// <summary>
        /// 同步查询所有实体。
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(IDbTransaction trans = null)
        {
            return repository.GetAll(trans);
        }

        /// <summary>
        /// 异步步查询所有实体。
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetAllAsync(IDbTransaction trans = null)
        {
            return  repository.GetAllAsync(trans);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public Task<T> GetAsync(Tkey id, IDbTransaction trans = null)
        {
            return repository.GetAsync(id, trans);
        }
        ///<summary>
        /// 根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>

        public IEnumerable<T> GetListWhere(string where = null, IDbTransaction trans = null)
        {
            return repository.GetListWhere(where, trans);
        }
        ///<summary>
        /// 异步根据查询条件查询数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListWhereAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetListWhereAsync(where, trans);
        }
        /// <summary>
        /// 同步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public long Insert(T entity, IDbTransaction trans = null)
        {
            return repository.Insert(entity, trans);
        }

        /// <summary>
        /// 异步步新增实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<long> InsertAsync(T entity, IDbTransaction trans = null)
        {
            return repository.InsertAsync(entity, trans);
        }
        /// <summary>
        /// 同步批量新增实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public long Insert(List<T> entities, IDbTransaction trans = null)
        {
            return repository.Insert(entities, trans);
        }
        /// <summary>
        /// 异步批量新增实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<long> InsertAsync(List<T> entities, IDbTransaction trans = null)
        {
            return repository.InsertAsync(entities, trans);
        }

        /// <summary>
        /// 同步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="id">主键ID</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public bool Update(T entity, Tkey id, IDbTransaction trans = null)
        {
            return repository.Update(entity,id,trans);
        }

        /// <summary>
        /// 同步批量更新实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public bool Update(List<T> entities, IDbTransaction trans = null)
        {
            return repository.Update(entities, trans);
        }

        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="id">主键ID</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(T entity, Tkey id, IDbTransaction trans = null)
        {
            return repository.UpdateAsync(entity,id, trans);
        }

        /// <summary>
        /// 异步批量更新实体。
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(List<T> entities, IDbTransaction trans = null)
        {
            return repository.UpdateAsync(entities, trans);
        }


        /// <summary>
        /// 更新某一字段值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool UpdateTableField(string strField, string fieldValue, string where, IDbTransaction trans = null)
        {

            return repository.UpdateTableField(strField, fieldValue, where, trans);
        }

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAllByIsDeleteMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsDeleteMark(where, trans);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAllByIsNotDeleteMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsNotDeleteMark(where, trans);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAllByIsEnabledMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsEnabledMark(where, trans);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAllByIsNotEnabledMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsNotEnabledMark(where, trans);
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAllByIsNotDeleteAndEnabledMark(string where = null, IDbTransaction trans = null)
        {
            return repository.GetAllByIsNotDeleteAndEnabledMark(where, trans);
        }

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllByIsDeleteMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsDeleteMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllByIsNotDeleteMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsNotDeleteMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllByIsEnabledMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsEnabledMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllByIsNotEnabledMarkAsync(string where = null, IDbTransaction trans = null)
        {
            return await repository.GetAllByIsNotEnabledMarkAsync(where, trans);
        }

        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null, IDbTransaction trans = null)
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
        public bool SetEnabledMark(bool bl, Tkey id,string userId=null, IDbTransaction trans = null)
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
        public async Task<bool> SetEnabledMarkAsync(bool bl, Tkey id, string userId = null, IDbTransaction trans = null)
        {
            return await repository.SetEnabledMarkAsync(bl, id,userId, trans);
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
        /// 分页查询，自行封装sql语句
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
        /// 分页查询包含用户信息
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

        // 添加此代码以正确实现可处置模式。
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
