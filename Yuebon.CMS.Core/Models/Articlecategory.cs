using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章分类，数据实体对象
    /// </summary>
    [SugarTable("CMS_Articlecategory","文章分类")]
    [Serializable]
    public class Articlecategory:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取标题
        /// </summary>
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        [MaxLength(50)]
        public long ParentId { get; set; }

        /// <summary>
        /// 设置或获取全路径
        /// </summary>
        [MaxLength(200)]
        public string ClassPath { get; set; }

        /// <summary>
        /// 设置或获取层级
        /// </summary>
        public int? ClassLayer { get; set; }

        /// <summary>
        /// 设置或获取排序
        /// </summary>
        public int? SortCode { get; set; }


        /// <summary>
        /// 设置或获取外链地址
        /// </summary>
        [MaxLength(200)]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 设置或获取主图图片地址
        /// </summary>
        [MaxLength(250)]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 设置或获取SEO标题
        /// </summary>
        [MaxLength(120)]
        public string SeoTitle { get; set; }

        /// <summary>
        /// 设置或获取SEO关键词
        /// </summary>
        [MaxLength(500)]
        public string SeoKeywords { get; set; }

        /// <summary>
        /// 设置或获取SEO描述
        /// </summary>
        [MaxLength(500)]
        public string SeoDescription { get; set; }

        /// <summary>
        /// 设置或获取是否热门
        /// </summary>
        public bool? IsHot { get; set; }

        /// <summary>
        /// 设置或获取描述
        /// </summary>
        [SugarColumn(ColumnDescription = "描述", ColumnDataType = "nvarchar(10000)")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        public long? CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        public long? DeptId { get; set; }

        /// <summary>
        /// 设置或获取删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取有效标志
        /// </summary>
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual long? CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改用户
        /// </summary>
        [MaxLength(50)]
        public virtual long? LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除用户
        /// </summary>
        [MaxLength(50)]
        [SugarColumn(ColumnDescription= "删除用户")]
        public virtual long? DeleteUserId { get; set; }


    }
}
