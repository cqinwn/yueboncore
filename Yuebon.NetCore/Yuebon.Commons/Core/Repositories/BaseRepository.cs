using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Dapper;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using static Dapper.SqlMapper;

namespace Yuebon.Commons.Repositories
{
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    public abstract class BaseRepository<T, TKey> : IRepository<T, TKey> 
        where T :Entity
    {
        #region 构造函数及基本配置
        /// <summary>
        ///  EF DBContext
        /// </summary>
        private IDbContextCore _dbContext;
        /// <summary>
        /// 
        /// </summary>
        protected DbSet<T> DbSet => DbContext.GetDbSet<T>();
        /// <summary>
        /// 
        /// </summary>
        protected string dbConfigName=typeof(T).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName?? Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
        /// <summary>
        /// 需要初始化的对象表名
        /// </summary>
        protected string tableName= typeof(T).GetCustomAttribute<TableAttribute>(false)?.Name;
        /// <summary>
        /// 数据库参数化访问的占位符
        /// </summary>
        protected string parameterPrefix = "@";
        /// <summary>
        /// 防止和保留字、关键字同名的字段格式，如[value]
        /// </summary>
        protected string safeFieldFormat = "[{0}]";
        /// <summary>
        /// 数据库的主键字段名,若主键不是Id请重载BaseRepository设置
        /// </summary>
        protected string primaryKey="Id";
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
        /// 是否开启多租户
        /// </summary>
        protected bool isMultiTenant = false;


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
        /// 构造方法
        /// </summary>
        public BaseRepository()
        {
        }

        /// <summary>
        /// 构造方法，指定上下文
        /// </summary>
        /// <param name="dbContext">上下文</param>
        public BaseRepository(IDbContextCore dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext;
            _dbContext.EnsureCreated();
        }
        /// <summary>
        /// 
        /// </summary>
        private IDbContextCore EFContext
        {
            get
            {
                DBServerProvider.GetDbContextConnection<T>(DbContext);
                return DbContext;
            }
        }
        /// <summary>
        /// EF 上下文接口
        /// </summary>
        public virtual IDbContextCore DbContext
        {
            get { return _dbContext; }
        }

        /// <summary>
        /// 用Dapper原生方法操作数据
        /// </summary>
        public IDbConnection DapperConn
        {
            get { return new DapperDbContext().GetConnection<T>(); }
        }
        #endregion

        #region Dapper 操作
        #region 查询获得对象和列表
        /// <summary>
        /// 根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public virtual T Get(TKey primaryKey)
        {
            //return DapperConn.Get<T>(primaryKey);
            return DbContext.Find<T,TKey>(primaryKey);
        }
        /// <summary>
        /// 异步根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <returns></returns>
        public virtual async  Task<T> GetAsync(TKey primaryKey)
        {
            //return await DapperConn.GetAsync<T>(primaryKey);
            return DbContext.Find<T>(primaryKey);
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
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            // return DbContext.GetDbSet<T>().FromSqlRaw<T>(sql).FirstOrDefault<T>();

            return DapperConn.QueryFirstOrDefault<T>(sql);

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
            string  sql = $"select * from { tableName} ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where "+where;
            }
            return await DbContext.GetDbSet<T>().FromSqlRaw<T>(sql).FirstOrDefaultAsync<T>();
        }

        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(IDbTransaction trans=null)
        {
            return GetListWhere();
        }
        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync( IDbTransaction trans=null)
        {
            return await GetListWhereAsync();
        }


        /// <summary>
        /// 根据查询条件获取数据集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetListWhere(string where = null, IDbTransaction trans=null)
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
            return DapperConn.Query<T>(sql, trans);
        }

        /// <summary>
        /// 根据查询条件获取数据集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListWhereAsync(string where = null, IDbTransaction trans=null)
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
            return await DapperConn.QueryAsync<T>(sql, trans);
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
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sql = $"select top {top} {selectedFields} from " + tableName;
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return DapperConn.Query<T>(sql, trans);
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
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            string sql = $"select top {top} {selectedFields}  from " + tableName;
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return await DapperConn.QueryAsync<T>(sql, trans);
        }
        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsDeleteMark(string where = null, IDbTransaction trans = null)
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
            return GetListWhere(sqlWhere,trans);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteMark(string where = null, IDbTransaction trans=null)
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
            return GetListWhere(sqlWhere, trans);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsEnabledMark(string where = null, IDbTransaction trans=null)
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
            return GetListWhere(sqlWhere, trans);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotEnabledMark(string where = null, IDbTransaction trans = null)
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
            return GetListWhere(sqlWhere, trans);
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteAndEnabledMark(string where = null, IDbTransaction trans = null)
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
            return GetListWhere(sqlWhere, trans);
        }

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsDeleteMarkAsync(string where = null, IDbTransaction trans = null)
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
            return await GetListWhereAsync(sqlWhere, trans);
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteMarkAsync(string where = null, IDbTransaction trans = null)
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
            return await GetListWhereAsync(sqlWhere, trans);
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsEnabledMarkAsync(string where = null, IDbTransaction trans = null)
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
            return await GetListWhereAsync(sqlWhere, trans);
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotEnabledMarkAsync(string where = null, IDbTransaction trans = null)
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
            return await GetListWhereAsync(sqlWhere, trans);
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null, IDbTransaction trans=null)
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
            return await GetListWhereAsync(sqlWhere, trans);
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
           return FindWithPager(condition, info, this.SortField, this.isDescending, trans);
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
            return FindWithPager(condition, info, fieldToSort, this.isDescending, trans);
        }
        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">排序方式 true为desc，false为asc</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual List<T> FindWithPager(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
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
            PagerHelper pagerHelper = new PagerHelper(this.tableName, this.selectedFields, fieldToSort, info.PageSize, info.CurrenetPageIndex, desc, condition);

            string pageSql = pagerHelper.GetPagingSql(true, this.dbConfigName);
            pageSql += ";" + pagerHelper.GetPagingSql(false, this.dbConfigName);

            var reader = DapperConn.QueryMultiple(pageSql);
            info.RecordCount = reader.ReadFirst<int>();
            list = reader.Read<T>().AsList();
            return list;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="condition">查询的条件</param>
        /// <param name="info">分页实体</param>
        /// <param name="fieldToSort">排序字段</param>
        /// <param name="desc">排序方式 true为desc，false为asc</param>
        /// <param name="trans">事务对象</param>
        /// <returns>指定对象的集合</returns>
        public virtual async Task<List<T>> FindWithPagerAsync(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
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

            PagerHelper pagerHelper = new PagerHelper(this.tableName, this.selectedFields, fieldToSort, info.PageSize, info.CurrenetPageIndex, desc, condition);

            string pageSql = pagerHelper.GetPagingSql(true, this.dbConfigName);
            pageSql += ";" + pagerHelper.GetPagingSql(false, this.dbConfigName);

            var reader = await DapperConn.QueryMultipleAsync(pageSql);
            info.RecordCount = reader.ReadFirst<int>();
            list = reader.Read<T>().AsList();
            return list;
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
            return await FindWithPagerAsync(condition, info, fieldToSort, this.isDescending, trans);
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
            return await FindWithPagerAsync(condition, info, this.SortField, trans);
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
            StringBuilder sb = new StringBuilder();
            int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
            int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
            string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
            sb.AppendFormat("SELECT count(*) as RecordCount FROM (select {0} FROM {1} where {2})  AS main_temp;", primaryKey, tableName, condition);
            sb.AppendFormat("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by {0}) AS rows ,{1} FROM {2} where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);
            var reader = DapperConn.QueryMultiple(sb.ToString());
            info.RecordCount = reader.ReadFirst<int>();
            list = reader.Read<T>().AsList();
            return list;
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
        public virtual async Task<List<T>> FindWithPagerSqlAsync(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
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
            StringBuilder sb = new StringBuilder();
            int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
            int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
            string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
            sb.AppendFormat("SELECT count(*) as RecordCount FROM (select {0} FROM {1} where {2})  AS main_temp;", primaryKey, tableName, condition);
            sb.AppendFormat("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by {0}) AS rows ,{1} FROM {2} where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);
            var reader = await DapperConn.QueryMultipleAsync(sb.ToString());
            info.RecordCount = reader.ReadFirst<int>();
            List<T> list  = reader.Read<T>().AsList();
            return list;
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
        public virtual List<object> FindWithPagerRelationUser(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
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
            StringBuilder sb = new StringBuilder();
            int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
            int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
            string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
            sb.AppendFormat("SELECT count(*) as RecordCount FROM (select t1.{0} FROM {1} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id where {2})  AS main_temp;", primaryKey, tableName, condition);
            sb.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER (order by  {0}) AS rows ,t1.{1},t2.Account as Account,t2.NickName as NickName,t2.RealName as RealName,t2.HeadIcon as HeadIcon ,t2.MobilePhone as MobilePhone  FROM {2} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id " +
                "where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);

            var reader = DapperConn.QueryMultiple(sb.ToString());
            info.RecordCount = reader.ReadFirst<int>();
            List<object> list = reader.Read<object>().AsList();
            return list;
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
        public virtual async Task<List<object>> FindWithPagerRelationUserAsync(string condition, PagerInfo info, string fieldToSort, bool desc, IDbTransaction trans = null)
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
            StringBuilder sb = new StringBuilder();
            int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
            int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
            string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
            sb.AppendFormat("SELECT count(*) as RecordCount FROM (select t1.{0} FROM {1} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id where {2})  AS main_temp;", primaryKey, tableName, condition);
            sb.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER (order by  {0}) AS rows ,t1.{1},t2.Account as Account,t2.NickName as NickName,t2.RealName as RealName,t2.HeadIcon as HeadIcon ,t2.MobilePhone as MobilePhone  FROM {2} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id " +
                "where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);

            var reader = await DapperConn.QueryMultipleAsync(sb.ToString());
            info.RecordCount = reader.ReadFirst<int>();
            List<object> list = reader.Read<object>().AsList();
            return list;
        }
        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual int GetCountByWhere(string condition)
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
            string sql = $"select count(*) from {tableName}  where ";
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql = sql + condition;
            }
            return DapperConn.Query<int>(sql).FirstOrDefault();
        }

        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual async Task<int> GetCountByWhereAsync(string condition)
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
            string sql = $"select count(*) from {tableName}  where ";
            if (!string.IsNullOrWhiteSpace(condition))
            {
                sql = sql + condition;
            }
            return await DapperConn.QueryFirstAsync<int>(sql);
        }

        /// <summary>
        /// 根据条件查询获取某个字段的最大值
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <param name="trans">事务</param>
        /// <returns>返回字段的最大值</returns>
        public virtual async Task<int> GetMaxValueByFieldAsync(string strField, string where, IDbTransaction trans = null)
        {
            string sql = $"select isnull(MAX({strField}),0) as maxVaule from {tableName} ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }

            return await DapperConn.QueryFirstAsync<int>(sql);
        }
        /// <summary>
        /// 根据条件统计某个字段之和,sum(字段)
        /// </summary>
        /// <param name="strField">字段</param>
        /// <param name="where">条件</param>
        /// <param name="trans">事务</param>
        /// <returns>返回字段的最大值</returns>
        public virtual async Task<int> GetSumValueByFieldAsync(string strField, string where, IDbTransaction trans = null)
        {
            string sql = $"select isnull(sum({strField}),0) as sumVaule from {tableName} ";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            return await DapperConn.QueryFirstAsync<int>(sql);
        }
        #endregion
        #region 新增、修改和删除

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual long Insert(T entity, IDbTransaction trans=null)
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            return DapperConn.Insert<T>(entity);
        }


        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<long> InsertAsync(T entity, IDbTransaction trans=null)
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            return await DapperConn.InsertAsync<T>(entity);
        }
        
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual void Insert(List<T> entities)
        {
            DbContext.BulkInsert<T>(entities);
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(T entity, TKey primaryKey, IDbTransaction trans=null)
        {
           return DbContext.Update<T>(entity)>0;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(T entity, IDbTransaction trans = null)
        {
            return DbContext.Update(entity)>0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="primaryKey"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateAsync(T entity, TKey primaryKey, IDbTransaction trans=null)
        {
          return DbContext.Update(entity)>0;
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(List<T> entities, IDbTransaction trans=null)
        {
            return DbContext.EditRange<T>(entities)>0;
        }
        /// <summary>
        /// 异步批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateAsync(List<T> entities,IDbTransaction trans=null)
        {
            return DbContext.EditRange<T>(entities) > 0;
        }

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public virtual bool Delete(T entity)
        {
            DbContext.GetDbSet<T>().Remove(entity);
            return DbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(T entity, IDbTransaction trans = null)
        {
            DbContext.GetDbSet<T>().Remove(entity);
            return await DbContext.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 物理删除信息
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete(TKey primaryKey, IDbTransaction trans=null)
        {
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where " + PrimaryKey + "=@PrimaryKey";
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey });

            param.Add(tupel);
            Tuple<bool, string> result= ExecuteTransaction(param);
            return result.Item1;
        }
        /// <summary>
        /// 异步物理删除信息
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteAsync(TKey primaryKey, IDbTransaction trans=null)
        {
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where " + PrimaryKey + "=@PrimaryKey" ;
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey });
            param.Add(tupel);
            Tuple<bool, string> result =await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        /// <summary>
        /// 按主键批量删除
        /// </summary>
        /// <param name="ids">主键Id List集合</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public  virtual bool DeleteBatch(IList<dynamic> ids, IDbTransaction trans = null)
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteBatchWhere(string where, IDbTransaction trans = null)
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual  async Task<bool> DeleteBatchWhereAsync(string where, IDbTransaction trans = null)
        {
            if(HasInjectionData(where))
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
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        /// <summary>
        /// 根据指定对象的ID和用户ID,从数据库中删除指定对象(用于记录人员的操作日志）
        /// </summary>
        /// <param name="primaryKey">指定对象的ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteByUser(TKey primaryKey, string userId, IDbTransaction trans=null)
        {
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where " + PrimaryKey + " = @PrimaryKey";
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey });
            param.Add(tupel);
            Tuple<bool, string> result = ExecuteTransaction(param);
            return result.Item1;
        }
        /// <summary>
        /// 异步根据指定对象的ID和用户ID,从数据库中删除指定对象(用于记录人员的操作日志）
        /// </summary>
        /// <param name="primaryKey">指定对象的ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteByUserAsync(TKey primaryKey, string userId, IDbTransaction trans=null)
        {
            var param = new List<Tuple<string, object>>();
            string sql = $"delete from {tableName} where " + PrimaryKey + " = @PrimaryKey";
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        /// <summary>
        /// 逻辑删除信息，bl为true时将DeleteMark设置为1删除，bl为flase时将DeleteMark设置为10-恢复删除
        /// </summary>
        /// <param name="bl">true为不删除，false删除</param>
        /// <param name="primaryKey">主键ID</param>
        /// <param name="userId">操作用户</param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteSoft(bool bl, TKey primaryKey, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",DeleteUserId='" + userId + "'";
            }
            DateTime deleteTime = DateTime.Now;
            sql += ",DeleteTime=@DeleteTime where " + PrimaryKey + "=@PrimaryKey" ;
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteSoftAsync(bool bl, TKey primaryKey, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",DeleteUserId='" + userId + "'";
            }
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
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteSoftBatchAsync(bool bl, string where, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",DeleteUserId='" + userId + "'";
            }
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool SetEnabledMark(bool bl, TKey primaryKey, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",LastModifyUserId='" + userId + "'";
            }
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> SetEnabledMarkAsync(bool bl, TKey primaryKey, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",LastModifyUserId='" + userId + "'";
            }
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
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",LastModifyUserId='" + userId + "'";
            }
            DateTime lastModifyTime = DateTime.Now;
            sql += ",LastModifyTime=@LastModifyTime where " + where;

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { LastModifyTime = lastModifyTime });
            param.Add(tupel);
            Tuple<bool, string> result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }

        public virtual async Task<bool> SetEnabledMarkByWhereAsync(bool bl, string where, object paramparameters = null, string userId = null, IDbTransaction trans = null)
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
            if (!string.IsNullOrEmpty(userId))
            {
                sql += ",LastModifyUserId='" + userId + "'";
            }
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool UpdateTableField(string strField, string fieldValue, string where, IDbTransaction trans = null)
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateTableFieldAsync(string strField, string fieldValue, string where, IDbTransaction trans = null)
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool UpdateTableField(string strField, int fieldValue, string where, IDbTransaction trans = null)
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
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateTableFieldAsync(string strField, int fieldValue, string where, IDbTransaction trans = null)
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
            using (IDbConnection connection = DapperConn)
            {
                bool isClosed = connection.State == ConnectionState.Closed;
                if (isClosed) connection.Open();
                using (var transaction =  connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var tran in trans)
                        {
                            await connection.ExecuteAsync(tran.Item1, tran.Item2, transaction, commandTimeout);
                        }
                        //提交事务
                        transaction.Commit();
                        return new Tuple<bool, string>(true, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        Log4NetHelper.Error("", ex);
                        transaction.Rollback();
                        connection.Close();
                        connection.Dispose();
                        DapperConn.Close();
                        DapperConn.Dispose();
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        DapperConn.Close();
                        DapperConn.Dispose();
                    }
                }
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
            using (IDbConnection connection = DapperConn)
            {
                bool isClosed = connection.State == ConnectionState.Closed;
                if (isClosed) connection.Open();
                //开启事务
                using (var transaction = DapperConn.BeginTransaction())
                {
                    try
                    {
                        foreach (var tran in trans)
                        {
                            DapperConn.Execute(tran.Item1, tran.Item2, transaction, commandTimeout);
                        }
                        //提交事务
                        transaction.Commit();
                        return new Tuple<bool, string>(true, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        Log4NetHelper.Error("", ex);
                        transaction.Rollback();
                        connection.Close();
                        connection.Dispose();
                        DapperConn.Close();
                        DapperConn.Dispose();
                        throw ex;
                        //return new Tuple<bool, string>(false, ex.ToString());
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                        DapperConn.Close();
                        DapperConn.Dispose();
                    }
                }
            }
        }

        IDbTransaction dbTransaction = null;
        private T Execute<T>(Func<IDbConnection, IDbTransaction, T> func, bool beginTransaction = false, bool disposeConn = true)
        {
            if (beginTransaction)
            {
                if(DapperConn.State!=ConnectionState.Open)
                DapperConn.Open();
                dbTransaction = DapperConn.BeginTransaction();
            }
            using (IDbConnection connection = DapperConn)
            {
                try
                {
                    T reslutT = func(connection, dbTransaction);
                    if (dbTransaction != null)
                    {
                        dbTransaction.Commit();
                    }
                    return reslutT;
                }
                catch (Exception ex)
                {
                    Log4NetHelper.Error("", ex);
                    if (dbTransaction != null)
                    {
                        DapperConn.Close();
                        DapperConn.Dispose();
                        connection.Dispose();
                        dbTransaction.Rollback();
                    }
                    throw ex;
                }
                finally
                {
                    if (disposeConn)
                    {
                        DapperConn.Close();
                        DapperConn.Dispose();
                        connection.Dispose();
                    }
                    dbTransaction?.Dispose();
                }
            }
        }

        #endregion
        #endregion

        #region EF操作

        #region 新增
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Add(T entity)
        {
            return DbContext.Add<T>(entity);
        }
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<int> AddAsync(T entity)
        {
            return await DbContext.AddAsync(entity);
        }
        /// <summary>
        /// 批量新增实体，数量量较多是推荐使用BulkInsert()
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int AddRange(ICollection<T> entities)
        {
            return DbContext.AddRange(entities);
        }
        /// <summary>
        /// 批量新增实体，数量量较多是推荐使用BulkInsert()
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task<int> AddRangeAsync(ICollection<T> entities)
        {
            return await DbContext.AddRangeAsync(entities);
        }
        /// <summary>
        /// 批量新增SqlBulk方式，效率最高
        /// </summary>
        /// <param name="entities">数据实体集合</param>
        /// <param name="destinationTableName">数据库表名称，默认为实体名称</param>
        public virtual void BulkInsert(IList<T> entities, string destinationTableName = null)
        {
            DbContext.BulkInsert<T>(entities, destinationTableName);
        }
        /// <summary>
        /// 执行新增的sql语句
        /// </summary>
        /// <param name="sql">新增Sql语句</param>
        /// <returns></returns>
        public int AddBySql(string sql)
        {
            return DbContext.ExecuteSqlWithNonQuery(sql);
        }

        #endregion

        #region Update

        /// <summary>
        /// 更新数据实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Edit(T entity)
        {
            return DbContext.Edit<T>(entity);
        }
        /// <summary>
        /// 批量更新数据实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int EditRange(ICollection<T> entities)
        {
            return DbContext.EditRange(entities);
        }
        /// <summary>
        /// 更新指定字段的值
        /// </summary>
        /// <param name="model">数据实体</param>
        /// <param name="updateColumns">指定字段</param>
        /// <returns></returns>
        public virtual int Update(T model, params string[] updateColumns)
        {
            DbContext.Update(model, updateColumns);
            return DbContext.SaveChanges();
        }
        /// <summary>
        /// 执行更新数据的Sql语句
        /// </summary>
        /// <param name="sql">更新数据的Sql语句</param>
        /// <returns></returns>
        public int UpdateBySql(string sql)
        {
            return DbContext.ExecuteSqlWithNonQuery(sql);
        }
        #endregion

        #region Delete

        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual int Delete(TKey key)
        {
            return DbContext.Delete<T, TKey>(key);
        }
        /// <summary>
        /// 执行删除数据Sql语句
        /// </summary>
        /// <param name="sql">删除的Sql语句</param>
        /// <returns></returns>
        public int DeleteBySql(string sql)
        {
            return DbContext.ExecuteSqlWithNonQuery(sql);
        }

        #endregion

        #region Query
        /// <summary>
        /// 根据条件统计数量Count()
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<T, bool>> @where = null)
        {
            return DbContext.Count(where);
        }

        /// <summary>
        /// 根据条件统计数量Count()
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> @where = null)
        {
            return await DbContext.CountAsync(where);
        }
        /// <summary>
        /// 是否存在,存在返回true，不存在返回false
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>

        public virtual bool Exist(Expression<Func<T, bool>> @where = null)
        {
            return DbContext.Exist(where);
        }
        /// <summary>
        /// 是否存在,存在返回true，不存在返回false
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<bool> ExistAsync(Expression<Func<T, bool>> @where = null)
        {
            return await DbContext.ExistAsync(where);
        }

        /// <summary>
        /// 根据主键获取实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual T GetSingle(TKey key)
        {
            return DbContext.Find<T, TKey>(key);
        }


        /// <summary>
        /// 根据主键获取实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual async Task<T> GetSingleAsync(TKey key)
        {
            return await DbContext.FindAsync<T, TKey>(key);
        }

        /// <summary>
        /// 获取单个实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual T GetSingleOrDefault(Expression<Func<T, bool>> @where = null)
        {
            return DbContext.GetSingleOrDefault(@where);
        }

        /// <summary>
        /// 获取单个实体。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> @where = null)
        {
            return await DbContext.GetSingleOrDefaultAsync(where);
        }

        /// <summary>
        /// 获取实体列表。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IList<T> Get(Expression<Func<T, bool>> @where = null)
        {
            return DbContext.GetByCompileQuery(where);
        }
        /// <summary>
        /// 获取实体列表。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>> @where = null)
        {
            return await DbContext.GetByCompileQueryAsync(where);
        }

        /// <summary>
        ///  分页获取实体列表。建议：如需使用Include和ThenInclude请重载此方法。
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="pagerInfo">分页信息</param>
        /// <param name="asc">排序方式</param>
        /// <param name="orderby">排序字段</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetByPagination(Expression<Func<T, bool>> @where, PagerInfo pagerInfo,  bool asc = false, params Expression<Func<T, object>>[] @orderby)
        {
            var filter = DbContext.Get(where);
            if (orderby != null)
            {
                foreach (var func in orderby)
                {
                    filter = asc ? filter.OrderBy(func).AsQueryable() : filter.OrderByDescending(func).AsQueryable();
                }
            }
            pagerInfo.RecordCount = filter.Count();
            return filter.Skip(pagerInfo.PageSize * (pagerInfo.CurrenetPageIndex - 1)).Take(pagerInfo.PageSize);
        }
        /// <summary>
        /// sql语句查询数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetBySql(string sql)
        {
            return DbContext.SqlQuery<T, T>(sql);
        }
        /// <summary>
        /// sql语句查询数据集，返回输出Dto实体
        /// </summary>
        /// <typeparam name="TView"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<TView> GetViews<TView>(string sql)
        {
            var list = DbContext.SqlQuery<T, TView>(sql);
            return list;
        }
        /// <summary>
        /// 查询视图
        /// </summary>
        /// <typeparam name="TView">返回结果对象</typeparam>
        /// <param name="viewName">视图名称</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public List<TView> GetViews<TView>(string viewName, Func<TView, bool> @where)
        {
            var list = DbContext.SqlQuery<T, TView>($"select * from {viewName}");
            if (where != null)
            {
                return list.Where(where).ToList();
            }

            return list;
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
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
            if (DapperConn != null)
            {
                DapperConn?.Dispose();
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~BaseRepository() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);

            DbContext?.Dispose();
            DapperConn?.Dispose();
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
