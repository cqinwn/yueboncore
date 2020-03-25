using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(UserLogOn))]
    [Serializable]
    public class UserLogOnInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string UserSecretkey { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? AllowStartTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? AllowEndTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? LockStartDate { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? LockEndDate { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? FirstVisitTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? PreviousVisitTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? LastVisitTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? ChangePasswordDate { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? MultiUserLogin { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? LogOnCount { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? UserOnLine { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string AnswerQuestion { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? CheckIPAddress { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Theme { get; set; }

    }
}
