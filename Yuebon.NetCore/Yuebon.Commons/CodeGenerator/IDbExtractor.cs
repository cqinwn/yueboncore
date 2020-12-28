using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Pages;

namespace Yuebon.Commons.CodeGenerator
{
    /// <summary>
    /// 数据库操作接口
    /// </summary>
    public interface IDbExtractor : IDisposable
    {
        /// <summary>
        /// 获取数据库信息
        /// </summary>
        /// <returns></returns>
        List<DataBaseInfo> GetAllDataBases();
        /// <summary>
        /// 获取数据库表的信息
        /// </summary>
        /// <param name="tablelist">数据库表名称</param>
        /// <returns></returns>
        List<DbTableInfo> GetWhereTables(string tablelist=null);

        /// <summary>
        /// 根据条件获取数据库的所有表的信息
        /// </summary>
        /// <param name="strwhere"></param>
        /// <param name="fieldNameToSort"></param>
        /// <param name="isDescending"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        List<DbTableInfo> GetTablesWithPage(string strwhere, string fieldNameToSort, bool isDescending, PagerInfo info);

        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        /// <param name="tableName">数据表的名称</param>
        /// <returns></returns>
        List<DbFieldInfo> GetAllColumns(string tableName);
    }
}
