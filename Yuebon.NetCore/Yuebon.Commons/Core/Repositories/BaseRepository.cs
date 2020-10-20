using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IRepositories;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using static Dapper.SqlMapper;

namespace Yuebon.Commons.Repositories
{
    /// <summary>
    /// 定义一个记录操作日志的事件处理
    /// </summary>
    /// <param name="tableName">操作表名称</param>
    /// <param name="operationType">操作类型：增加、修改、删除、软删除</param>
    /// <param name="note">操作的详细记录信息</param>
    /// <returns></returns>
    public delegate bool OperationLogEventHandler(string tableName, string operationType, string note);
    /// <summary>
    /// 泛型仓储，实现泛型仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TKey">实体主键类型</typeparam>
    public abstract class BaseRepository<T, TKey> : IRepository<T, TKey> 
        where T : Entity
        where TKey : IEquatable<TKey>
    {
        #region 构造函数及基本配置
        /// <summary>
        /// 定义一个操作记录的事件处理
        /// </summary>
        public event OperationLogEventHandler OnOperationLog;
        public DbConnection dbConnection;
        /// <summary>
        /// 上下文
        /// </summary>
        protected BaseDbContext _dbContext;

        private DbSet<T> _dbSet;

        /// <summary>
        /// 数据库配置名称
        /// </summary>
        protected string dbConfigName = "";
        /// <summary>
        /// 需要初始化的对象表名
        /// </summary>
        protected string tableName;
        /// <summary>
        /// 数据库参数化访问的占位符
        /// </summary>
        protected string parameterPrefix = "@";
        /// <summary>
        /// 防止和保留字、关键字同名的字段格式，如[value]
        /// </summary>
        protected string safeFieldFormat = "[{0}]";
        /// <summary>
        /// 数据库的主键字段名
        /// </summary>
        protected string primaryKey;
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
        /// 是否开启多租户
        /// </summary>
        protected string tenantId = "";

        /// <summary>
        /// 租户Id
        /// </summary>
        public string TenantId
        {
            get { return tenantId; }
            set { tenantId = value; }
        }
        /// <summary>
        /// 数据库配置名称，默认为空。
        /// 可在子类指定不同的配置名称，用于访问不同的数据库
        /// </summary>
        public string DbConfigName
        {
            get { return dbConfigName; }
            set { dbConfigName = value; }
        }

        /// <summary>
        /// 数据库参数化访问的占位符
        /// </summary>
        public string ParameterPrefix
        {
            get { return parameterPrefix; }
            set { parameterPrefix = value; }
        }

        /// <summary>
        /// 防止和保留字、关键字同名的字段格式，如[value]。
        /// 不同数据库类型的BaseDAL需要进行修改
        /// </summary>
        public string SafeFieldFormat
        {
            get { return safeFieldFormat; }
            set { safeFieldFormat = value; }
        }

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
        /// 是否为降序
        /// </summary>
        public bool IsDescending
        {
            get { return isDescending; }
            set { isDescending = value; }
        }

        /// <summary>
        /// 选择的字段，默认为所有(*)
        /// </summary>
        public string SelectedFields
        {
            get { return selectedFields; }
            set { selectedFields = value; }
        }

        /// <summary>
        /// 数据库访问对象的表名
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
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
        /// 设置数据库配置项名称
        /// </summary>
        /// <param name="_dbConfigName">数据库配置项名称</param>
        public virtual void SetDbConfigName(string _dbConfigName)
        {
            dbConfigName = _dbConfigName;
        }

        /// <summary>
        /// 数据库访问对象的外键约束
        /// </summary>
        public bool IsMultiTenant
        {
            get
            {
                return isMultiTenant;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseRepository()
        {
        }

        /// <summary>
        /// 指定上下文
        /// </summary>
        /// <param name="dbContext">上下文</param>
        public BaseRepository(BaseDbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
            _dbSet = dbContext.Set<T>();
        }
        /// <summary>
        /// 指定数据库连接配置
        /// </summary>
        /// <param name="_dbConfigName">数据库连接配置名称</param>
        public BaseRepository(string _dbConfigName) : this()
        {
            SetDbConfigName(_dbConfigName);
        }
        /// <summary>
		/// 指定表名以及主键,对基类进构造
		/// </summary>
		/// <param name="_tableName">表名</param>
		/// <param name="_primaryKey">表主键</param>
        public BaseRepository(string _tableName, string _primaryKey) : this()
        {
            this.tableName = _tableName;
            this.primaryKey = _primaryKey;
        }
        /// <summary>
		/// 指定数据库连接配置、表名以及主键,对基类进构造
		/// </summary>
		/// <param name="_dbConfigName">数据库连接配置名称</param>
		/// <param name="_tableName">表名</param>
		/// <param name="_primaryKey">表主键</param>
        public BaseRepository(string _dbConfigName,string _tableName,string _primaryKey) : this()
        {
            SetDbConfigName(_dbConfigName);
            this.tableName = _tableName;
            this.primaryKey = _primaryKey;
        }


        /// <summary>
        /// 数据库连接,根据数据库类型自动识别，类型区分用配置名称是否包含主要关键字
        /// MSSQL、MYSQL、ORACLE、SQLITE、MEMORY、NPGSQL
        /// </summary>
        /// <returns></returns>
        public DbConnection OpenSharedConnection()
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            this.isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName= Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }
            // 数据库连接配置
            string defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
            if (IsMultiTenant)
            {
                defaultSqlConnectionString= Configs.GetConnectionString(dbConfigName);
            }
            if (conStringEncrypt == "true")
            {
                defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
            }
            string dbType = dbConfigName.ToUpper();
            if (dbType.Contains("MSSQL"))
            {
                dbConnection = new SqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MYSQL"))
            {
                dbConnection = new MySqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("ORACLE"))
            {
                dbConnection = new OracleConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("SQLITE"))
            {
                dbConnection = new SqliteConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else if (dbType.Contains("NPGSQL"))
            {
                dbConnection = new NpgsqlConnection(defaultSqlConnectionString);
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }
            return dbConnection;
        }
        #endregion

        #region 查询获得对象和列表
        /// <summary>
        /// 根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual T Get(TKey primaryKey, IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Get<T>(primaryKey, trans);
            }
        }
        /// <summary>
        /// 异步根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync(TKey primaryKey, IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.GetAsync<T>(primaryKey, trans);
            }
        }

        /// <summary>
        /// 根据条件获取一个对象
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual T GetWhere(string where, IDbTransaction trans =null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
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

            return Execute((conn, trans) =>
            {
                return conn.QueryFirstOrDefault<T>(sql, trans);
            });
        }
        /// <summary>
        /// 根据条件异步获取一个对象
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual async Task<T> GetWhereAsync(string where, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
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

            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.QueryFirstOrDefault<T>(sql, trans);
            }
        }


        /// <summary>
        /// 查询对象，并返回关联的创建用户信息，
        /// 查询表别名为s，条件要s.字段名
        /// </summary>
        /// <param name="primaryKey">主键Id</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual T GetByIdRelationUser(TKey primaryKey, IDbTransaction trans = null)
        {
            string sql = $"select s.* ,u.RealName as RealName,u.NickName as NickName,u.HeadIcon as HeadIcon from { tableName} s left join sys_user u on s.CreatorUserId=u.Id";
            if (!string.IsNullOrWhiteSpace(primaryKey.ToString()))
            {
                sql += " where s."+ primaryKey + "='"+ primaryKey + "'";
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.QueryFirstOrDefault<T>(sql, trans);
            }
        }
        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll(IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.GetAll<T>(trans);
            }
        }
        /// <summary>
        /// 获取所有数据，谨慎使用
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync( IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.GetAllAsync<T>(trans);
            }
        }


        /// <summary>
        /// 根据查询条件获取数据集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetListWhere(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from { tableName} ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return Execute((conn, trans) =>
            {
                return conn.Query<T>(sql, trans);
            });
        }

        /// <summary>
        /// 根据查询条件获取数据集合
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetListWhereAsync(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields}  from { tableName} ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            return Execute((conn, trans) =>
            {
                return conn.Query<T>(sql, trans);
            });
        }

        /// <summary>
        /// 根据查询条件查询前多少条数据
        /// </summary>
        /// <param name="top">多少条数据</param>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetListTopWhere(int top,string where = null, IDbTransaction trans = null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select top {top} {selectedFields} from " + tableName;
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Query<T>(sql, trans);
            }
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
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select top {top} {selectedFields}  from " + tableName;
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += " where " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.QueryAsync<T>(sql, trans);
            }
        }
        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsDeleteMark(string where=null, IDbTransaction trans =null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields}  from { tableName} where DeleteMark=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += sql + " and "+where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Query<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteMark(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from { tableName} where DeleteMark=0";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Query<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsEnabledMark(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where EnabledMark=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Query<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotEnabledMark(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where EnabledMark=0";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql += sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Query<T>(sql, trans);
            }
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAllByIsNotDeleteAndEnabledMark(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where DeleteMark=0 and EnabledMark=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql = sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return conn.Query<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询软删除的数据，如果查询条件为空，即查询所有软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsDeleteMarkAsync(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where DeleteMark=1 ";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql = sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.QueryAsync<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询未软删除的数据，如果查询条件为空，即查询所有未软删除的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteMarkAsync(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where DeleteMark=0";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql = sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.QueryAsync<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询有效的数据，如果查询条件为空，即查询所有有效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsEnabledMarkAsync(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where EnabledMark=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql = sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.QueryAsync<T>(sql, trans);
            }
        }

        /// <summary>
        /// 查询无效的数据，如果查询条件为空，即查询所有无效的数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotEnabledMarkAsync(string where = null, IDbTransaction trans=null)
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
            string sql = $"select {selectedFields} from {tableName} where EnabledMark=0";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql = sql + " and " + where;
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                return await conn.QueryAsync<T>(sql, trans);
            }
        }
        /// <summary>
        /// 查询未软删除且有效的数据，如果查询条件为空，即查询所有数据
        /// </summary>
        /// <param name="where">查询条件</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllByIsNotDeleteAndEnabledMarkAsync(string where = null, IDbTransaction trans=null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(where))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", where));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(where))
            {
                where = "1=1";
            }
            string sql = $"select {selectedFields} from {tableName} where DeleteMark=0 and EnabledMark=1";
            if (!string.IsNullOrWhiteSpace(where))
            {
                sql = sql + " and " + where;
            }
            using DbConnection conn = OpenSharedConnection();
            return await conn.QueryAsync<T>(sql, trans);
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
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                
                PagerHelper pagerHelper = new PagerHelper(this.tableName,this.selectedFields,fieldToSort,info.PageSize,info.CurrenetPageIndex,desc,condition);
      
                string pageSql = pagerHelper.GetPagingSql(true, this.dbConfigName);
                pageSql +=";"+ pagerHelper.GetPagingSql(false, this.dbConfigName);

                var reader = conn.QueryMultiple(pageSql);
                info.RecordCount = reader.ReadFirst<int>();
                list = reader.Read<T>().AsList();
                return list;
            }
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
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            using (DbConnection conn = OpenSharedConnection())
            {

                PagerHelper pagerHelper = new PagerHelper(this.tableName, this.selectedFields, fieldToSort, info.PageSize, info.CurrenetPageIndex, desc, condition);

                string pageSql = pagerHelper.GetPagingSql(true, this.dbConfigName);
                pageSql += ";" + pagerHelper.GetPagingSql(false, this.dbConfigName);

                var reader = await conn.QueryMultipleAsync(pageSql);
                info.RecordCount = reader.ReadFirst<int>();
                list = reader.Read<T>().AsList();
                return list;
            }
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
            using (DbConnection conn = OpenSharedConnection())
            {
                StringBuilder sb = new StringBuilder();
                int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
                int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
                string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
                sb.AppendFormat("SELECT count(*) as RecordCount FROM (select {0} FROM {1} where {2})  AS main_temp;", primaryKey, tableName,condition);
                sb.AppendFormat("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by {0}) AS rows ,{1} FROM {2} where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition,  startRows, endNum);
                var reader = conn.QueryMultiple(sb.ToString());
                info.RecordCount = reader.ReadFirst<int>();
                list= reader.Read<T>().AsList();
                return list;
            }
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
            using (DbConnection conn = OpenSharedConnection())
            {
                StringBuilder sb = new StringBuilder();
                int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
                int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
                string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
                sb.AppendFormat("SELECT count(*) as RecordCount FROM (select {0} FROM {1} where {2})  AS main_temp;", primaryKey, tableName, condition);
                sb.AppendFormat("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by {0}) AS rows ,{1} FROM {2} where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);
                var reader = await conn.QueryMultipleAsync(sb.ToString());
                info.RecordCount = reader.ReadFirst<int>();
                list = reader.Read<T>().AsList();
                return list;
            }
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
        public virtual List<object> FindWithPagerRelationUser(string condition, PagerInfo info, string fieldToSort, bool desc,  IDbTransaction trans = null)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            using (DbConnection conn = OpenSharedConnection())
            {
                StringBuilder sb = new StringBuilder();
                int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
                int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
                string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
                sb.AppendFormat("SELECT count(*) as RecordCount FROM (select t1.{0} FROM {1} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id where {2})  AS main_temp;", primaryKey, tableName, condition);
                sb.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER (order by  {0}) AS rows ,t1.{1},t2.Account as Account,t2.NickName as NickName,t2.RealName as RealName,t2.HeadIcon as HeadIcon ,t2.MobilePhone as MobilePhone  FROM {2} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id " +
                    "where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);

                var reader = conn.QueryMultiple(sb.ToString());
                info.RecordCount = reader.ReadFirst<int>();
                List<object> list = reader.Read<object>().AsList();
                return list;
            }
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

            var type = MethodBase.GetCurrentMethod().DeclaringType;
            if (HasInjectionData(condition))
            {
                Log4NetHelper.Info(string.Format("检测出SQL注入的恶意数据, {0}", condition));
                throw new Exception("检测出SQL注入的恶意数据");
            }
            if (string.IsNullOrEmpty(condition))
            {
                condition = "1=1";
            }
            using DbConnection conn = OpenSharedConnection();
            StringBuilder sb = new StringBuilder();
            int startRows = (info.CurrenetPageIndex - 1) * info.PageSize + 1;//起始记录
            int endNum = info.CurrenetPageIndex * info.PageSize;//结束记录
            string strOrder = string.Format(" {0} {1}", fieldToSort, desc ? "DESC" : "ASC");
            sb.AppendFormat("SELECT count(*) as RecordCount FROM (select t1.{0} FROM {1} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id where {2})  AS main_temp;", primaryKey, tableName, condition);
            sb.AppendFormat("SELECT * FROM (SELECT ROW_NUMBER() OVER (order by  {0}) AS rows ,t1.{1},t2.Account as Account,t2.NickName as NickName,t2.RealName as RealName,t2.HeadIcon as HeadIcon ,t2.MobilePhone as MobilePhone  FROM {2} t1 inner join Sys_User t2 on t1.CreatorUserId = t2.Id " +
                "where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, selectedFields, tableName, condition, startRows, endNum);

            var reader = await conn.QueryMultipleAsync(sb.ToString());
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
            var type = MethodBase.GetCurrentMethod().DeclaringType;
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
            using (DbConnection conn = OpenSharedConnection())
            {
                return  conn.Query<int>(sql).FirstOrDefault();
            }
        }

        /// <summary>
        /// 根据条件统计数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public virtual async Task<int> GetCountByWhereAsync(string condition)
        {
            var type = MethodBase.GetCurrentMethod().DeclaringType;
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
            using (DbConnection conn = OpenSharedConnection())
            {
                IEnumerable<int> lit=  await conn.QueryAsync<int>(sql);
                return lit.FirstOrDefault();
            }
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
            using (DbConnection conn = OpenSharedConnection())
            {
                string sql = $"select isnull(MAX({strField}),0) as maxVaule from {tableName} ";
                if (!string.IsNullOrEmpty(where))
                {
                    sql += " where " + where;
                }

                IEnumerable<int> lit = await conn.QueryAsync<int>(sql);
                return lit.FirstOrDefault();
            }
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
            using (DbConnection conn = OpenSharedConnection())
            {
                string sql = $"select isnull(sum({strField}),0) as sumVaule from {tableName} ";
                if (!string.IsNullOrEmpty(where))
                {
                    sql += " where " + where;
                }
                IEnumerable<int> lit = await conn.QueryAsync<int>(sql);
                return lit.FirstOrDefault();
            }
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
            using (DbConnection conn = OpenSharedConnection())
            {
                if (entity.KeyIsNull())
                {
                    entity.GenerateDefaultKeyVal();
                }
                long row = conn.Insert(entity, trans);
                OperationLogOfInsert(entity); 
                return row;
            }
        }


        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<long> InsertAsync(T entity, IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                if (entity.KeyIsNull())
                {
                    entity.GenerateDefaultKeyVal();
                }
                long row = await conn.InsertAsync(entity, trans);
                OperationLogOfInsert(entity);
                return row;
            }
        }
        
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual long Insert(List<T> entities, IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        if (entity.KeyIsNull())
                        {
                            entity.GenerateDefaultKeyVal();
                        }
                    }
                    trans = conn.BeginTransaction();
                    long row = conn.Insert(entities, trans);
                    trans.Commit();
                    OperationLogOfInsert(entities);
                    return row;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 异步批量插入数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<long> InsertAsync(List<T> entities, IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                trans = conn.BeginTransaction();
                try
                {
                    foreach (var entity in entities)
                    {
                        if (entity.KeyIsNull())
                        {
                            entity.GenerateDefaultKeyVal();
                        }
                    }
                    long row = await conn.InsertAsync(entities, trans);
                    trans.Commit();
                    OperationLogOfInsert(entities);
                    return row;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
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
            //_dbContext.Update(entity);
            //OperationLogOfUpdate(entity, primaryKey);
            //int n = Save();
            //return n>0;
            using (DbConnection conn = OpenSharedConnection())
            {
                OperationLogOfUpdate(entity);
                return conn.Update(entity, trans);
            }
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(T entity, IDbTransaction trans = null)
        {
            //_dbContext.Update(entity);
            //OperationLogOfUpdate(entity);
            //int n = Save();
            //return n > 0;
            using (DbConnection conn = OpenSharedConnection())
            {
                OperationLogOfUpdate(entity);
                return conn.Update(entity, trans);
            }
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
            //_dbContext.Update(entity);
            //OperationLogOfUpdate(entity);
            //int n = Save();
            //return n > 0;
            using (DbConnection conn = OpenSharedConnection())
            {
                OperationLogOfUpdate(entity);
                return await  conn.UpdateAsync(entity, trans);
            }
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Update(List<T> entities, IDbTransaction trans=null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                try
                {
                    trans = conn.BeginTransaction();
                    bool bl=conn.Update(entities, trans);
                    trans.Commit();
                    OperationLogOfUpdate(entities);
                    return bl;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// 异步批量更新数据
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> UpdateAsync(List<T> entities,IDbTransaction trans=null)
        {
            using (DbConnection conn =OpenSharedConnection())
            {
                trans = conn.BeginTransaction();
                try
                {
                    bool isSuccess = await conn.UpdateAsync(entities, trans);
                    trans.Commit();
                    OperationLogOfUpdate(entities);
                    return isSuccess;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 同步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual bool Delete(T entity, IDbTransaction trans = null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                trans = conn.BeginTransaction();
                try
                {
                    bool isSuccess =  conn.Delete<T>(entity, trans);
                    trans.Commit();
                    return isSuccess;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 异步物理删除实体。
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(T entity, IDbTransaction trans = null)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                trans = conn.BeginTransaction();
                try
                {
                    bool isSuccess = await conn.DeleteAsync<T>(entity, trans);
                    trans.Commit();
                    return isSuccess;
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// 物理删除所有数据
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteAll(IDbTransaction trans=null)
        {
            using (DbConnection conn =OpenSharedConnection())
            {
                return conn.DeleteAll<T>(trans);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans">事务对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual async Task<bool> DeleteAllAsync(IDbTransaction trans=null)
        {
            using (DbConnection conn =OpenSharedConnection())
            {
                return await conn.DeleteAllAsync<T>(trans);
            }
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
            OperationLogOfDelete(primaryKey);
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
            OperationLogOfDelete(primaryKey);
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
            OperationLogOfDeleteSoft(primaryKey, userId);
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
            OperationLogOfDeleteSoft(primaryKey, userId);
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
        public virtual bool SetEnabledMark(bool bl, TKey primaryKey, string userId = null, IDbTransaction trans=null)
        {
            using (DbConnection conn =OpenSharedConnection())
            {
                OperationLogOfSetEnable(primaryKey, userId, bl);
                string sql = $"update {tableName} set ";
                if (bl)
                {
                    sql +=  "EnabledMark=1 ";
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
                sql += ",LastModifyTime=@lastModifyTime where "+ PrimaryKey + "=@PrimaryKey";

                var param = new List<Tuple<string, object>>();
                Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @PrimaryKey = primaryKey, @lastModifyTime = lastModifyTime });
                param.Add(tupel);
                Tuple<bool, string> result =  ExecuteTransaction(param);
                return result.Item1;

            }
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
            OperationLogOfSetEnable(primaryKey, userId, bl);
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
            Tuple<string, object> tupel = new Tuple<string, object>(sql, new { @LastModifyTime = lastModifyTime });
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
            using (DbConnection conn = OpenSharedConnection())
            {
                //开启事务
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string exeSqlLog = string.Empty;
                        foreach (var tran in trans)
                        {
                            exeSqlLog += "SQL语句:" + tran.Item1 + "  \n SQL参数: " + JsonHelper.ToJson(tran.Item2) + " \n";
                            conn.ExecuteAsync(tran.Item1, tran.Item2, transaction, commandTimeout);
                        }
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        //提交事务
                        transaction.Commit();
                        stopwatch.Stop();
                        exeSqlLog += "耗时:" + stopwatch.ElapsedMilliseconds + "  毫秒\n";
                        OperationLogOfSQL(sb.ToString());
                        return new Tuple<bool, string>(true, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        OperationLogOfException(ex);
                        Log4NetHelper.Error("",ex);
                        transaction.Rollback();
                        conn.Close();
                        conn.Dispose();
                        return new Tuple<bool, string>(false, ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
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
            using (DbConnection conn = OpenSharedConnection())
            {
                //开启事务
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string exeSqlLog = string.Empty;
                        foreach (var tran in trans)
                        {
                            exeSqlLog+="SQL语句:" + tran.Item1 + "  \n SQL参数: " + JsonHelper.ToJson(tran.Item2) + " \n";
                            conn.Execute(tran.Item1, tran.Item2, transaction, commandTimeout);
                        }
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        //提交事务
                        transaction.Commit();
                        stopwatch.Stop();
                        exeSqlLog+="耗时:" + stopwatch.ElapsedMilliseconds + "  毫秒\n";
                        OperationLogOfSQL(exeSqlLog);
                        return new Tuple<bool, string>(true, string.Empty);
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        OperationLogOfException(ex);
                        Log4NetHelper.Error("", ex);
                        transaction.Rollback();
                        conn.Close();
                        conn.Dispose();
                        return new Tuple<bool, string>(false, ex.ToString());
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync<T>(Func<DbConnection, DbTransaction, T> func)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var sb = new StringBuilder("ExecuteTransaction 事务： ");
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        //提交事务
                        transaction.Commit();
                        stopwatch.Stop();
                        sb.Append("耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
                        Log4NetHelper.Info(sb.ToString());
                        return func(conn, transaction);
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        Log4NetHelper.Error("", ex);
                        transaction.Rollback();
                        conn.Close();
                        conn.Dispose();
                        return func(conn, transaction);
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public T Execute<T>(Func<DbConnection, DbTransaction, T> func)
        {
            using (DbConnection conn = OpenSharedConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        var sb = new StringBuilder("ExecuteTransaction 事务： ");
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        //提交事务
                        transaction.Commit();
                        stopwatch.Stop();
                        sb.Append("耗时:" + (stopwatch.ElapsedMilliseconds + "  毫秒\n"));
                        Log4NetHelper.Info(sb.ToString());
                        return func(conn, transaction);
                    }
                    catch (Exception ex)
                    {
                        //回滚事务
                        Log4NetHelper.Error("", ex);
                        transaction.Rollback();
                        conn.Close();
                        conn.Dispose();
                        return func(conn, transaction);
                    }
                    finally
                    {
                        conn.Close();
                        conn.Dispose();
                    }
                }
            }
        }
        #endregion

        #region EF操作


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual long InsertEF(T entity, IDbTransaction trans = null)
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            this._dbContext.Add(entity);

            OperationLogOfInsert(entity);
            int n = Save();
            _dbContext.Entry(entity).State = EntityState.Detached;
            return n;
        }
        /// <summary>
        /// 异步新增
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="trans">事务对象</param>
        /// <returns></returns>
        public virtual async Task<long> InsertEFAsync(T entity, IDbTransaction trans = null)
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            await _dbContext.AddAsync(entity);
            OperationLogOfInsert(entity);
            int n = Save();
            _dbContext.Entry(entity).State = EntityState.Detached;
            return n;
        }

        /// <summary>
        /// 根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual T GetEF(TKey primaryKey, IDbTransaction trans = null)
        {
          return  _dbContext.Find<T>(primaryKey);
        }
        /// <summary>
        /// 异步根据id获取一个对象
        /// </summary>
        /// <param name="primaryKey">主键</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public virtual async Task<T> GetEFAsync(TKey primaryKey, IDbTransaction trans = null)
        {
            return await _dbContext.FindAsync<T>(primaryKey);
        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            try
            {
                var entities = _dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added
                                || e.State == EntityState.Modified)
                    .Select(e => e.Entity);

                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(entity, validationContext, validateAllProperties: true);
                }
                return _dbContext.SaveChanges();
            }
            catch (ValidationException exc)
            {
                throw (exc.InnerException as Exception ?? exc);
            }
            catch (Exception ex)
            {
                throw (ex.InnerException as Exception ?? ex);
            }
        }
        #endregion


        #region 用户操作记录的实现
        /// <summary>
        /// 插入操作的日志记录
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfInsert(T obj, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Create.ToString();
                string note = JsonHelper.ToJson(obj);
                OnOperationLog(this.tableName, operationType, note);
            }
        }

        /// <summary>
        /// 插入操作的日志记录
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfInsert(List<T> obj, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Create.ToString();
                string note = JsonHelper.ToJson(obj);
                OnOperationLog(this.tableName, operationType, note);
            }
        }
        /// <summary>
        /// 修改操作的日志记录
        /// </summary>
        /// <param name="primaryKey">记录ID</param>
        /// <param name="obj">数据对象</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfUpdate(T obj, TKey primaryKey, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                T objInDb = Get(primaryKey);
                if (objInDb != null)
                {
                    string operationType = DbLogType.Update.ToString();
                    string note = "更新前的数据：\n\r" + JsonHelper.ToJson(objInDb);
                    note += "\n\r更新后的数据：\n\r" + JsonHelper.ToJson(obj);
                    OnOperationLog(this.tableName, operationType, note);
                }

            }
        }
        /// <summary>
        /// 修改操作的日志记录
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfUpdate(T obj,  IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Update.ToString();
                string note = "\n\r更新后的数据：\n\r" + JsonHelper.ToJson(obj);
                OnOperationLog(this.tableName, operationType, note);
            }
        }
        /// <summary>
        /// 修改操作的日志记录
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfUpdate(List<T> obj, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Update.ToString();
                string note = "批量更新的数据：\n\r" + JsonHelper.ToJson(obj);
                OnOperationLog(this.tableName, operationType, note);

            }
        }
        /// <summary>
        /// 禁用或启用操作的日志记录
        /// </summary>
        /// <param name="primaryKey">记录ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="bltag">事务对象</param>
        protected virtual void OperationLogOfSetEnable(TKey primaryKey, string userId,bool bltag)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Update.ToString();


                if (primaryKey != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Id：{0}", primaryKey);
                    sb.AppendLine();
                    if (bltag)
                    {
                        sb.Append("状态：启用");
                    }
                    else
                    {
                        sb.Append("状态：禁用");
                    }
                    string note = sb.ToString();

                    OnOperationLog(this.tableName, operationType, note);
                }
            }
        }

        /// <summary>
        /// 删除操作的日志记录
        /// </summary>
        /// <param name="primaryKey">记录ID</param>
        protected virtual void OperationLogOfDelete(TKey primaryKey)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Delete.ToString();


                T objInDb = Get(primaryKey);
                if (objInDb != null) 
                {

                    string note = "删除数据：\n\r"+ JsonHelper.ToJson(objInDb);

                    OnOperationLog(this.tableName, operationType, note);
                }
            }
        }

        /// <summary>
        /// 软删除操作的日志记录
        /// </summary>
        /// <param name="primaryKey">记录ID</param>
        /// <param name="userId">用户ID</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfDeleteSoft(TKey primaryKey, string userId, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.DeleteSoft.ToString();
                if (primaryKey != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("Id：{0},软删除", primaryKey);
                    sb.AppendLine("\r\n");

                    string note = sb.ToString();
                    OnOperationLog(this.tableName, operationType, note);
                }
            }
        }


        /// <summary>
        /// 插入Sql的日志记录
        /// </summary>
        /// <param name="strSql">SQL 语句</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfSQL(string strSql, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.SQL.ToString();
                OnOperationLog(this.tableName, operationType, strSql);
            }
        }
        /// <summary>
        /// 插入异常记录
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="trans">事务对象</param>
        protected virtual void OperationLogOfException(Exception ex, IDbTransaction trans = null)
        {
            if (OnOperationLog != null)
            {
                string operationType = DbLogType.Exception.ToString();
                var message =
                   $" 异常类型：{ex.GetType().Name} \r\n异常信息：{ex.Message} \r\n堆栈调用：\r\n{ex.StackTrace}";
                OnOperationLog(this.tableName, operationType, message);
            }
        }
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
            if (_dbContext != null)
            {
                _dbContext.Dispose();
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
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
