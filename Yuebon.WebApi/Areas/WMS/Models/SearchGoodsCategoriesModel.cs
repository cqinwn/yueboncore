using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.AspNetCore.UI;

namespace Yuebon.WebApi.Areas.WMS.Models
{
    /// <summary>
    /// 商品分类查询条件
    /// </summary>
    [Serializable]
    public class SearchGoodsCategoriesModel : SearchModel
    {

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 分类代码
        /// </summary>
        public string EnCode { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }
    }
}
