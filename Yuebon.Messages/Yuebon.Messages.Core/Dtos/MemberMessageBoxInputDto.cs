using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(MemberMessageBox))]
    [Serializable]
    public class MemberMessageBoxInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }
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
