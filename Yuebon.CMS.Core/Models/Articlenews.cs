using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章，通知公告，数据实体对象
    /// </summary>
    [SugarTable("CMS_Articlenews", "文章，通知公告")]
    [Serializable]
    public class Articlenews:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取文章分类Id
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "文章分类ID")]
        public long CategoryId { get; set; }

        /// <summary>
        /// 设置或获取分类名称
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "分类名称")]
        public string CategoryName { get; set; }

        /// <summary>
        /// 设置或获取文章标题
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "文章标题")]
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取副标题
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "副标题")]
        public string SubTitle { get; set; }

        /// <summary>
        /// 设置或获取外链
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "外链")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 设置或获取主图
        /// </summary>
        [MaxLength(250)]
        [SugarColumn(ColumnDescription= "主图图片地址")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 设置或获取SEO标题
        /// </summary>
        [MaxLength(120)]
        [SugarColumn(ColumnDescription= "SEO标题")]
        public string SeoTitle { get; set; }

        /// <summary>
        /// 设置或获取SEO关键词
        /// </summary>
        [MaxLength(500)]
        [SugarColumn(ColumnDescription= "SEO关键词")]
        public string SeoKeywords { get; set; }

        /// <summary>
        /// 设置或获取SEO描述
        /// </summary>
        [MaxLength(500)]
        [SugarColumn(ColumnDescription= "SEO描述")]
        public string SeoDescription { get; set; }

        /// <summary>
        /// 设置或获取标签，多个用逗号隔开
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "标签，多个用逗号隔开")]
        public string Tags { get; set; }

        /// <summary>
        /// 设置或获取摘要
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "摘要")]
        public string Zhaiyao { get; set; }

        /// <summary>
        /// 设置或获取详情
        /// </summary>
        [SugarColumn(ColumnDescription= "详情",ColumnDataType = "nvarchar(200000)")]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取排序
        /// </summary>
        [SugarColumn(ColumnDescription= "排序")]
        public int? SortCode { get; set; }

        /// <summary>
        /// 设置或获取开启评论
        /// </summary>
        [SugarColumn(ColumnDescription= "开启评论")]
        public bool? IsMsg { get; set; }

        /// <summary>
        /// 设置或获取是否置顶，默认不置顶
        /// </summary>
        [SugarColumn(ColumnDescription= "是否置顶，默认不置顶")]
        public bool? IsTop { get; set; }

        /// <summary>
        /// 设置或获取是否推荐
        /// </summary>
        [SugarColumn(ColumnDescription= "是否推荐")]
        public bool? IsRed { get; set; }

        /// <summary>
        /// 设置或获取是否热门，默认否
        /// </summary>
        [SugarColumn(ColumnDescription= "是否热门，默认否")]
        public bool? IsHot { get; set; }

        /// <summary>
        /// 设置或获取是否是系统预置文章，不可删除
        /// </summary>
        [SugarColumn(ColumnDescription= "是否是系统预置文章，不可删除")]
        public bool? IsSys { get; set; }

        /// <summary>
        /// 设置或获取是否推荐到最新
        /// </summary>
        [SugarColumn(ColumnDescription= "是否推荐到最新")]
        public bool? IsNew { get; set; }

        /// <summary>
        /// 设置或获取是否推荐到幻灯
        /// </summary>
        [SugarColumn(ColumnDescription= "是否推荐到幻灯")]
        public bool? IsSlide { get; set; }

        /// <summary>
        /// 设置或获取点击量
        /// </summary>
        [SugarColumn(ColumnDescription= "点击量")]
        public int? Click { get; set; }

        /// <summary>
        /// 设置或获取喜欢量
        /// </summary>
        [SugarColumn(ColumnDescription= "喜欢量")]
        public int? LikeCount { get; set; }

        /// <summary>
        /// 设置或获取浏览量
        /// </summary>
        [SugarColumn(ColumnDescription= "浏览量")]
        public int? TotalBrowse { get; set; }

        /// <summary>
        /// 设置或获取来源
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "来源")]
        public string Source { get; set; }

        /// <summary>
        /// 设置或获取作者
        /// </summary>
        [MaxLength(200)]
        [SugarColumn(ColumnDescription= "作者")]
        public string Author { get; set; }

        /// <summary>
        /// 设置或获取是否发布
        /// </summary>
        [SugarColumn(ColumnDescription= "是否发布")]
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取逻辑删除标志
        /// </summary>
        [SugarColumn(ColumnDescription= "逻辑删除标志")]
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [SugarColumn(ColumnDescription= "创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建用户主键
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建用户主键")]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建人公司ID")]
        public long? CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "创建人部门ID")]
        public long? DeptId { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        [SugarColumn(ColumnDescription= "最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "最后修改用户")]
        public virtual long? LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        [SugarColumn(ColumnDescription= "删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "删除用户")]
        public virtual long? DeleteUserId { get; set; }


    }
}
