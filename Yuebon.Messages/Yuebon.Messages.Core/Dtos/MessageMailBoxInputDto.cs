using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Models;
using Yuebon.Messages.Models;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(MessageMailBox))]
    [Serializable]
    public class MessageMailBoxInputDto: IInputDto
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


    }
}
