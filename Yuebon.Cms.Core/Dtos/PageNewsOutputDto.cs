using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 单页面管理输出Dto
    /// </summary>
    [Serializable]
    public class PageNewsOutputDto : IOutputDto
    {
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public PageNewsOutputDto()
        { }

        #region Property PageNews
        /// <summary>
        /// 主键
        /// </summary>
        public  string Id { get; set; }
        /// <summary>
		/// 标题
        /// </summary>	
        public  string Title
        {
            get;
            set;
        }
        /// <summary>
		/// 副标题
        /// </summary>	
        public  string SubTitle
        {
            get;
            set;
        }
        /// <summary>
		/// 分类编号
        /// </summary>		
        public  string CategoryId
        {
            get;
            set;
        }
        /// <summary>
		/// 分类名称
        /// </summary>		
        public  string CategoryName
        {
            get;
            set;
        }
        /// <summary>
        /// 外链
        /// </summary>		
        public  string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 主图URL
        /// </summary>		
        public  string ImgUrl
        {
            get;
            set;
        }
        /// <summary>
        /// SEO标题
        /// </summary>		
        public  string SeoTitle
        {
            get;
            set;
        }
        /// <summary>
        /// SEO关键词
        /// </summary>		
        public  string SeoKeywords
        {
            get;
            set;
        }
        /// <summary>
        /// SEO描述
        /// </summary>	
        public  string SeoDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 标签
        /// </summary>	
        public  string Tags
        {
            get;
            set;
        }
        /// <summary>
        /// 摘要
        /// </summary>		
        public  string Zhaiyao
        {
            get;
            set;
        }
        /// <summary>
        /// 详细内容
        /// </summary>		
        public  string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public  int? SortCode
        {
            get;
            set;
        }
        /// <summary>
        /// 是否开启评论
        /// </summary>		
        public  bool IsMsg
        {
            get;
            set;
        }
        /// <summary>
        /// 是否置顶
        /// </summary>		
        public  bool IsTop
        {
            get;
            set;
        }
        /// <summary>
        /// 是否推荐
        /// </summary>		
        public  bool IsRed
        {
            get;
            set;
        }
        /// <summary>
        /// 是否热门
        /// </summary>		
        public  bool IsHot
        {
            get;
            set;
        }
        /// <summary>
        /// 是否是幻灯
        /// </summary>		
        public  bool IsSlide
        {
            get;
            set;
        }
        /// <summary>
        /// 是否系统文章
        /// </summary>		
        public  bool IsSys
        {
            get;
            set;
        }
        /// <summary>
        /// 是否最新
        /// </summary>		
        public  bool IsNew
        {
            get;
            set;
        }
        /// <summary>
        /// 点击量
        /// </summary>		
        public  int Click
        {
            get;
            set;
        }
        /// <summary>
        /// 喜欢数量
        /// </summary>		
        public  int LikeCount
        {
            get;
            set;
        }

        /// <summary>
        /// 有效标志
        /// </summary>		
        public  bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// Source
        /// </summary>		
        public  string Source
        {
            get;
            set;
        }
        /// <summary>
        /// 作者
        /// </summary>		
        public  string Author
        {
            get;
            set;
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public  bool? DeleteMark { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public  DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public  string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        public  string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        public  string DeptId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public  DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public  string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public  DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public  string DeleteUserId { get; set; }
        #endregion
    }
}
