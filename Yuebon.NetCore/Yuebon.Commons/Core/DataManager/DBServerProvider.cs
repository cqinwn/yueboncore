using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Encrypt;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extensions;

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
        private static string dbConfigName = "DefaultDb";

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
            DbConnectionOptions connectionOptions = GeDbConnectionOptions<TEntity>(masterDb); 
            string defaultSqlConnectionString = connectionOptions.ConnectionString;
            DatabaseType dbType = connectionOptions.DatabaseType;
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
            DbConnectionOptions connectionOptions = GeDbConnectionOptions(masterDb);
            string defaultSqlConnectionString = connectionOptions.ConnectionString;
            DatabaseType dbType = connectionOptions.DatabaseType;
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

        /// <summary>
        /// 获取数据库连接连接配置
        /// </summary>
        /// <typeparam name="TEntity">数据实体</typeparam>
        /// <param name="masterDb">是否访问主库，默认为是，否则访问从库即只读数据库</param>
        /// <returns></returns>
        public static DbConnectionOptions GeDbConnectionOptions<TEntity>(bool masterDb = true)
        {          
            dbConfigName = typeof(TEntity).GetCustomAttribute<AppDBContextAttribute>(false)?.DbConfigName ?? "DefaultDb";
            bool conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }

            List<DbConnections> listdatabase = Appsettings.app<DbConnections>("DbConnections").Where(i => i.Enabled).ToList();
            List<DbConnectionOptions> dictRead = listdatabase.Where(m => m.ConnId == dbConfigName).FirstOrDefault().ReadDB;

            DbConnectionOptions dbConnectionOptions = new DbConnectionOptions();
            bool isDBReadWriteSeparate = Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool();
            if (masterDb || !isDBReadWriteSeparate)
            {
                DbConnections conn = listdatabase.Where(m => m.ConnId == dbConfigName).FirstOrDefault();
                dbConnectionOptions.ConnectionString = conn.MasterDB.ConnectionString;// Configs.GetConfigurationValue("DbConnections:" + dbConfigName+":MasterDB", "ConnectionString");
                dbConnectionOptions.DatabaseType = conn.MasterDB.DatabaseType;//(DatabaseType)Enum.Parse(typeof(DatabaseType), Configs.GetConfigurationValue("DbConnections:" + dbConfigName + ":MasterDB", "DatabaseType"));
            }
            else
            {
                dbConnectionOptions = GetReadConn(dictRead);
            }
            if (conStringEncrypt)
            {
                dbConnectionOptions.ConnectionString = DEncrypt.Decrypt(dbConnectionOptions.ConnectionString);
            }
            return dbConnectionOptions;
        }


        /// <summary>
        /// 获取数据库连接连接配置
        /// </summary>
        /// <param name="masterDb">是否访问主库，默认为是，否则访问从库即只读数据库</param>
        /// <returns></returns>
        public static DbConnectionOptions GeDbConnectionOptions(bool masterDb = true)
        {
            bool conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt").ToBool();
            if (string.IsNullOrEmpty(dbConfigName))
            {
                dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
            }

            List<DbConnections> listdatabase = Appsettings.app<DbConnections>("DbConnections").Where(i => i.Enabled).ToList();
            List<DbConnectionOptions> dictRead =listdatabase.Where(m=>m.ConnId== dbConfigName).FirstOrDefault().ReadDB;

            DbConnectionOptions dbConnectionOptions = new DbConnectionOptions();
            bool isDBReadWriteSeparate = Configs.GetConfigurationValue("AppSetting", "IsDBReadWriteSeparate").ToBool();
            if (masterDb || !isDBReadWriteSeparate)
            {
                DbConnections conn = listdatabase.Where(m => m.ConnId == dbConfigName).FirstOrDefault();
                dbConnectionOptions.ConnectionString = conn.MasterDB.ConnectionString;
                dbConnectionOptions.DatabaseType = conn.MasterDB.DatabaseType;
            }
            else
            {
                dbConnectionOptions = GetReadConn(dictRead);
            }
            if (conStringEncrypt)
            {
                dbConnectionOptions.ConnectionString = DEncrypt.Decrypt(dbConnectionOptions.ConnectionString);
            }
            return dbConnectionOptions;
        }

        /// <summary>
        /// 按从库数据库连接的策略进行返回连接对象，实现从库的负载均衡
        /// </summary>
        /// <param name="slaveData"></param>
        /// <returns></returns>
        private static DbConnectionOptions GetReadConn(List<DbConnectionOptions> slaveData)
        {
            DbConnectionOptions connectionOptions = new DbConnectionOptions();
            string queryDBStrategy = Configs.GetConfigurationValue("AppSetting", "QueryDBStrategy");
            if(queryDBStrategy== "Random")//随机策略
            {
                int index = new Random().Next(0, slaveData.Count - 1);
                connectionOptions = slaveData[index];
            }
            else if (queryDBStrategy == "Polling")//轮询策略
            {

            }
            else //权重策略
            {

            }
            return connectionOptions;
        }

        #endregion

        /// <summary>
        /// 获取所有数据库连接配置
        /// </summary>
        /// <returns></returns>
        public static List<DbConnections> GetAllDbConnections()
        {
            List<DbConnections> listdatabase = Appsettings.app<DbConnections>("DbConnections").Where(i => i.Enabled).ToList();
            return listdatabase;
        }
    }
}
