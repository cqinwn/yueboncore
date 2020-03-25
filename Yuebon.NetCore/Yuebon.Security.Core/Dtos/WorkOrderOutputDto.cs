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
    public class WorkOrderOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Category { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(256)]
        public string SecretContent { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(256)]
        public string Mobile { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(256)]
        public string Attachment { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(256)]
        public string Customer { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(1)]
        public string Status { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string DeleteUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CompanyId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string DeptId { get; set; }

    }
}
