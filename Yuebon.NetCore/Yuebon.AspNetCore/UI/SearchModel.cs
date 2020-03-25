using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.AspNetCore.UI
{
    /// <summary>
    /// 查询条件公共实体类
    /// </summary>
    [Serializable]
    public class SearchModel
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string Keywords
        {
            get; set;
        }
        /// <summary>
        /// 排序方式 默认asc 
        /// </summary>
        public string Order
        {
            get; set;
        }
        /// <summary>
        /// 排序字段 默认Id
        /// </summary>
        public string Sort
        {
            get; set;
        }
        /// <summary>
        /// 第几页
        /// </summary>
        public int CurrentPage
        {
            get; set;
        }
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PageSize
        {
            get; set;
        }
    }
}
