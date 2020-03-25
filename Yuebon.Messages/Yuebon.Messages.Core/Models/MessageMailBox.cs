using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// ，数据实体对象
    /// </summary>
    [Table("Sys_MessageMailBox")]
    [Serializable]
    public class MessageMailBox:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 设置或获取是否短信提醒
        /// </summary>
        public bool? IsMsgRemind { get; set; }
        /// <summary>
        /// 设置或获取是否发送
        /// </summary>
        public bool? IsSend { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime SendDate { get; set; }
        /// <summary>
        /// 设置或获取是否是强制消息
        /// </summary>
        public bool? IsCompel { get; set; }
        /// <summary>
        /// 设置或获取是否发送
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string DeleteUserId { get; set; }

    }
}
