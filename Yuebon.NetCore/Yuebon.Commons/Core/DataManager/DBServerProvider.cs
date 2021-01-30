using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
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
using Yuebon.Commons.DbContextCore;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.IDbContext;
using Yuebon.Commons.Json;

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
        /// <param name="masterDb">是否访问主库，默认为是，否则访问从库即只读数据库</param>
        /// <returns></returns>
        public static IDbConnection GetDBConnection<TEntity>(bool masterDb = true)
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            bool isMultiTenant = Configs.GetConfigurationValue("AppSetting", "IsMultiTenant").ToBool();
            //获取实体真实的数据库连接池对象名，如果不存在则用默认数据连接池名
            dbConfigName = typeof(TEntity).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName ?? dbConfigName;
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }

            Dictionary<string, DbConnectionOptions> dict = Configs.GetSection("DbConnections:" + dbConfigName).Get<Dictionary<string, DbConnectionOptions>>();
            Dictionary<string, DbConnectionOptions> dictRead = Configs.GetSection("DbConnections:" + dbConfigName+ ":ReadDb").Get<Dictionary<string, DbConnectionOptions>>();
            string defaultSqlConnectionString = dict["MassterDB"].ConnectionString;
            bool isDBReadWriteSeparate = Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool();
            DatabaseType dbType = DatabaseType.SqlServer;

            if (masterDb || !isDBReadWriteSeparate || dictRead.Count == 0)
            {
                defaultSqlConnectionString = dict["MassterDB"].ConnectionString;
                dbType = dict["MassterDB"].DatabaseType;
            }
            else
            {
                DbConnectionOptions connectionOptions = GetReadConn(dictRead);
                defaultSqlConnectionString = connectionOptions.ConnectionString;
                dbType = connectionOptions.DatabaseType;
            }
            if (conStringEncrypt == "true")
            {
                defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
            }
            if (dbType==DatabaseType.SqlServer)
            {
                dbConnection=new SqlConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.MySql)
            {
                dbConnection =new MySqlConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.Oracle)
            {
                dbConnection = new OracleConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.SQLite)
            {
                dbConnection = new SqliteConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.Npgsql)
            {
                dbConnection = new NpgsqlConnection(defaultSqlConnectionString);
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
        /// <param name="masterDb">是否访问主库，默认为是，否则访问从库即只读数据库</param>
        /// <returns></returns>
        public static IDbConnection GetDBConnection(bool masterDb=true)
        {
            string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }


            Dictionary<string, DbConnectionOptions> dict = Configs.GetSection("DbConnections:" + dbConfigName).Get<Dictionary<string, DbConnectionOptions>>();
            Dictionary<string, DbConnectionOptions> dictRead = Configs.GetSection("DbConnections:" + dbConfigName + ":ReadDb").Get<Dictionary<string, DbConnectionOptions>>();
            string defaultSqlConnectionString = dict["MassterDB"].ConnectionString;
            bool isDBReadWriteSeparate = Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool();
            DatabaseType dbType = DatabaseType.SqlServer;

            if (masterDb || !isDBReadWriteSeparate || dictRead.Count == 0)
            {
                defaultSqlConnectionString = dict["MassterDB"].ConnectionString;
                dbType = dict["MassterDB"].DatabaseType;
            }
            else
            {
                DbConnectionOptions connectionOptions = GetReadConn(dictRead);
                defaultSqlConnectionString = connectionOptions.ConnectionString;
                dbType = connectionOptions.DatabaseType;
            }
            if (conStringEncrypt == "true")
            {
                defaultSqlConnectionString = DEncrypt.Decrypt(defaultSqlConnectionString);
            }
            if (dbType == DatabaseType.SqlServer)
            {
                dbConnection = new SqlConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.MySql)
            {
                dbConnection = new MySqlConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.Oracle)
            {
                dbConnection = new OracleConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.SQLite)
            {
                dbConnection = new SqliteConnection(defaultSqlConnectionString);
            }
            else if (dbType == DatabaseType.Npgsql)
            {
                dbConnection = new NpgsqlConnection(defaultSqlConnectionString);
            }
            else
            {
                throw new NotSupportedException("The database is not supported");
            }
            return dbConnection;
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

        /// <summary>
        /// 按从库数据库连接的策略进行返回连接对象，实现从库的负载均衡
        /// </summary>
        /// <param name="slaveData"></param>
        /// <returns></returns>
        private static DbConnectionOptions GetReadConn(Dictionary<string, DbConnectionOptions> slaveData)
        {
            DbConnectionOptions connectionOptions = new DbConnectionOptions();
            string queryDBStrategy = Configs.GetConfigurationValue("AppSetting", "QueryDBStrategy");
            if(queryDBStrategy== "Random")//随机策略
            {
                int index = new Random().Next(0, slaveData.Count - 1);
                connectionOptions = slaveData[index.ToString()];

            }
            else if (queryDBStrategy == "Polling")//轮询策略
            {

            }
            else //权重策略
            {

            }
            return connectionOptions;
        }
    }
}
