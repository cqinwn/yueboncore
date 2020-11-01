using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using Yuebon.Commons.Dapper;
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;

namespace Yuebon.Commons.Core.DataManager
{
    /// <summary>
    /// 数据库服务提供者
    /// </summary>
    public class DBServerProvider
    {
        /// <summary>
        /// 数据库配置名称
        /// </summary>
        private static string dbConfigName = "MsSqlServer";
        #region Dapper Context
        /// <summary>
        /// 获取默认数据库连接
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
          return  GetConnectionString(dbConfigName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConnectionString(string key)
        {
          return  dbConfigName = key?? dbConfigName;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetDBConnection()
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            bool isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }
            // 数据库连接配置
            string defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
            if (isMultiTenant)
            {
                defaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
            }
            if (conStringEncrypt == "true")
            {
                defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
            }
            string dbType = dbConfigName.ToUpper();
            if (dbType.Contains("MSSQL"))
            {
                return new SqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MYSQL"))
            {
                return new MySqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("ORACLE"))
            {
                return new OracleConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("SQLITE"))
            {
                return new SqliteConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else if (dbType.Contains("NPGSQL"))
            {
                return new NpgsqlConnection(defaultSqlConnectionString);
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
        }
        /// <summary>
        /// 默认数据库连接
        /// </summary>
        public static ISqlDapper SqlDapper
        {
            get
            {
                return new SqlDapper(dbConfigName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static ISqlDapper GetSqlDapper(string dbName = null)
        {
            return new SqlDapper(dbName ?? dbConfigName);
        }
        /// <summary>
        /// 指定数据库连接
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static ISqlDapper GetSqlDapper<TEntity>()
        {
            //获取实体真实的数据库连接池对象名，如果不存在则用默认数据连接池名
            dbConfigName = typeof(TEntity).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName ?? dbConfigName;
            return GetSqlDapper(dbConfigName);
        }
        #endregion

        #region EF Context
        /// <summary>
        /// 获取实体的数据库连接
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="defaultDbContext"></param>
        /// <returns></returns>
        public static void GetDbContextConnection<TEntity>(IDbContextCore defaultDbContext)
        {

            dbConfigName = typeof(TEntity).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName ?? dbConfigName;
            //defaultDbContext.GetDatabase().ConnectionString = ConnectionPool[dbName];
            //string connstr= defaultDbContext.Database.GetDbConnection().ConnectionString;
            // if (connstr != ConnectionPool[DefaultConnName])
            // {
            //     defaultDbContext.Database.GetDbConnection().ConnectionString = ConnectionPool[DefaultConnName];
            // };
        }
        #endregion
    }
}
