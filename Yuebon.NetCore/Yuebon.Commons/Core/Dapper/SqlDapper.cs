using Dapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Yuebon.Commons.Core.DataManager;

namespace Yuebon.Commons.Dapper
{
    /// <summary>
    /// Dapper常用方法的实现
    /// 注册的时候 InstancePerLifetimeScope
    /// 线程内唯一（也就是单个请求内唯一）
    /// </summary>
    public class SqlDapper : ISqlDapper
    {
        private IDbConnection dbConnection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (dbConnection == null || dbConnection.State == ConnectionState.Closed)
                {
                    dbConnection = DBServerProvider.GetDBConnection();
                }
                return dbConnection;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public SqlDapper()
        {
            DBServerProvider.GetConnectionString();
        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="connKeyName"></param>
        public SqlDapper(string connKeyName)
        {
           DBServerProvider.GetConnectionString(connKeyName);
        }

        /// <summary>
        /// 事务
        /// </summary>
        public IDbTransaction DbTransaction { get; set; }

        /// <summary>
        /// 是否已被提交
        /// </summary>
        public bool Committed { get; private set; } = true;

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            Committed = false;
            bool isClosed = Connection.State == ConnectionState.Closed;
            if (isClosed) Connection.Open();
            DbTransaction = Connection?.BeginTransaction();
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void CommitTransaction()
        {
            DbTransaction?.Commit();
            Committed = true;
            Dispose();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollBackTransaction()
        {
            DbTransaction?.Rollback();
            Committed = true;
            Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public T Get<T>(dynamic primaryKey) where T : class
        {
            var type = typeof(T);
            var key = GetSingleKey<T>(nameof(Get));
            var name = GetTableName(type);
            string sql = $"SELECT * FROM {name} WHERE {key.Name} = @keyName";

            var dynParms = new DynamicParameters();
            dynParms.Add("@keyName", primaryKey);
            return Connection.QueryFirstOrDefault<T>(sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public async Task<T> GetAsync<T>(dynamic primaryKey) where T : class
        {
            var type = typeof(T);
            var key = GetSingleKey<T>(nameof(Get));
            var name = GetTableName(type);
            string sql = $"SELECT * FROM {name} WHERE {key.Name} = @keyName";

            var dynParms = new DynamicParameters();
            dynParms.Add("@keyName", primaryKey);
            return await Connection.QueryFirstOrDefaultAsync<T>(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> KeyProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        /// <summary>
        /// 
        /// </summary>
        private static readonly ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>> TypeProperties = new ConcurrentDictionary<RuntimeTypeHandle, IEnumerable<PropertyInfo>>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetTableName(Type type)
        {
#if NETSTANDARD1_3
                var info = type.GetTypeInfo();
#else
                var info = type;
#endif
                //NOTE: This as dynamic trick falls back to handle both our own Table-attribute as well as the one in EntityFramework 
                var tableAttrName =
                    info.GetCustomAttribute<TableAttribute>(false)?.Name
                    ?? (info.GetCustomAttributes(false).FirstOrDefault(attr => attr.GetType().Name == "TableAttribute") as dynamic)?.Name;


            return tableAttrName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        private static PropertyInfo GetSingleKey<T>(string method)
        {
            var type = typeof(T);
            var keys = KeyPropertiesCache(type);
            //var explicitKeys = ExplicitKeyPropertiesCache(type);
            var keyCount = keys.Count;// + explicitKeys.Count;
            if (keyCount > 1)
                throw new DataException($"{method}<T> only supports an entity with a single [Key]  property. [Key] Count: {keys.Count}");
            if (keyCount == 0)
                throw new DataException($"{method}<T> only supports an entity with a [Key]  property");

            return keys[0];
        }

        /// <summary>
        /// 查询主键,属性加了Key标签
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static List<PropertyInfo> KeyPropertiesCache(Type type)
        {
            if (KeyProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pi))
            {
                return pi.ToList();
            }

            var allProperties = TypePropertiesCache(type);
            var keyProperties = allProperties.Where(p => p.GetCustomAttributes(true).Any(a => a is KeyAttribute)).ToList();

            if (keyProperties.Count == 0)
            {
                var idProp = allProperties.Find(p => string.Equals(p.Name, "Id", StringComparison.CurrentCultureIgnoreCase));
                if (idProp != null)
                {
                    keyProperties.Add(idProp);
                }
            }

            KeyProperties[type.TypeHandle] = keyProperties;
            return keyProperties;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static List<PropertyInfo> TypePropertiesCache(Type type)
        {
            if (TypeProperties.TryGetValue(type.TypeHandle, out IEnumerable<PropertyInfo> pis))
            {
                return pis.ToList();
            }

            var properties = type.GetProperties().ToArray();
            TypeProperties[type.TypeHandle] = properties;
            return properties.ToList();
        }

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
            str_Regex += strBadChar[^1] + ").*";

            return str_Regex;
        }


        #endregion


        #region Dispose实现
        private bool disposedValue = false; // 要检测冗余调用
        /// <summary>
        /// 释放
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
            if (Connection != null)
            {
                DbTransaction.Dispose();
                Connection.Dispose();
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

            DbTransaction?.Dispose();
            if (Connection.State == ConnectionState.Open)
                Connection?.Close();
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }

        #endregion

    }
}
