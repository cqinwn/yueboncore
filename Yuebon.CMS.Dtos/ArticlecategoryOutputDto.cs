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

        /// <summary>
        /// 设置或获取标题
        /// </summary>
        [MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取父级Id
        /// </summary>
        [MaxLength(50)]
        public string ParentId { get; set; }

        /// <summary>
        /// 设置或获取全路径
        /// </summary>
        [MaxLength(500)]
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
        [MaxLength(255)]
        public string LinkUrl { get; set; }

        /// <summary>
        /// 设置或获取主图图片
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
        /// 设置或获取是否热门
        /// </summary>
        public bool? IsHot { get; set; }

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

        /// <summary>
        /// 获取子集
        /// </summary>
        public List<ArticlecategoryOutputDto> Children { get; set; }
    }
}
