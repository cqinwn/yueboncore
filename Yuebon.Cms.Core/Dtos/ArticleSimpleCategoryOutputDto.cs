using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 输出文章分类
    /// </summary>
    public class ArticleSimpleCategoryOutputDto : IOutputDto
    {
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>	
        public virtual string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 别称
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }
        /// <summary>
        /// 值
        /// </summary>		
        public virtual string Value
        {
            get;
            set;
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public virtual bool CK
        {
            set;
            get;
        }
    }
}
