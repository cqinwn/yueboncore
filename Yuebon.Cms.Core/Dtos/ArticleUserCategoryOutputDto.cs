using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 输出文章分类
    /// </summary>
    public class ArticleUserCategoryOutputDto : IOutputDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>	
        public virtual string SelectItems
        {
            get;
            set;
        }
        /// <summary>
        /// 目录id
        /// </summary>
        public virtual string UnSelectItems
        {
            get;
            set;
        }
        /// <summary>
        /// 页
        /// </summary>		
        public virtual string CreatorUserId
        {
            get;
            set;
        }
    }
}
