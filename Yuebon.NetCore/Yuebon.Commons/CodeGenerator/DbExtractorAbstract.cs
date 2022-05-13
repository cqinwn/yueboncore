﻿using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Core.DataManager;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.CodeGenerator
{
    /// <summary>
    /// 实现了基本方法的数据库抽取器基类
    /// </summary>
    public abstract class DbExtractorAbstract
    {

        #region 初始化
        /// <summary>
        /// 连接字符串
        /// </summary>
        internal string defaultSqlConnectionString { get; set; }

        private DbConnection dbConnection;
        /// <summary>
        /// 数据库配置名称
        /// </summary>
        protected string dbConfigName = "";
        private SqlSugarScope Db;
        /// <summary>
        /// 实例化
        /// </summary>
        public DbExtractorAbstract()
        {
            Db = OpenSharedConnection();

        }
        #endregion

        /// <summary>
        /// 数据库连接,根据数据库类型自动识别，类型区分用配置名称是否包含主要关键字
        /// MSSQL、MYSQL、ORACLE、SQLITE、MEMORY、NPGSQL
        /// </summary>
        /// <returns></returns>
        public SqlSugarScope OpenSharedConnection()
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            object connCode = yuebonCacheHelper.Get("CodeGeneratorDbConn");
            //DbConnectionOptions dbConnectionOptions = DBServerProvider.GeDbConnectionOptions();
            //DatabaseType dbType = DatabaseType.SqlServer;
            //if (connCode!=null)
            //{
            //    defaultSqlConnectionString = connCode.ToString();
            //    string dbTypeCache=yuebonCacheHelper.Get("CodeGeneratorDbType").ToString();
            //    dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), dbTypeCache);
            //}
            //else
            //{
            //    defaultSqlConnectionString = dbConnectionOptions.ConnectionString;

            //    dbType = dbConnectionOptions.DatabaseType;
            //    TimeSpan expiresSliding = DateTime.Now.AddMinutes(30) - DateTime.Now;
            //    yuebonCacheHelper.Add("CodeGeneratorDbConn", defaultSqlConnectionString, expiresSliding, false);
            //    yuebonCacheHelper.Add("CodeGeneratorDbType", dbType, expiresSliding, false);
            //}
            //if (dbType == DatabaseType.SqlServer)
            //{
            //    dbConnection = new SqlConnection(defaultSqlConnectionString);
            //}
            //else if (dbType == DatabaseType.MySql)
            //{
            //    dbConnection = new MySqlConnection(defaultSqlConnectionString);
            //}
            //else if (dbType == DatabaseType.Oracle)
            //{
            //    dbConnection = new OracleConnection(defaultSqlConnectionString);
            //}
            //else if (dbType == DatabaseType.SQLite)
            //{
            //    dbConnection = new SqliteConnection(defaultSqlConnectionString);
            //}
            //else if (dbType == DatabaseType.Npgsql)
            //{
            //    dbConnection = new NpgsqlConnection(defaultSqlConnectionString);
            //}
            //else
            //{
            //    throw new NotSupportedException("The database is not supported");
            //}
            //if (dbConnection.State != ConnectionState.Open)
            //{
            //    dbConnection.Open();
            //}
            string dbTypeCache = yuebonCacheHelper.Get("CodeGeneratorDbType").ToString();
            ConnectionConfig config = new ConnectionConfig()
            {
                ConfigId = "codedb",
                ConnectionString = connCode.ToString(),
                DbType = (SqlSugar.DbType)dbTypeCache.ToInt(),
                IsAutoCloseConnection = true
            };
            return new SqlSugarScope(config);
        }



        #region 信息抽取

        /// <summary>
        /// 获取数据库的所有表的信息，
        /// 请定义TABLE_NAME 和 COMMENTS 字段的脚本
        /// </summary>
        /// <param name="sql">具体的脚本</param>
        /// <returns></returns>
        protected List<DbTableInfo> GetAllTablesInternal(string sql)
        {
            var list = new List<DbTableInfo>();
            using (DbConnection conn = OpenSharedConnection())
            {
                list = conn.Query<DbTableInfo>(sql).ToList();
            }
            return list;
        }
        /// <summary>
        /// 获取所有数据库信息，
        /// </summary>
        /// <param name="sql">具体的脚本</param>
        /// <returns></returns>
        protected List<DataBaseInfo> GetAllDataBaseInternal(string sql)
        {
            var list = new List<DataBaseInfo>();
            using (DbConnection conn = OpenSharedConnection())
            {
                list = conn.Query<DataBaseInfo>(sql).ToList();
            }
            return list;
        }


        /// <summary>
        /// 获取数据库的所有表的信息，
        /// 请定义TABLE_NAME 和 COMMENTS 字段的脚本
        /// </summary>
        /// <param name="sql">具体的脚本</param>
        /// <param name="info">分页信息</param>
        /// <returns></returns>
        protected List<DbTableInfo> GetAllTablesInternal(string sql, PagerInfo info)
        {
            var list = new List<DbTableInfo>();
            using (DbConnection conn = OpenSharedConnection())
            {
                var reader = conn.QueryMultiple(sql);
                info.RecordCount = reader.ReadFirst<int>();
                list = reader.Read<DbTableInfo>().AsList();
            }
            return list;
        }
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <returns></returns>
        protected List<DbFieldInfo> GetAllColumnsInternal(string sql)
        {
            List<DbFieldInfo> list = new List<DbFieldInfo>();
            using (DbConnection conn = OpenSharedConnection())
            {
               IEnumerable<dynamic> dlist = conn.Query(sql);
                foreach(var item in dlist)
                {
                    DbFieldInfo dbFieldInfo = new DbFieldInfo
                    {
                        FieldName = item.FieldName,
                        //Increment = item.Increment == "1" ? true : false,
                        IsIdentity = item.IsIdentity == "1" ? true : false,
                        FieldType = item.FieldType.ToString(),
                        DataType = item.FieldType.ToString(),
                        FieldMaxLength = item.FieldMaxLength,
                        FieldPrecision = item.FieldPrecision,
                        FieldScale = item.FieldScale,
                        IsNullable = item.IsNullable == "1" ? true : false,
                        FieldDefaultValue = item.FieldDefaultValue,
                        Description = item.Description
                    };
                    list.Add(dbFieldInfo);
                }
            }
            return list;
        }

        #endregion
    }
}
