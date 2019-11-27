using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 页面分类表，数据实体对象
    /// </summary>
    [Table("CMS_PageCategory")]
    [Serializable]
    public class PageCategory : BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PageCategory()
        { }

        #region Property PageCategory

        /// <summary>
		/// 标题
        /// </summary>	
        [MaxLength(256)]
        public virtual string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 父级ID
        /// </summary>	
        [MaxLength(50)]
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
        public virtual int? SortCode
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
        [MaxLength(256)]
        public virtual string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 图片URL
        /// </summary>		
        [MaxLength(256)]
        public virtual string ImgUrl
        {
            get;
            set;
        }
        /// <summary>
        /// SEO标题
        /// </summary>		
        [MaxLength(256)]
        public virtual string SeoTitle
        {
            get;
            set;
        }
        /// <summary>
        /// Seo关键词
        /// </summary>		
        [MaxLength(256)]
        public virtual string SeoKeywords
        {
            get;
            set;
        }
        /// <summary>
        /// Seo描述
        /// </summary>		
        [MaxLength(256)]
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
        [MaxLength(50)]
        public virtual string CreatorUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 公司ID
        /// </summary>		
        [MaxLength(50)]
        public virtual string CompanyId
        {
            get;
            set;
        }
        /// <summary>
        /// 部门
        /// </summary>		
        [MaxLength(50)]
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
        [MaxLength(50)]
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
        [MaxLength(50)]
        public virtual string DeleteUserId
        {
            get;
            set;
        }
        #endregion
    }
}
