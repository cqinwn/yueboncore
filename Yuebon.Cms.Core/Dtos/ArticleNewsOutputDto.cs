using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.CMS.Dtos
{
    [Serializable]
    public class ArticleNewsOutputDto
    {
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public ArticleNewsOutputDto()
        { }

        #region Property ArticleNews
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
        public bool IsNew
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

        /// <summary>
        /// 姓名
        /// </summary>
        public  string RealName
        {
            set;
            get;
        }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            set;
            get;
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account
        {
            set;
            get;
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string MobilePhone
        {
            set;
            get;
        }
        /// <summary>
        /// 头像 
        /// </summary>
        public string HeadIcon
        {
            set;
            get;
        }

        /// <summary>
        /// 扩展字段: 
        /// </summary>
        public  string ifGood
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public  string ShowAddTime
        {
            set;
            get;
        }


        /// <summary>
        /// 数据条数
        /// </summary>
        public  int? RecordCount
        {
            set;
            get;
        }


        /// <summary>
        /// 总点赞量
        /// </summary>
        public  int? TotalGood { get; set; }

        /// <summary>
        /// 总评论量
        /// </summary>
        public  int? TotalMsg { get; set; }

        /// <summary>
        /// 总浏览
        /// </summary>
        public  int? TotalBrowse { get; set; }

        /// <summary>
        /// 总喜欢量
        /// </summary>
        public  int? TotalFavorite { get; set; }

        /// <summary>
        /// 星级评分
        /// </summary>
        public  decimal? StarScore { get; set; }

        /// <summary>
        /// 额外星级分数
        /// </summary>	
        public  decimal? ExtratStarScore { get; set; }
        #endregion
    }
}
