using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.CodeGenerator
{
    /// <summary>
    /// MS SQL
    /// </summary>
   public class MssqlExtractor: DbExtractorAbstract
    {

        /// <summary>
        /// 获取数据库信息
        /// </summary>
        /// <returns></returns>
        public List<DataBaseInfo> GetAllDataBases()
        {
            var sql = string.Format(@"select name as DbName from master..sysdatabases as dbs");
            return GetAllDataBaseInternal(sql);
        }
        /// <summary>
        /// 根据表名获取数据库表的信息
        /// </summary>
        /// <param name="tablelist">表名称</param>
        /// <returns></returns>
        public List<DbTableInfo> GetAllTables(string tablelist)
        {
            var sql = string.Format(@"SELECT tbs.name as TableName ,ds.value as Description FROM sys.tables tbs
left join sys.extended_properties ds on ds.major_id=tbs.object_id and ds.minor_id=0");
            if (!string.IsNullOrEmpty(tablelist))
            {
                sql += string.Format(@" where tbs.name in('{0}')", tablelist.Replace(",","','"));
            }
            return GetAllTablesInternal(sql);
        }


        /// <summary>
        /// 获取数据库的所有表的信息
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="fieldNameToSort"></param>
        /// <param name="isDescending"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<DbTableInfo> GetAllTables(string tablename, string fieldNameToSort, bool isDescending, PagerInfo info)
        {

            string where = "1=1";
            if (!string.IsNullOrEmpty(tablename))
            {
                where += " and TableName like '%" + tablename + "%'";
            }
            var sql = string.Format(@"SELECT tbs.name as TableName ,ds.value as Description FROM sys.tables tbs
left join sys.extended_properties ds on ds.major_id=tbs.object_id and ds.minor_id=0");
           
            string sqlcount = string.Format(@"select count(*) as Total from({0}) AA where {1}", sql, where);

            string strOrder = string.Format(" order by {0} {1}", fieldNameToSort, isDescending ? "DESC" : "ASC");
            int minRow = info.PageSize * (info.CurrenetPageIndex - 1) + 1;
            int maxRow = info.PageSize * info.CurrenetPageIndex;

            string pagesql = string.Format(@"With Paging AS
                ( SELECT ROW_NUMBER() OVER ({0}) as RowNumber, {1} FROM ({2}) AA Where {3})
                SELECT * FROM Paging WHERE RowNumber Between {4} and {5}", strOrder, "*", sql, where,
            minRow, maxRow);
            pagesql = sqlcount + ";" + pagesql;
            return GetAllTablesInternal(pagesql, info);
        }
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        public List<DbFieldInfo> GetAllColumns(string tableName)
        {
            if (tableName == null)
                throw new ArgumentNullException(nameof(tableName));
          
            var sqlFields = string.Format(@"
               SELECT a.name as FieldName,
(case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '1'else '0' end) as Increment, 
(case when (SELECT count(*) FROM sysobjects 
WHERE (name in (SELECT name FROM sysindexes 
WHERE (id = a.id) AND (indid in 
(SELECT indid FROM sysindexkeys 
WHERE (id = a.id) AND (colid in 
(SELECT colid FROM syscolumns WHERE (id = a.id) AND (name = a.name))))))) 
AND (xtype = 'PK'))>0 then '1' else '0' end) as IsIdentity,b.name as FieldType,a.length as FieldMaxLength, 
COLUMNPROPERTY(a.id,a.name,'PRECISION') as FieldPrecision, 
isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0) as FieldScale,(case when a.isnullable=1 then '1'else '0' end) IsNullable, 
isnull(g.[value], ' ') AS Description
FROM syscolumns a 
left join systypes b on a.xtype=b.xusertype 
inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' 
left join syscomments e on a.cdefault=e.id 
left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id
left join sys.extended_properties f on d.id=f.class and f.minor_id=0
WHERE d.name='{0}' --如果只查询指定表,加上此条件
order by a.id,a.colorder", tableName);
            List<DbFieldInfo> list = new List<DbFieldInfo>();
            list = GetAllColumnsInternal(sqlFields);
            List<DbFieldInfo> reslist = new List<DbFieldInfo>();
            foreach (DbFieldInfo info in list)
            {
                info.DataType= ConvertDataType(info);
                reslist.Add(info);
            }
            return reslist;
        }


        #region 字段转换
        //所有类型转换 http://www.cnblogs.com/vjine/p/3462167.html
        /// <summary>
        /// 将字段信息的类型转换为C#信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public string ConvertDataType(DbFieldInfo info)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));
            if (string.IsNullOrEmpty(info.FieldType))
                throw new ArgumentNullException(nameof(info.FieldType));
            info.DataType = SqlType2CsharpTypeStr(info.FieldType, info.IsNullable);
            return info.DataType;
        }

        /// <summary>
        /// 将数据库类型转为系统类型。
        /// </summary>
        /// <param name="sqlType"></param>
        /// <param name="isNullable">字段是否可空</param>
        /// <returns></returns>
        public static string SqlType2CsharpTypeStr(string sqlType, bool isNullable = false)
        {
            if (string.IsNullOrEmpty(sqlType))
                throw new ArgumentNullException(nameof(sqlType));
            var val = string.Empty;
            var allowNull = false;
            switch (sqlType.ToLower())
            {
                case "bit":
                    val = "bool";
                    break;
                case "int":
                    val = "int";
                    break;
                case "smallint":
                    val = "short";
                    break;
                case "bigint":
                    val = "long";
                    break;
                case "tinyint":
                    val = "byte";
                    break;

                case "binary":
                case "image":
                case "varbinary":
                    val = "byte[]";
                    allowNull = true;
                    break;

                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    val = "decimal";
                    break;

                case "float":
                    val = "float";
                    break;
                case "real":
                    val = "Single";
                    break;

                case "datetime":
                case "date":
                    val = "DateTime";
                    break;   
                case "smalldatetime":
                case "timestamp":
                    val = "DateTime";
                    break;

                case "uniqueidentifier":
                    val = "Guid";
                    break;
                case "Variant":
                    val = "object";
                    allowNull = true;
                    break;

                case "text":
                case "ntext":
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                default:
                    val = "string";
                    allowNull = true;
                    break;
            }
            if (isNullable && !allowNull)
                return val + "?";
            return val;
        }
        #endregion
    }
}
