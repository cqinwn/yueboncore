using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 操作轨迹表输入对象模型
    /// </summary>
    [AutoMap(typeof(OperateTrajectory))]
    [Serializable]
    public class OperateTrajectoryInputDto: IInputDto<string>
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
        /// 设置或获取 
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsGood { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsFavorite { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsStar { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalDuration { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalBrowse { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? TotalMsg { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? TotalDownload { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExt1 { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExt2 { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExt3 { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalExt1 { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalExt2 { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? TotalExt3 { get; set; }

    }
}
