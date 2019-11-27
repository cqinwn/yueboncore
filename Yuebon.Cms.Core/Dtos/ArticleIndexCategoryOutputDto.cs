using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 输出文章分类
    /// </summary>
    public class ArticleIndexCategoryOutputDto : IOutputDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>	
        public virtual string txt
        {
            get;
            set;
        }
        /// <summary>
        /// 目录id
        /// </summary>
        public virtual string cateId
        {
            get;
            set;
        }
        /// <summary>
        /// 页
        /// </summary>		
        public virtual string page
        {
            get;
            set;
        }
        /// <summary>
        /// 加载更多
        /// </summary>
        public virtual bool loadMore
        {
            set;
            get;
        }

        /// <summary>
        /// 加载更多
        /// </summary>
        public virtual bool refresh
        {
            set;
            get;
        }

        /// <summary>
        /// 加载更多
        /// </summary>
        public virtual int loadingType
        {
            set;
            get;
        }

        /// <summary>
        /// 加载更多
        /// </summary>
        public virtual int maxpage
        {
            set;
            get;
        }
    }
}
