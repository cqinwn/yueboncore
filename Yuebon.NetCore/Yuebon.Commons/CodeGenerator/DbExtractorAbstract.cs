using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Encrypt;
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
        internal string DefaultSqlConnectionString { get; set; }

        private DbConnection dbConnection;
        /// <summary>
        /// 数据库配置名称
        /// </summary>
        protected string dbConfigName = "";
        /// <summary>
        /// 实例化
        /// </summary>
        public DbExtractorAbstract()
        {

        }
        #endregion

        /// <summary>
        /// 数据库连接,根据数据库类型自动识别，类型区分用配置名称是否包含主要关键字
        /// MSSQL、MYSQL、ORACLE、SQLITE、MEMORY、NPGSQL
        /// </summary>
        /// <returns></returns>
        public DbConnection OpenSharedConnection()
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            object connCode = yuebonCacheHelper.Get("CodeGeneratorDbConn");
            string dbType = "";
            if (connCode!=null)
            {
                DefaultSqlConnectionString = connCode.ToString();
                dbType=yuebonCacheHelper.Get("CodeGeneratorDbType").ToString().ToUpper();
            }
            else
            {
                string conStringEncrypt = Configs.GetConfigurationValue("AppSetting", "ConStringEncrypt");
                if (string.IsNullOrEmpty(dbConfigName))
                {
                    dbConfigName = Configs.GetConfigurationValue("AppSetting", "DefaultDataBase");
                }
                DefaultSqlConnectionString = Configs.GetConnectionString(dbConfigName);
                if (conStringEncrypt == "true")
                {
                    DefaultSqlConnectionString = DEncrypt.Decrypt(DefaultSqlConnectionString);
                }
                dbType = dbConfigName.ToUpper();
                TimeSpan expiresSliding = DateTime.Now.AddMinutes(30) - DateTime.Now;
                yuebonCacheHelper.Add("CodeGeneratorDbConn", DefaultSqlConnectionString, expiresSliding, false);
                yuebonCacheHelper.Add("CodeGeneratorDbType", dbType, expiresSliding, false);
            }
            if (dbType.Contains("SQLSERVER"))
            {
                dbConnection = new SqlConnection(DefaultSqlConnectionString);
            }
            else if (dbType.Contains("MYSQL"))
            {
                dbConnection = new MySqlConnection(DefaultSqlConnectionString);
            }
            else if (dbType.Contains("ORACLE"))
            {
                dbConnection = new OracleConnection(DefaultSqlConnectionString);
            }
            else if (dbType.Contains("SQLITE"))
            {
                dbConnection = new SqliteConnection(DefaultSqlConnectionString);
            }
            else if (dbType.Contains("MEMORY"))
            {
                throw new NotSupportedException("In Memory Dapper Database Provider is not yet available.");
            }
            else if (dbType.Contains("NPGSQL"))
            {
                dbConnection = new NpgsqlConnection(DefaultSqlConnectionString);
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
