using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Dtos;
using Yuebon.CMS.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 文章分类输入对象模型
    /// </summary>
    [AutoMap(typeof(Articlecategory))]
    [Serializable]
    public class ArticlecategoryInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取主键
        /// </summary>
        public string Id { get; set; }

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
        /// 设置或获取描述
        /// </summary>
        public string Description { get; set; }

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
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }


    }
}
