using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输出对象模型
    /// </summary>
    [Serializable]
    public class UploadFileOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
        public string FileName { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(500)]
        public string FilePath { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(20)]
        public string FileType { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? FileSize { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(20)]
        public string Extension { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool EnabledMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool DeleteMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public Guid? CreatorUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CreateUserName { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime CreatorTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(500)]
        public string Thumbnail { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
        public string BelongApp { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string BelongAppId { get; set; }

    }
}
