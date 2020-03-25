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
    public class OrganizeOutputDto
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
        public string ParentId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? Layers { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string EnCode { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string FullName { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string ShortName { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CategoryId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string ManagerId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(20)]
        public string TelePhone { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(20)]
        public string MobilePhone { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string WeChat { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(20)]
        public string Fax { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string AreaId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(500)]
        public string Address { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? AllowEdit { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? AllowDelete { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? SortCode { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? EnabledMark { get; set; }
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
        [MaxLength(500)]
        public string DeleteUserId { get; set; }

    }
}
