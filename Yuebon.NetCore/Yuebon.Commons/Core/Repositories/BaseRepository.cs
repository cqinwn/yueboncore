using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.DependencyInjection;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Log;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.Repositories
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class BaseRepository<T> : IRepository<T>, ITransientDependency where T : class, new ()
    {
        #region 构造函数及基本配置

        /// <summary>
        /// 需要初始化的对象表名
        /// </summary>
        protected string tableName =typeof(T).GetCustomAttribute<SugarTable>()?.TableName;
        
        /// <summary>
        /// 数据库的主键字段名,若主键不是Id请重载BaseRepository设置
        /// </summary>
        protected string primaryKey = "Id";
        /// <summary>
        /// 排序字段
        /// </summary>
        protected string sortField;
        /// <summary>
        /// 是否为降序
        /// </summary>
        protected bool isDescending = true;
        /// <summary>
        /// 选择的字段，默认为所有(*) 
        /// </summary>
        protected string selectedFields = " * ";

        /// <summary>
        /// 数据库配置名称
        /// </summary>
        private static string dbConfigName = "DefaultDb";

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField
        {
            get
            {
                return sortField;
            }
            set
            {
                sortField = value;
            }
        }

        /// <summary>
        /// 数据库访问对象的外键约束
        /// </summary>
        public string PrimaryKey
        {
            get
            {
                return primaryKey;
            }
        }
        /// <summary>
        /// 
        /// </summary> 
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// 
        /// </summary>
        private SqlSugarScope _dbBase;

        private ISqlSugarClient _db
        {
            get
            {
                string t = typeof(T).Name;
                dbConfigName = typeof(T).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName ?? "DefaultDb";
                if (Appsettings.GetValue("AppSetting:MutiDBEnabled").ObjToBool())
                {
                    _dbBase.ChangeDatabase(dbConfigName.ToLower());                    
                }

                return _dbBase;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ISqlSugarClient Db
        {
            get { return _db; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbBase = unitOfWork.GetDbClient();
        }

        #endregion

        #region SqlSugar 操作


        #region 查询获得对象和列表

        #region 单个实体
        /// <summary>
        /// 同步查询单个实体。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public T Get(long primaryKey)
        {
            return Db.Queryable<T>().InSingle(primaryKey);
        }

        /// <summary>
        /// 异步查询单个实体。
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public async Task<T> GetAsync(long primaryKey)
        {
            return await Db.Queryable<T>().InSingleAsync(primaryKey);
        }
        /// <summary>
        /// 根据条件获取一个对象
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual T GetWhere(string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select * from { tableName} ";
            sql += " where " + where;
            return Db.Ado.SqlQuerySingle<T>(sql);
        }

        /// <summary>
        /// 根据条件异步获取一个对象
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<T> GetWhereAsync(string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select * from { tableName} ";
            sql += " where " + where;

            return await Db.Ado.SqlQuerySingleAsync<T>(sql);
        }
        #endregion

        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return GetListWhere();
        }
        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetListWhereAsync();
        }


        /// <summary>
        /// 根据查询条件获取数据集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetListWhere(string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sql = $"select {selectedFields} from { tableName} ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return Db.Ado.SqlQuery<T>(sql);
        }

        /// <summary>
        /// 根据查询条件获取数据集合
        /// SQL语句
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListWhereAsync(string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sql = $"select {selectedFields}  from { tableName} ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return await Db.Ado.SqlQueryAsync<T>(sql);
        }

        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// SQL语句，仅支持SqlServer和Mysql
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual  IEnumerable<T> GetListTopWhere(int top, string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }

            return Db.Queryable<T>().Take(top).WhereIF(!string.IsNullOrEmpty(where), where).ToList();
        }


        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListTopWhereAsync(int top, string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }

            return await Db.Queryable<T>().Take(top).WhereIF(!string.IsNullOrEmpty(where), where).ToListAsync();
        }
        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsDeleteMark(string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " DeleteMark=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return GetListWhere(sqlWhere);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteMark(string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " DeleteMark=0 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return GetListWhere(sqlWhere);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsEnabledMark(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " EnabledMark=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return GetListWhere(sqlWhere);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotEnabledMark(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " EnabledMark=0 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return GetListWhere(sqlWhere);
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteAndEnabledMark(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " DeleteMark=0 and EnabledMark=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return GetListWhere(sqlWhere);
        }

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsDeleteMarkAsync(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " DeleteMark=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return await GetListWhereAsync(sqlWhere);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteMarkAsync(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }

            string sqlWhere = " DeleteMark=0 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return await GetListWhereAsync(sqlWhere);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsEnabledMarkAsync(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }

            string sqlWhere = " EnabledMark=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return await GetListWhereAsync(sqlWhere);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotEnabledMarkAsync(string where = null)
        {

            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " EnabledMark=0";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return await GetListWhereAsync(sqlWhere);
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sqlWhere = " DeleteMark=0 and EnabledMark=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sqlWhere += " and " + where;
            }
            return await GetListWhereAsync(sqlWhere);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info)
        {
            return FindWithPager(condition, info, this.SortField, this.isDescending);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort)
        {
            return FindWithPager(condition, info, fieldToSort, this.isDescending);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort)
        {
            return await FindWithPagerAsync(condition, info, fieldToSort, this.isDescending);
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info)
        {
            return await FindWithPagerAsync(condition, info, this.SortField);
        }
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段，如name asc,age desc</param>
        /// <param name="desc">排序方式 true为desc，false为asc</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort, bool desc)
        {
            List<T> list = new List<T>();

            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            if (desc)
            {
                fieldToSort += " desc";
            }

            int totalCount = 0;
            list= Db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(fieldToSort), fieldToSort).WhereIF(!string.IsNullOrEmpty(condition), condition).ToPageList(info.CurrenetPageIndex, info.PageSize,ref totalCount);
            info.RecordCount = totalCount;
            return list;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">排序方式 true为desc，false为asc</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort, bool desc)
        {

            List<T> list = new List<T>();

            string t = typeof(T).Name;
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            if (desc)
            {
                fieldToSort += " desc";
            }
            RefAsync<int> totalCount = 0;
            list = await Db.Queryable<T>().OrderByIF(!string.IsNullOrEmpty(fieldToSort), fieldToSort).WhereIF(!string.IsNullOrEmpty(condition), condition).ToPageListAsync(info.CurrenetPageIndex, info.PageSize, totalCount);
            info.RecordCount = totalCount;
            return list;
        }

        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="fieldName">统计字段名称</param>
        /// <returns></returns>
        public virtual int GetCountByWhere(string condition, string fieldName = "*")
        {
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            string sql = $"select count({fieldName}) from {tableName}  where ";
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql = sql + condition;
            }
            return Db.Ado.GetInt(sql);
        }

        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="fieldName">统计字段名称</param>
        /// <returns></returns>
        public virtual async Task<int> GetCountByWhereAsync(string condition, string fieldName = "*")
        {
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            string sql = $"select count({fieldName}) from {tableName}  where ";
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql = sql + condition;
            }
            return await Db.Ado.GetIntAsync(sql);
        }

        /// <summary>
        /// 根据条件查询获取某个字段的最大值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <returns>返回字段的最大值</returns>
        public virtual async Task<decimal> GetMaxValueByFieldAsync(string strField, string where)
        {
            return await Db.Queryable<T>().WhereIF(!string.IsNullOrEmpty(where),where).MaxAsync<decimal>(strField);
        }
        /// <summary>
        /// 根据条件统计某个字段之和,sum(字段)
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <returns>返回字段求和后的值</returns>
        public virtual async Task<decimal> GetSumValueByFieldAsync(string strField, string where)
        {
            return await Db.Queryable<T>().WhereIF(!string.IsNullOrEmpty(where), where).SumAsync<decimal>(strField);
        }
        #endregion

        #region 新增、修改和删除

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert(T entity)
        {
            return Db.Insertable(entity).ExecuteCommand();
        }


        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> InsertAsync(T entity)
        {
            return await Db.Insertable(entity).ExecuteCommandAsync();
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async void Insert(List<T> entities)
        {
            if (entities.Count <= 500)
            {
                await  Db.Insertable(entities).UseParameter().ExecuteCommandAsync();
            }
            else
            {
                await Db.Fastest<T>().BulkCopyAsync(entities);
            }
        }

        /// <summary>
        /// 新增或更新
        /// </summary>
        /// <param name="entities">数据集合</param>
        /// <param name="insertNum">返回新增数量</param>
        /// <param name="updateNum">返回更新数量</param>
        public virtual  void InsertOrUpdate(List<T> entities, out int insertNum, out int updateNum)
        {
            var x = Db.Storageable(entities).ToStorage(); //将数据进行分组 
            insertNum=  x.AsInsertable.ExecuteCommand(); //执行插入 （可以换成雪花ID和自增）
            updateNum=  x.AsUpdateable.ExecuteCommand(); //执行更新　
        }
        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(T entity)
        {
            return Db.Updateable<T>(entity).ExecuteCommandHasChange();
        }

        /// <summary>
        /// 异步更新实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public virtual Task<bool> UpdateAsync(T entity)
        {
            return Db.Updateable<T>(entity).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere">条件</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(T entity, string strWhere)
        {
            return Db.Updateable<T>(entity).Where(strWhere).ExecuteCommandHasChange();
        }
        /// <summary>
        /// 按条件更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="strWhere">条件</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateAsync(T entity, string strWhere)
        {
            return await Db.Updateable<T>(entity).Where(strWhere).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="lstColumns"></param>
        /// <param name="lstIgnoreColumns"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public async Task<bool> Update(T entity, List<string> lstColumns = null, List<string> lstIgnoreColumns = null, string strWhere = "")
        {
            IUpdateable<T> up = Db.Updateable(entity);
            if (lstIgnoreColumns != null && lstIgnoreColumns.Count > 0)
            {
                up = up.IgnoreColumns(lstIgnoreColumns.ToArray());
            }
            if (lstColumns != null && lstColumns.Count > 0)
            {
                up = up.UpdateColumns(lstColumns.ToArray());
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                up = up.Where(strWhere);
            }
            return await up.ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {

            return Db.Deleteable<T>().ExecuteCommandHasChange();
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(T entity)
        {
            return await Db.Deleteable<T>().ExecuteCommandHasChangeAsync();
        }

        /// <summary>
        /// 物理删除信息
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete(object primaryKey)
        {
            return  Db.Deleteable<T>(primaryKey).ExecuteCommandHasChange();
        }
        /// <summary>
        /// 异步物理删除信息
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteAsync(object primaryKey)
        {
            return await Db.Deleteable<T>(primaryKey).ExecuteCommandHasChangeAsync();
           
        }

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids">主键Id List集合</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteBatch(IList<dynamic> ids)
        {
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where PrimaryKey in (@PrimaryKey)";
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = ids });

            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }
        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteBatchWhere(string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where " + where;
            Tuple<string, object> tupel = new Tuple<string, object>(sql, null);

            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }
        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteBatchWhereAsync(string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            return await Db.Deleteable<T>().Where(where).ExecuteCommandHasChangeAsync();
        }


        /// <summary>
        /// 逻辑删除信息，bl为true时将DeleteMark设置为1删除，bl为flase时将DeleteMark设置为10-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteSoft(bool bl, object primaryKey, long userId)
        {
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "DeleteMark=0 ";
            }
            else
            {
                sql += "DeleteMark=1 ";
            }
            sql += ",DeleteUserId=" + userId;
            DateTime deleteTime = DateTime.Now;
            sql += ",DeleteTime=@DeleteTime where " + PrimaryKey + "=@PrimaryKey";
            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey, @DeleteTime = deleteTime });
            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }

        /// <summary>
        /// 异步逻辑删除信息，bl为true时将DeleteMark设置为1删除，bl为flase时将DeleteMark设置为0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteSoftAsync(bool bl, object primaryKey, long userId)
        {
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "DeleteMark=0 ";
            }
            else
            {
                sql += "DeleteMark=1 ";
            }
            sql += ",DeleteUserId=" + userId;
            DateTime deleteTime = DateTime.Now;
            sql += ",DeleteTime=@DeleteTime where " + PrimaryKey + "=@PrimaryKey";
            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey, @DeleteTime = deleteTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        /// <summary>
        /// 异步批量软删除信息，将DeleteMark设置为1-删除，0-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param> c
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteSoftBatchAsync(bool bl, string where, long userId)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "DeleteMark=0 ";
            }
            else
            {
                sql += "DeleteMark=1 ";
            }
            sql += ",DeleteUserId=" + userId;
            DateTime deleteTime = DateTime.Now;
            sql += ",DeleteTime=@DeleteTime where " + where;

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @DeleteTime = deleteTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }
        /// <summary>
        /// 设置数据有效性，将EnabledMark设置为1-有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool SetEnabledMark(bool bl, object primaryKey, long userId)
        {
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "EnabledMark=1 ";
            }
            else
            {
                sql += "EnabledMark=0 ";
            }
                sql += ",LastModifyUserId=" + userId;
            DateTime lastModifyTime = DateTime.Now;
            sql += ",LastModifyTime=@lastModifyTime where " + PrimaryKey + "=@PrimaryKey";

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey, @lastModifyTime = lastModifyTime });
            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }

        /// <summary>
        /// 异步设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> SetEnabledMarkAsync(bool bl, object primaryKey, long userId)
        {
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "EnabledMark=1 ";
            }
            else
            {
                sql += "EnabledMark=0 ";
            }
                sql += ",LastModifyUserId=" + userId;
            DateTime lastModifyTime = DateTime.Now;
            sql += ",LastModifyTime=@LastModifyTime where " + PrimaryKey + "=@PrimaryKey";

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = PrimaryKey, @LastModifyTime = lastModifyTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        /// <summary>
        /// 异步按条件设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="where">条件</param>
        /// <param name="userId">操作用户</param>
        /// <returns></returns>
        public virtual async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, long userId)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "EnabledMark=1 ";
            }
            else
            {
                sql += "EnabledMark=0 ";
            }
                sql += ",LastModifyUserId=" + userId;
            DateTime lastModifyTime = DateTime.Now;
            sql += ",LastModifyTime=@LastModifyTime where " + where;

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { LastModifyTime = lastModifyTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }
        /// <summary>
        /// 异步按条件设置数据有效性，将EnabledMark设置为1:有效，0-为无效
        /// </summary>
        /// <param name="bl">true为有效，false无效</param>
        /// <param name="where">条件</param>
        /// <param name="userId"></param>
        /// <param name="paramparameters"></param>
        /// <returns></returns>
        public virtual async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, long userId, object paramparameters = null)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set ";
            if (bl)
            {
                sql += "EnabledMark=1 ";
            }
            else
            {
                sql += "EnabledMark=0 ";
            }
            sql += ",LastModifyUserId=" + userId;
            DateTime lastModifyTime = DateTime.Now;
            sql += ",LastModifyTime=@LastModifyTime  " + where;

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { LastModifyTime = lastModifyTime, paramparameters });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }
        /// <summary>
        /// 更新某一字段值,字段值字符类型
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值字符类型</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool UpdateTableField(string strField, string fieldValue, string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set " + strField + "='" + fieldValue + "'";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, null);
            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }

        /// <summary>
        /// 更新某一字段值,字段值字符类型
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值字符类型</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateTableFieldAsync(string strField, string fieldValue, string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set " + strField + "='" + fieldValue + "'";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, null);
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }
        /// <summary>
        /// 更新某一字段值，字段值为数字
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值数字</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool UpdateTableField(string strField, int fieldValue, string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set " + strField + "=" + fieldValue + "";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, null);
            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }


        /// <summary>
        /// 更新某一字段值，字段值为数字
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="fieldValue">字段值数字</param>
        /// <param name="where">条件,为空更新所有内容</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateTableFieldAsync(string strField, int fieldValue, string where)
        {
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"update {tableName} set " + strField + "=" + fieldValue + "";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, null);
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        /// <summary>
        /// 多表多数据操作批量插入、更新、删除--事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        public async Task<Tuple<bool, string>> ExecuteTransactionAsync(List<Tuple<string, object>> trans, int? commandTimeout = null)
        {
            if (!trans.Any()) return new Tuple<bool, string>(false, "执行事务SQL语句不能为空！");
            _unitOfWork.BeginTran();
            try
            {
                foreach (var tran in trans)
                {
                    await Db.Ado.ExecuteCommandAsync(tran.Item1, tran.Item2);
                }
                //提交事务
                _unitOfWork.CommitTran();
                return new Tuple<bool, string>(true, string.Empty);
            }
            catch (Exception ex)
            {
                //回滚事务
                Log4NetHelper.Error("", ex);
                _unitOfWork.RollbackTran();
                throw;
            }
        }


        /// <summary>
        /// 多表多数据操作批量插入、更新、删除--事务
        /// </summary>
        /// <param name="trans">事务</param>
        /// <param name="commandTimeout">超时</param>
        /// <returns></returns>
        public Tuple<bool, string> ExecuteTransaction(List<Tuple<string, object>> trans, int? commandTimeout = null)
        {
            if (!trans.Any()) return new Tuple<bool, string>(false, "执行事务SQL语句不能为空！");
            _unitOfWork.BeginTran();
            try
            {
                foreach (var tran in trans)
                {
                    Db.Ado.ExecuteCommand(tran.Item1, tran.Item2);
                }
                //提交事务
                _unitOfWork.CommitTran();
                return new Tuple<bool, string>(true, string.Empty);
            }
            catch (Exception ex)
            {
                //回滚事务
                Log4NetHelper.Error("ExecuteTransaction", ex);
                _unitOfWork.RollbackTran();
                return new Tuple<bool, string>(false, ex.ToString());
            }
        }
        #endregion

        #endregion

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
        private static string GetRegexString()
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
            str_Regex += strBadChar[^1] + ").*";

            return str_Regex;
        }


        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用
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

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion
        #endregion
    }
}
