using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 输出对象模型
    /// </summary>
    [Serializable]
    public class MemberMessageBoxOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取消息内容Id
        /// </summary>
        public long? ContentId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
        public string MsgContent { get; set; }

        /// <summary>
        /// 设置或获取发送者
        /// </summary>
        [MaxLength(100)]
        public string Sernder { get; set; }

        /// <summary>
        /// 设置或获取接受者
        /// </summary>
        [MaxLength(100)]
        public string Accepter { get; set; }

        /// <summary>
        /// 设置或获取是否已读
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? ReadDate { get; set; }


    }
}
