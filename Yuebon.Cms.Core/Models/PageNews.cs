using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章表，数据实体对象
    /// </summary>
    [Table("CMS_PageNews")]
    [Serializable]
    public class PageNews : BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PageNews()
        { }

        #region Property PageNews

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
		/// 副标题
        /// </summary>	
        [MaxLength(256)]
        public virtual string SubTitle
        {
            get;
            set;
        }
        /// <summary>
		/// 分类编号
        /// </summary>		
        public virtual string CategoryId
        {
            get;
            set;
        }
        /// <summary>
        /// 外链
        /// </summary>		
        [MaxLength(256)]
        public virtual string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 主图URL
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
        /// SEO关键词
        /// </summary>		
        [MaxLength(256)]
        public virtual string SeoKeywords
        {
            get;
            set;
        }
        /// <summary>
        /// SEO描述
        /// </summary>		
        [MaxLength(256)]
        public virtual string SeoDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 标签
        /// </summary>		
        [MaxLength(256)]
        public virtual string Tags
        {
            get;
            set;
        }
        /// <summary>
        /// 摘要
        /// </summary>		
        [MaxLength(256)]
        public virtual string Zhaiyao
        {
            get;
            set;
        }
        /// <summary>
        /// 详细内容
        /// </summary>		
        public virtual string Description
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
        /// 是否开启评论
        /// </summary>		
        public virtual bool IsMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 是否置顶
        /// </summary>		
        public virtual bool IsTop
        {
            get;
            set;
        }
        /// <summary>
        /// 是否推荐
        /// </summary>		
        public virtual bool IsRed
        {
            get;
            set;
        }
        /// <summary>
        /// 是否热门
        /// </summary>		
        public virtual bool IsHot
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是幻灯
        /// </summary>		
        public virtual bool IsSlide
        {
            get;
            set;
        }
        /// <summary>
        /// 是否系统文章
        /// </summary>		
        public virtual bool IsSys
        {
            get;
            set;
        }
        /// <summary>
        /// 点击量
        /// </summary>		
        public virtual int Click
        {
            get;
            set;
        }
        /// <summary>
        /// 喜欢数量
        /// </summary>		
        public virtual int LikeCount
        {
            get;
            set;
        }

        /// <summary>
        /// 来源
        /// </summary>		
        public virtual string Source
        {
            get;
            set;
        }
        /// <summary>
        /// 作者
        /// </summary>		
        public virtual string Author
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
        public virtual bool? DeleteMark { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        [MaxLength(50)]
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        public virtual string DeleteUserId { get; set; }
        #endregion
    }
}
