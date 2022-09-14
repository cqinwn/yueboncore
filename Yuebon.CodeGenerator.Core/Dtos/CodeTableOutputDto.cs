namespace Yuebon.CodeGenerator.Dtos
{
    /// <summary>
    /// 表信息输出对象模型
    /// </summary>
    [Serializable]
    public class CodeTableOutputDto
    {
        /// <summary>
        /// 设置或获取编号,主键
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public int? DbId { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string ClassName { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string TableName { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? IsLock { get; set; }

    }
}
