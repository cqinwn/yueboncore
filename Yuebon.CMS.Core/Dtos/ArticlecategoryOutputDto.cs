using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 文章分类输出对象模型
    /// </summary>
    [Serializable]
    public class ArticlecategoryOutputDto
    {
        /// <summary>
        /// 设置或获取主键
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// 设置或获取标题
        /// </summary>
        [MaxLength(100)]
        public string Title { get; set; }

        /// 设置或获取父级Id
        /// </summary>
        [MaxLength(50)]
        public string ParentId { get; set; }

        /// 设置或获取全路径
        /// </summary>
        [MaxLength(500)]
        public string ClassPath { get; set; }

        /// 设置或获取层级
        /// </summary>
        public int? ClassLayer { get; set; }

        /// 设置或获取排序
        /// </summary>
        public int SortCode { get; set; }

        /// 设置或获取描述
        /// </summary>
        public string Description { get; set; }

        /// 设置或获取外链地址
        /// </summary>
        [MaxLength(255)]
        public string LinkUrl { get; set; }

        /// 设置或获取主图图片
        /// </summary>
        [MaxLength(255)]
        public string ImgUrl { get; set; }

        /// 设置或获取SEO标题
        /// </summary>
        [MaxLength(255)]
        public string SeoTitle { get; set; }

        /// 设置或获取SEO关键词
        /// </summary>
        [MaxLength(255)]
        public string SeoKeywords { get; set; }

        /// 设置或获取SEO描述
        /// </summary>
        [MaxLength(255)]
        public string SeoDescription { get; set; }

        /// 设置或获取是否热门
        /// </summary>
        public bool? IsHot { get; set; }

        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

        /// 设置或获取删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// 设置或获取创建人
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }

        /// 设置或获取所属公司
        /// </summary>
        [MaxLength(50)]
        public string CompanyId { get; set; }

        /// 设置或获取所属部门
        /// </summary>
        [MaxLength(50)]
        public string DeptId { get; set; }

        /// 设置或获取最近修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// 设置或获取最近修改人
        /// </summary>
        [MaxLength(50)]
        public string LastModifyUserId { get; set; }

        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// 设置或获取删除人
        /// </summary>
        [MaxLength(50)]
        public string DeleteUserId { get; set; }


        /// <summary>
        /// 获取子集
        /// </summary>
        public List<ArticlecategoryOutputDto> Children { get; set; }
    }
}