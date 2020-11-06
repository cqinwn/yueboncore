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
        private static string dbConfigName = "";
        /// <summary>
        /// 数据库连接
        /// </summary>
        private static IDbConnection dbConnection;
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
        public static IDbConnection GetDBConnection<TEntity>()
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            bool isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            //获取实体真实的数据库连接池对象名，如果不存在则用默认数据连接池名
            dbConfigName = typeof(TEntity).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName ?? dbConfigName;
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
                dbConnection=new SqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MYSQL"))
            {
                dbConnection =new MySqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("ORACLE"))
            {
                dbConnection = new OracleConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("SQLITE"))
            {
                dbConnection = new SqliteConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("NPGSQL"))
            {
                dbConnection = new NpgsqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
            return dbConnection;
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetDBConnection()
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
            else if (dbType.Contains("NPGSQL"))
            {
                dbConnection = new NpgsqlConnection(defaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
            return dbConnection;
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
        }
        #endregion
    }
}
