﻿
using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Yuebon.Commons;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Core.DataManager;

namespace CodeGenerator.Seed
{
    public class MyContext
    {

        private static DbConnections connectObject => GetMainConnectionDb();
        private static string _connectionString = connectObject.MasterDB.ConnectionString;
        private static DbType _dbType = (DbType)connectObject.MasterDB.DatabaseType;
        public static string ConnId = connectObject.ConnId;
        private SqlSugarScope _db;

        /// <summary>
        /// 连接字符串 
        /// Yuebon.com
        /// </summary>
        public static DbConnections GetMainConnectionDb()
        {
            List<DbConnections> dbList = DBServerProvider.GetAllDbConnections();
            var mainConnetctDb = dbList.Find(x => x.ConnId == Appsettings.app(new string[] { "AppSetting", "DefaultDataBase" }));
            if (dbList.Count > 0)
            {
                if (mainConnetctDb == null)
                {
                    mainConnetctDb = DBServerProvider.GetAllDbConnections()[0];
                }
            }
            else
            {
                throw new Exception("请确保appsettigns.json中配置连接字符串,并设置Enabled为true;");
            }

            return mainConnetctDb;
        }
        /// <summary>
        /// 连接字符串 
        /// Yuebon.com
        /// </summary>
        public static string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }
        /// <summary>
        /// 数据库类型 
        /// Yuebon.com 
        /// </summary>
        public static DbType DbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }
        /// <summary>
        /// 数据连接对象 
        /// Yuebon.com 
        /// </summary>
        public SqlSugarScope Db
        {
            get { return _db; }
            private set { _db = value; }
        }

        /// <summary>
        /// 功能描述:构造函数
        /// 作　　者:Yuebon.com
        /// </summary>
        public MyContext(ISqlSugarClient sqlSugarClient)
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new ArgumentNullException("数据库连接字符串为空");

            _db = sqlSugarClient as SqlSugarScope;
            
        }


        #region 实例方法
        /// <summary>
        /// 功能描述:获取数据库处理对象
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <returns>返回值</returns>
        public SimpleClient<T> GetEntityDB<T>() where T : class, new()
        {
            return new SimpleClient<T>(_db);
        }


        #endregion


        #region 根据实体类生成数据库表
        /// <summary>
        /// 功能描述:根据实体类生成数据库表
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <param name="blnBackupTable">是否备份表</param>
        /// <param name="lstEntitys">指定的实体</param>
        public void CreateTableByEntity<T>(bool blnBackupTable, params T[] lstEntitys) where T : class, new()
        {
            Type[] lstTypes = null;
            if (lstEntitys != null)
            {
                lstTypes = new Type[lstEntitys.Length];
                for (int i = 0; i < lstEntitys.Length; i++)
                {
                    T t = lstEntitys[i];
                    lstTypes[i] = typeof(T);
                }
            }
            CreateTableByEntity(blnBackupTable, lstTypes);
        }

        /// <summary>
        /// 功能描述:根据实体类生成数据库表
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <param name="blnBackupTable">是否备份表</param>
        /// <param name="lstEntitys">指定的实体</param>
        public void CreateTableByEntity(bool blnBackupTable, params Type[] lstEntitys)
        {
            if (blnBackupTable)
            {
                _db.CodeFirst.BackupTable().InitTables(lstEntitys); //change entity backupTable            
            }
            else
            {
                _db.CodeFirst.InitTables(lstEntitys);
            }
        }
        #endregion


        #region 静态方法


        /// <summary>
        /// 功能描述:设置初始化参数
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <param name="strConnectionString">连接字符串</param>
        /// <param name="enmDbType">数据库类型</param>
        public static void Init(string strConnectionString, DbType enmDbType = SqlSugar.DbType.SqlServer)
        {
            _connectionString = strConnectionString;
            _dbType = enmDbType;
        }

        /// <summary>
        /// 功能描述:创建一个链接配置
        /// 作　　者:Yuebon.com
        /// 支持Nullable 可空类型自动化
        /// </summary>
        /// <param name="blnIsAutoCloseConnection">是否自动关闭连接</param>
        /// <param name="blnIsShardSameThread">是否夸类事务</param>
        /// <returns>ConnectionConfig</returns>
        public static ConnectionConfig GetConnectionConfig(bool blnIsAutoCloseConnection = true, bool blnIsShardSameThread = false)
        {
            ConnectionConfig config = new ConnectionConfig()
            {
                ConnectionString = _connectionString,
                DbType = _dbType,
                IsAutoCloseConnection = blnIsAutoCloseConnection,
                ConfigureExternalServices = new ConfigureExternalServices()
                {
                    //DataInfoCacheService = new HttpRuntimeCache()
                    EntityService = (c, p) =>
                    {
                        // int?  decimal?这种 isnullable=true
                        if (c.PropertyType.IsGenericType &&
                        c.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            p.IsNullable = true;
                        }
                        else if (c.PropertyType == typeof(string) &&
                                 c.GetCustomAttribute<RequiredAttribute>() == null)
                        { //string类型如果没有Required isnullable=true
                            p.IsNullable = true;
                        }
                    }
                },
                //IsShardSameThread = blnIsShardSameThread
            };
            return config;
        }

        /// <summary>
        /// 功能描述:获取一个自定义的DB
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <param name="config">config</param>
        /// <returns>返回值</returns>
        public static SqlSugarScope GetCustomDB(ConnectionConfig config)
        {
            return new SqlSugarScope(config);
        }
        /// <summary>
        /// 功能描述:获取一个自定义的数据库处理对象
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <param name="sugarClient">sugarClient</param>
        /// <returns>返回值</returns>
        public static SimpleClient<T> GetCustomEntityDB<T>(SqlSugarScope sugarClient) where T : class, new()
        {
            return new SimpleClient<T>(sugarClient);
        }
        /// <summary>
        /// 功能描述:获取一个自定义的数据库处理对象
        /// 作　　者:Yuebon.com
        /// </summary>
        /// <param name="config">config</param>
        /// <returns>返回值</returns>
        public static SimpleClient<T> GetCustomEntityDB<T>(ConnectionConfig config) where T : class, new()
        {
            SqlSugarScope sugarClient = GetCustomDB(config);
            return GetCustomEntityDB<T>(sugarClient);
        }
        #endregion
    }
}
