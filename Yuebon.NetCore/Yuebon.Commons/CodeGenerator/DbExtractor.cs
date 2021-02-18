using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.CodeGenerator
{
    public class DbExtractor:IDbExtractor
    {
        public string dbName = "";
        DatabaseType dbType = DatabaseType.SqlServer;
        public DbExtractor()
        {
            MssqlExtractor mssqlExtractor = new MssqlExtractor();
            mssqlExtractor.OpenSharedConnection();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            string dbTypeCache = yuebonCacheHelper.Get("CodeGeneratorDbType").ToString();
            if (dbTypeCache != null)
               dbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), dbTypeCache);
            object odbn = yuebonCacheHelper.Get("CodeGeneratorDbName");
            if (odbn != null)
                dbName = odbn.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DataBaseInfo> GetAllDataBases()
        {
            List<DataBaseInfo> list = new List<DataBaseInfo>();
            if (dbType == DatabaseType.SqlServer)
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list= mssqlExtractor.GetAllDataBases();
            }
            else if (dbType == DatabaseType.MySql)
            {
                MySqlExtractor mssqlExtractor = new MySqlExtractor();
                list= mssqlExtractor.GetAllDataBases();
            }
            return list;
        }
        /// <summary>
        /// 获取数据所有表信息
        /// </summary>
        /// <param name="tablelist">数据库表名称</param>
        /// <returns></returns>
        public List<DbTableInfo> GetWhereTables(string tablelist = null)
        {
            List<DbTableInfo> list = new List<DbTableInfo>();
            if (dbType == DatabaseType.SqlServer)
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list = mssqlExtractor.GetAllTables(tablelist);
            }
            else if (dbType == DatabaseType.MySql)
            {
                MySqlExtractor mssqlExtractor = new MySqlExtractor();
                list = mssqlExtractor.GetAllTables(this.dbName,tablelist);
            }
            return list;
        }

        public List<DbTableInfo> GetTablesWithPage(string tablename, string fieldNameToSort, bool isDescending, PagerInfo info)
        {
            List<DbTableInfo> list = new List<DbTableInfo>();
            if (dbType == DatabaseType.SqlServer)
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list = mssqlExtractor.GetAllTables(tablename, fieldNameToSort, isDescending, info);
            }
            else if (dbType == DatabaseType.MySql)
            {
                MySqlExtractor mysqlExtractor = new MySqlExtractor();
                list = mysqlExtractor.GetAllTables(this.dbName, tablename, fieldNameToSort, isDescending, info);
            }
            return list;
        }

        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        public List<DbFieldInfo> GetAllColumns(string tableName)
        {
            List<DbFieldInfo> list = new List<DbFieldInfo>();
            if (dbType == DatabaseType.SqlServer)
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list = mssqlExtractor.GetAllColumns(tableName);
            }
            else if (dbType == DatabaseType.MySql)
            {
                MySqlExtractor mysqlExtractor = new MySqlExtractor();
                list = mysqlExtractor.GetAllColumns(this.dbName, tableName);
            }
            return list;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
