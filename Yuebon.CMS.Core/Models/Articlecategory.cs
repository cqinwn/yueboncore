using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章分类，数据实体对象
    /// </summary>
    [Table("CMS_Articlecategory")]
    [Comment("文章分类")]
    [Serializable]
    public class Articlecategory:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取标题
        /// </summary>
        [MaxLength(200)]
        [Comment("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        [MaxLength(50)]
        [Comment("父级Id")]
        public string ParentId { get; set; }

        /// <summary>
        /// 设置或获取全路径
        /// </summary>
        [MaxLength(200)]
        [Comment("全路径")]
        public string ClassPath { get; set; }

        /// <summary>
        /// 设置或获取层级
        /// </summary>
        [Comment("层级")]
        public int? ClassLayer { get; set; }

        /// <summary>
        /// 设置或获取排序
        /// </summary>
        [Comment("排序")]
        public int? SortCode { get; set; }


        /// <summary>
        /// 设置或获取外链地址
        /// </summary>
        [MaxLength(200)]
        [Comment("外链地址")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 设置或获取主图图片地址
        /// </summary>
        [MaxLength(250)]
        [Comment("主图图片地址")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// 设置或获取SEO标题
        /// </summary>
        [MaxLength(120)]
        [Comment("SEO标题")]
        public string SeoTitle { get; set; }

        /// <summary>
        /// 设置或获取SEO关键词
        /// </summary>
        [MaxLength(500)]
        [Comment("SEO关键词")]
        public string SeoKeywords { get; set; }

        /// <summary>
        /// 设置或获取SEO描述
        /// </summary>
        [MaxLength(500)]
        [Comment("SEO描述")]
        public string SeoDescription { get; set; }

        /// <summary>
        /// 设置或获取是否热门
        /// </summary>
        [Comment("是否热门")]
        public bool? IsHot { get; set; }

        /// <summary>
        /// 设置或获取描述
        /// </summary>
        [Comment("描述")]
        public virtual string Description { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人公司ID")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人部门ID")]
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Comment("创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        [Comment("最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改用户
        /// </summary>
        [MaxLength(50)]
        [Comment("最后修改用户")]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        [Comment("删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除用户
        /// </summary>
        [MaxLength(50)]
        [Comment("删除用户")]
        public virtual string DeleteUserId { get; set; }


    }
}
