using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    public class PageCategoryInputDto : IInputDto<string>
    {
        #region Property PageCategory
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
		/// 标题
        /// </summary>	
        public virtual string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 父级ID
        /// </summary>	
        public virtual string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// 分类路径
        /// </summary>		
        public virtual string ClassPath
        {
            get;
            set;
        }
        /// <summary>
        /// 第几级
        /// </summary>		
        public virtual int ClassLayer
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public virtual int SortId
        {
            get;
            set;
        }
        /// <summary>
        /// 描述
        /// </summary>	
        public virtual string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 链接
        /// </summary>		
        public virtual string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 图片URL
        /// </summary>	
        public virtual string ImgUrl
        {
            get;
            set;
        }
        /// <summary>
        /// SEO标题
        /// </summary>	
        public virtual string SeoTitle
        {
            get;
            set;
        }
        /// <summary>
        /// Seo关键词
        /// </summary>		
        public virtual string SeoKeywords
        {
            get;
            set;
        }
        /// <summary>
        /// Seo描述
        /// </summary>		
        public virtual string SeoDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 有效标志
        /// </summary>		
        public virtual bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// 删除标志
        /// </summary>		
        public virtual bool? DeleteMark
        {
            get;
            set;
        }
        /// <summary>
        /// 创建时间
        /// </summary>		
        public virtual DateTime? CreatorTime
        {
            get;
            set;
        }
        /// <summary>
        /// 创建人
        /// </summary>		
        public virtual string CreatorUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 公司ID
        /// </summary>		
        public virtual string CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 部门
        /// </summary>		
        public virtual string DeptId
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次修改时间
        /// </summary>		
        public virtual DateTime? LastModifyTime
        {
            get;
            set;
        }
        /// <summary>
        /// 最后一次修改人
        /// </summary>		
        public virtual string LastModifyUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 删除时间
        /// </summary>		
        public virtual DateTime? DeleteTime
        {
            get;
            set;
        }
        /// <summary>
        /// 删除人
        /// </summary>	
        public virtual string DeleteUserId
        {
            get;
            set;
        }
        #endregion
    }
}
