using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Pages
{
        /// <summary>
        /// 保存分页请求的结果。
        /// </summary>
        /// <typeparam name="T">返回结果集中的POCO类型</typeparam>
        public class PageResult<T>
        {
            /// <summary>
            /// 当前页码。
            /// </summary>
            public long CurrentPage { get; set; }

            /// <summary>
            /// 总页码数。
            /// </summary>
            public long TotalPages { get; set; }

            /// <summary>
            /// 记录总数。
            /// </summary>
            public long TotalItems { get; set; }

            /// <summary>
            /// 每页数量。
            /// </summary>
            public long ItemsPerPage { get; set; }

            /// <summary>
            /// 当前结果集。
            /// </summary>
            public List<T> Items { get; set; }

            /// <summary>
            /// 自定义用户属性。
            /// </summary>
            public object Context { get; set; }
        }
    }
