using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Yuebon.Commons.EfDbContext;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IRepositories;

namespace Yuebon.Commons.Repositories
{
    /// <summary>
    /// Represents the default implementation of the <see cref="IUnitOfWork"/> 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;
        private bool _disposed = false;
        private IDbConnection dbConnection;
        /// <summary>
        /// 数据库连接配置
        /// </summary>
        protected string defaultSqlConnectionString = "";
        /// <summary>
        /// 是否开启多租户
        /// </summary>
        protected bool isMultiTenant = false;

        /// <summary>
        /// 数据库配置名称
        /// </summary>
        protected string dbConfigName = "";
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
        /// Initializes a new instance of the 
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
        }



        public int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }


        public Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sql, object param = null, IDbTransaction trans = null) where TEntity : class
        {
            var conn = OpenSharedConnection();
            return conn.QueryAsync<TEntity>(sql, param, trans);

        }


        public async Task<int> ExecuteAsync(string sql, object param, IDbTransaction trans = null)
        {
            var conn = OpenSharedConnection();
            return await conn.ExecuteAsync(sql, param, trans);

        }



        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }



        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        /// <summary>
        /// 数据库连接,根据数据库类型自动识别，类型区分用配置名称是否包含主要关键字
        /// MSSQL、MYSQL、ORACLE、SQLITE、MEMORY、NPGSQL
        /// </summary>
        /// <returns></returns>
        public IDbConnection OpenSharedConnection()
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            this.isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }
            defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
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
    }
}
