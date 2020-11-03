using System;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// ，数据实体对象
    /// </summary>
    [Table("Sys_MemberMessageBox")]
    [Serializable]
    public class MemberMessageBox:BaseEntity<string>
    {
        /// <summary>
        /// 设置或获取消息内容Id
        /// </summary>
        public long? ContentId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string MsgContent { get; set; }

        /// <summary>
        /// 设置或获取发送者
        /// </summary>
        public string Sernder { get; set; }

        /// <summary>
        /// 设置或获取接受者
        /// </summary>
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
