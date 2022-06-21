namespace Yuebon.CMS.Dtos
{
    [Serializable]
    public class CategoryArticleOutputDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///  子标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentId { get; set; }

        public List<CategoryArticleOutputDto> Children { get; set; }
    }
}
