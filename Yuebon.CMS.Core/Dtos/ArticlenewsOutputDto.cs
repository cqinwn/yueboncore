using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 文章，通知公告输出对象模型
    /// </summary>
    [Serializable]
    public class ArticlenewsOutputDto
    {
        /// <summary>
        /// 设置或获取主键
        /// </summary>
        [MaxLength(50)]
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取文章分类
        /// </summary>
        [MaxLength(500)]
        public long CategoryId { get; set; }

        /// <summary>
        /// 设置或获取分类名称
        /// </summary>
        [MaxLength(500)]
        public string CategoryName { get; set; }

        /// <summary>
        /// 设置或获取文章标题
        /// </summary>
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取副标题
        /// </summary>
        [MaxLength(100)]
        public string SubTitle { get; set; }

        /// <summary>
        /// 设置或获取外链
        /// </summary>
        [MaxLength(255)]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 设置或获取主图
        /// </summary>
        [MaxLength(255)]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 设置或获取SEO标题
        /// </summary>
        [MaxLength(255)]
        public string SeoTitle { get; set; }

        /// <summary>
        /// 设置或获取SEO关键词
        /// </summary>
        [MaxLength(255)]
        public string SeoKeywords { get; set; }

        /// <summary>
        /// 设置或获取SEO描述
        /// </summary>
        [MaxLength(255)]
        public string SeoDescription { get; set; }

        /// <summary>
        /// 设置或获取标签，多个用逗号隔开
        /// </summary>
        [MaxLength(500)]
        public string Tags { get; set; }

        /// <summary>
        /// 设置或获取摘要
        /// </summary>
        [MaxLength(255)]
        public string Zhaiyao { get; set; }

        /// <summary>
        /// 设置或获取详情
        /// </summary>
        [MaxLength(16777215)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取排序
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 设置或获取开启评论
        /// </summary>
        public bool? IsMsg { get; set; }

        /// <summary>
        /// 设置或获取是否置顶，默认不置顶
        /// </summary>
        public bool? IsTop { get; set; }

        /// <summary>
        /// 设置或获取是否推荐
        /// </summary>
        public bool? IsRed { get; set; }

        /// <summary>
        /// 设置或获取是否热门，默认否
        /// </summary>
        public bool? IsHot { get; set; }

        /// <summary>
        /// 设置或获取是否是系统预置文章，不可删除
        /// </summary>
        public bool? IsSys { get; set; }

        /// <summary>
        /// 设置或获取是否推荐到最新
        /// </summary>
        public bool? IsNew { get; set; }

        /// <summary>
        /// 设置或获取是否推荐到幻灯
        /// </summary>
        public bool? IsSlide { get; set; }

        /// <summary>
        /// 设置或获取点击量
        /// </summary>
        public int? Click { get; set; }

        /// <summary>
        /// 设置或获取喜欢量
        /// </summary>
        public int? LikeCount { get; set; }

        /// <summary>
        /// 设置或获取浏览量
        /// </summary>
        public int? TotalBrowse { get; set; }

        /// <summary>
        /// 设置或获取来源
        /// </summary>
        [MaxLength(50)]
        public string Source { get; set; }

        /// <summary>
        /// 设置或获取作者
        /// </summary>
        [MaxLength(50)]
        public string Author { get; set; }

        /// <summary>
        /// 设置或获取是否发布
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取逻辑删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人
        /// </summary>
        [MaxLength(50)]
        public long CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取所属公司
        /// </summary>
        [MaxLength(50)]
        public long CompanyId { get; set; }

        /// <summary>
        /// 设置或获取所属部门
        /// </summary>
        [MaxLength(50)]
        public long DeptId { get; set; }

        /// <summary>
        /// 设置或获取最近修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最近修改人
        /// </summary>
        [MaxLength(50)]
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        [MaxLength(50)]
        public string DeleteUserId { get; set; }

    }
}