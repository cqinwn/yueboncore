using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.CodeGenerator
{
    public class DbExtractor:IDbExtractor
    {
        public string dbType="";
        public string dbName = "";

        public DbExtractor()
        {
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            dbType = yuebonCacheHelper.Get("CodeGeneratorDbType").ToString().ToUpper();
            dbName= yuebonCacheHelper.Get("CodeGeneratorDbName").ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DataBaseInfo> GetAllDataBases()
        {
            List<DataBaseInfo> list = new List<DataBaseInfo>();
            if (dbType.Contains("SQLSERVER"))
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list= mssqlExtractor.GetAllDataBases();
            }
            else if (dbType.Contains("MYSQL"))
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
            if (dbType.Contains("SQLSERVER"))
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list = mssqlExtractor.GetAllTables(tablelist);
            }
            else if (dbType.Contains("MYSQL"))
            {
                MySqlExtractor mssqlExtractor = new MySqlExtractor();
                list = mssqlExtractor.GetAllTables(this.dbName,tablelist);
            }
            return list;
        }

        public List<DbTableInfo> GetTablesWithPage(string strwhere, string fieldNameToSort, bool isDescending, PagerInfo info)
        {
            List<DbTableInfo> list = new List<DbTableInfo>();
            if (dbType.Contains("SQLSERVER"))
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list = mssqlExtractor.GetAllTables(strwhere, fieldNameToSort, isDescending, info);
            }
            else if (dbType.Contains("MYSQL"))
            {
                MySqlExtractor mssqlExtractor = new MySqlExtractor();
                list = mssqlExtractor.GetAllTables(this.dbName, strwhere, fieldNameToSort, isDescending, info);
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
            if (dbType.Contains("SQLSERVER"))
            {
                MssqlExtractor mssqlExtractor = new MssqlExtractor();
                list = mssqlExtractor.GetAllColumns(tableName);
            }
            else if (dbType.Contains("MYSQL"))
            {
                MySqlExtractor mssqlExtractor = new MySqlExtractor();
                list = mssqlExtractor.GetAllColumns(this.dbName, tableName);
            }
            return list;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
