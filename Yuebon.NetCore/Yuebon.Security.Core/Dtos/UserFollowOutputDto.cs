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
    public class UserFollowOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取关注用户Id
        /// </summary>
        [MaxLength(50)]
        public string UserId { get; set; }
        /// <summary>
        /// 设置或获取被关注用户Id
        /// </summary>
        [MaxLength(50)]
        public string FollowUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? CreatorTime { get; set; }

    }
}
