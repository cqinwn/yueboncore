using System;
using Yuebon.Commons.Enums;

namespace Yuebon.Commons.Pages
{

    /// <summary> 
    /// 根据各种不同数据库生成不同分页语句的辅助类 PagerHelper
    /// </summary> 
    public class PagerHelper
    {
        #region 成员变量

        private string tableName;//待查询表或自定义查询语句
        private string fieldsToReturn = "*";//需要返回的列
        private string fieldNameToSort = string.Empty;//排序字段名称
        private int pageSize = 10;//页尺寸,就是一页显示多少条记录
        private int pageIndex = 1;//当前的页码
        private bool isDescending = false;//是否以降序排列
        private string strwhere = string.Empty;//检索条件(注意: 不要加 where)

        #endregion

        #region 属性对象

        /// <summary>
        /// 待查询表或自定义查询语句
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>
        /// 需要返回的列
        /// </summary>
        public string FieldsToReturn
        {
            get { return fieldsToReturn; }
            set { fieldsToReturn = value; }
        }

        /// <summary>
        /// 排序字段名称
        /// </summary>
        public string FieldNameToSort
        {
            get { return fieldNameToSort; }
            set { fieldNameToSort = value; }
        }

        /// <summary>
        /// 页尺寸,就是一页显示多少条记录
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 当前的页码
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 是否以降序排列结果
        /// </summary>
        public bool IsDescending
        {
            get { return isDescending; }
            set { isDescending = value; }
        }

        /// <summary>
        /// 检索条件(注意: 不要加 where)
        /// </summary>
        public string StrWhere
        {
            get { return strwhere; }
            set { strwhere = value; }
        }

        /// <summary>
        /// 表或Sql语句包装属性
        /// </summary>
        internal string TableOrSqlWrapper
        {
            get
            {
                bool isSql = tableName.ToLower().Contains("from");
                if (isSql)
                {
                    return string.Format("({0}) AA ", tableName);//如果是Sql语句，则加括号后再使用
                }
                else
                {
                    return tableName;//如果是表名，则直接使用
                }
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 默认构造函数，其他通过属性设置
        /// </summary>
        public PagerHelper()
        {
        }

        /// <summary>
        /// 完整的构造函数,可以包含条件,返回记录字段等条件
        /// </summary>
        /// <param name="tableName">表名称，可以自定义查询语句</param>
        /// <param name="fieldsToReturn">需要返回的列</param>
        /// <param name="fieldNameToSort">排序字段名称</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="pageIndex">当前的页码</param>
        /// <param name="isDescending">是否以降序排列</param>
        /// <param name="strwhere">检索条件</param>
        public PagerHelper(string tableName, string fieldsToReturn, string fieldNameToSort,
            int pageSize, int pageIndex, bool isDescending, string strwhere)
        {
            this.tableName = tableName;
            this.fieldsToReturn = fieldsToReturn;
            this.fieldNameToSort = fieldNameToSort;
            this.pageSize = pageSize;
            this.pageIndex = pageIndex;
            this.isDescending = isDescending;
            this.strwhere = strwhere;
        }

        #endregion

        #region 各种数据库Sql分页查询，不依赖于存储过程
        /// <summary>
        /// 不依赖于存储过程的分页(Oracle)
        /// </summary>
        /// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
        /// <returns></returns>
        private string GetOracleSql(bool isDoCount)
        {
            string sql = "";
            if (string.IsNullOrEmpty(this.strwhere))
            {
                this.strwhere = " (1=1) ";
            }

            if (isDoCount)//执行总数统计
            {
                sql = string.Format("select count(*) as Total from {0} Where {1} ", this.TableOrSqlWrapper, this.strwhere);
            }
            else
            {
                string strOrder = string.Format(" order by {0} {1}", this.fieldNameToSort, this.isDescending ? "DESC" : "ASC");

                int minRow = pageSize * (pageIndex - 1);
                int maxRow = pageSize * pageIndex;
                string selectSql = string.Format("select {0} from {1} Where {2} {3}", fieldsToReturn, this.TableOrSqlWrapper, this.strwhere, strOrder);
                sql = string.Format(@"select b.* from
                           (select a.*, rownum as rowIndex from({2}) a) b
                           where b.rowIndex > {0} and b.rowIndex <= {1}", minRow, maxRow, selectSql);
            }

            return sql;
        }

        /// <summary>
        /// 不依赖于存储过程的分页(SqlServer)
        /// </summary>
        /// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
        /// <param name="isSql2008">是否是Sql server2008及低版本，默认为false</param>
        /// <returns></returns>
        private string GetSqlServerSql(bool isDoCount,bool isSql2008=false)
        {
            string sql = "";
            if (string.IsNullOrEmpty(this.strwhere))
            {
                this.strwhere = " (1=1) ";
            }

            if (isDoCount)//执行总数统计
            {
                sql = string.Format("select count(*) as Total from {0} Where {1} ", this.TableOrSqlWrapper, this.strwhere);
            }
            else
            {
                string strOrder = string.Format(" order by {0} {1}", this.fieldNameToSort, this.isDescending ? "DESC" : "ASC");
                int minRow = pageSize * (pageIndex - 1) + 1;
                int maxRow = pageSize * pageIndex;
                if (isSql2008)
                {
                    sql = string.Format("SELECT * FROM ( SELECT ROW_NUMBER() OVER (order by {0}) AS rows ,{1} FROM {2} where {3}) AS main_temp where rows BETWEEN {4} and {5}", strOrder, fieldsToReturn, TableOrSqlWrapper, strwhere, minRow, maxRow);
                }
                else
                {
                    sql = string.Format(@"With Paging AS
                ( SELECT ROW_NUMBER() OVER ({0}) as RowNumber, {1} FROM {2} Where {3})
                SELECT * FROM Paging WHERE RowNumber Between {4} and {5}", strOrder, this.fieldsToReturn, this.TableOrSqlWrapper, this.strwhere,
                    minRow, maxRow);
                }
            }

            return sql;
        }

        /// <summary>
        /// 不依赖于存储过程的分页(Access)
        /// </summary>
        /// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
        /// <returns></returns>
        private string GetAccessSql(bool isDoCount)
        {
            string sql = "";
            if (string.IsNullOrEmpty(this.strwhere))
            {
                this.strwhere = " (1=1) ";
            }

            if (isDoCount)//执行总数统计
            {
                sql = string.Format("select count(*) as Total from {0} Where {1} ", this.TableOrSqlWrapper, this.strwhere);
            }
            else
            {
                string strTemp = string.Empty;
                string strOrder = string.Empty;
                if (this.isDescending)
                {
                    strTemp = "<(select min";
                    strOrder = string.Format(" order by [{0}] desc", this.fieldNameToSort);
                }
                else
                {
                    strTemp = ">(select max";
                    strOrder = string.Format(" order by [{0}] asc", this.fieldNameToSort);
                }

                sql = string.Format("select top {0} {1} from {2} ", this.pageSize, this.fieldsToReturn, this.TableOrSqlWrapper);

                //如果是第一页就执行以上代码，这样会加快执行速度
                if (this.pageIndex == 1)
                {
                    sql += string.Format(" Where {0} ", this.strwhere);
                    sql += strOrder;
                }
                else
                {
                    sql += string.Format(" Where [{0}] {1} ([{0}]) from (select top {2} [{0}] from {3} where {5} {4} ) as tblTmp) and {5} {4}",
                        this.fieldNameToSort, strTemp, (this.pageIndex - 1) * this.pageSize, this.TableOrSqlWrapper, strOrder, this.strwhere);
                }
            }

            return sql;
        }

        /// <summary>
        /// 不依赖于存储过程的分页(MySql)
        /// </summary>
        /// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
        /// <returns></returns>
        private string GetMySqlSql(bool isDoCount)
        {
            string sql = "";
            if (string.IsNullOrEmpty(this.strwhere))
            {
                this.strwhere = " (1=1) ";
            }

            if (isDoCount)//执行总数统计
            {
                sql = string.Format("select count(Id) as Total from {0} Where {1}", this.TableOrSqlWrapper, this.strwhere);
            }
            else
            {
                //SELECT * FROM 表名称 LIMIT M,N 
                string strOrder = string.Format(" order by {0} {1}", this.fieldNameToSort, this.isDescending ? "DESC" : "ASC");

                int minRow = pageSize * (pageIndex - 1);
                int maxRow = pageSize * pageIndex;
                sql = string.Format("select {0} from {1} where Id IN(select t.Id from (select Id from {1} Where {2} {3} limit {4},{5})as t);",
                    fieldsToReturn, this.TableOrSqlWrapper, this.strwhere, strOrder, minRow, pageSize);
            }

            return sql;
        }

        /// <summary>
        /// 不依赖于存储过程的分页(SQLite)
        /// </summary>
        /// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
        /// <returns></returns>
        private string GetSQLiteSql(bool isDoCount)
        {
            string sql = "";
            if (string.IsNullOrEmpty(this.strwhere))
            {
                this.strwhere = " (1=1) ";
            }

            if (isDoCount)//执行总数统计
            {
                sql = string.Format("select count(*) as Total from {0} Where {1} ", this.TableOrSqlWrapper, this.strwhere);
            }
            else
            {
                //SELECT * FROM 表名称 LIMIT M,N 
                string strOrder = string.Format(" order by {0} {1}", this.fieldNameToSort, this.isDescending ? "DESC" : "ASC");

                int minRow = pageSize * (pageIndex - 1);
                int maxRow = pageSize * pageIndex;
                sql = string.Format("select {0} from {1} Where {2} {3} LIMIT {4},{5}",
                    fieldsToReturn, this.TableOrSqlWrapper, this.strwhere, strOrder, minRow, pageSize);
            }

            return sql;
        }

        /// <summary>
        /// 获取对应数据库的分页语句（指定数据库类型）
        /// </summary>
        /// <param name="isDoCount">如果isDoCount为True，返回总数统计Sql；否则返回分页语句Sql</param>
        /// <param name="dbType">数据库类型枚举</param>
        public string GetPagingSql( bool isDoCount, DatabaseType dbType)
        {
            string sql = "";
            switch (dbType)
            {
                case DatabaseType.Access:
                    sql = GetAccessSql(isDoCount);
                    break;
                case DatabaseType.SqlServer:
                    sql = GetSqlServerSql(isDoCount);
                    break;
                case DatabaseType.Oracle:
                    sql = GetOracleSql(isDoCount);
                    break;
                case DatabaseType.MySql:
                    sql = GetMySqlSql(isDoCount);
                    break;
                case DatabaseType.SQLite:
                    sql = GetSQLiteSql(isDoCount);
                    break;
            }
            return sql;
        }


        /// <summary>
        /// 数据库类型
        /// </summary>
        /// <param name="databaseType"></param>
        /// <returns></returns>
        private DatabaseType GetDataBaseType(string databaseType)
        {
            DatabaseType returnValue = DatabaseType.SqlServer;
            foreach (DatabaseType dbType in Enum.GetValues(typeof(DatabaseType)))
            {
                if (dbType.ToString().Equals(databaseType, StringComparison.OrdinalIgnoreCase))
                {
                    returnValue = dbType;
                    break;
                }
            }
            return returnValue;
        }
        #endregion
    }


}