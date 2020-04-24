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
    public class RoleAuthorizeOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// 设置或获取 
        /// </summary>
        public int? ItemType { get; set; }

        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string ItemId { get; set; }

        /// 设置或获取 
        /// </summary>
        public int? ObjectType { get; set; }

        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string ObjectId { get; set; }

        /// 设置或获取 
        /// </summary>
        public int? SortCode { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }

    }
}