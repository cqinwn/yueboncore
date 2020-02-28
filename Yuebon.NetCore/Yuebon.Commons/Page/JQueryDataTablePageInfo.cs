using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Pages
{
    /// <summary>
    ///  JQueryDataTable 分页
    /// </summary>
    public class JQueryDataTablePageInfo
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrenetPageIndex { get; set; }
        /// <summary>
        /// 每页显示的记录
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 记录总数
        /// </summary>
        public int RecordCount { get; set; }
        /// <summary>
        /// 计数器
        /// </summary>
        public int Draw { get; set; }
        /// <summary>
        /// 计数器
        /// </summary>
        public int SearchValue { get; set; }

        /// <summary>
        /// 排序方式
        /// </summary>
        public int Order { get; set; }

    }
}