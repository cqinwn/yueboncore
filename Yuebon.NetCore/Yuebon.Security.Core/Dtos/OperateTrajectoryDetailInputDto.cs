using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 商操作轨迹明细表输入对象模型
    /// </summary>
    [AutoMap(typeof(OperateTrajectoryDetail))]
    [Serializable]
    public class OperateTrajectoryDetailInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ContentId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string ContentTitle { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string AuthorUserId { get; set; }
        /// <summary>
        /// 设置或获取内容类型：商机-opp,文章：art；文库：doc
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 设置或获取离开时间
        /// </summary>
        public DateTime? LeaveTime { get; set; }
        /// <summary>
        /// 设置或获取访问时长，精确到秒
        /// </summary>
        public int? Duration { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string OperateType { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool IsSendMSg { get; set; }

    }
}
