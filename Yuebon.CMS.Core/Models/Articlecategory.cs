using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章分类，数据实体对象
    /// </summary>
    [Table("cms_articlecategory")]
    [Serializable]
    public class Articlecategory:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 设置或获取全路径
        /// </summary>
        public string ClassPath { get; set; }

        /// <summary>
        /// 设置或获取层级
        /// </summary>
        public int? ClassLayer { get; set; }

        /// <summary>
        /// 设置或获取排序
        /// </summary>
        public int SortCode { get; set; }


        /// <summary>
        /// 设置或获取外链地址
        /// </summary>
        public string LinkUrl { get; set; }

        /// <summary>
        /// 设置或获取主图图片
        /// </summary>
        public string ImgUrl { get; set; }

        /// <summary>
        /// 设置或获取SEO标题
        /// </summary>
        public string SeoTitle { get; set; }

        /// <summary>
        /// 设置或获取SEO关键词
        /// </summary>
        public string SeoKeywords { get; set; }

        /// <summary>
        /// 设置或获取SEO描述
        /// </summary>
        public string SeoDescription { get; set; }

        /// <summary>
        /// 设置或获取是否热门
        /// </summary>
        public bool? IsHot { get; set; }

        /// <summary>
        /// 设置或获取描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人
        /// </summary>
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取所属公司
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取所属部门
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取最近修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取最近修改人
        /// </summary>
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        public string DeleteUserId { get; set; }


    }
}
