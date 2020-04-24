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

        /// 设置或获取 
        /// </summary>
        public string UserPassword { get; set; }

        /// 设置或获取 
        /// </summary>
        public string UserSecretkey { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? AllowStartTime { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? AllowEndTime { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? LockStartDate { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? LockEndDate { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? FirstVisitTime { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? PreviousVisitTime { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? LastVisitTime { get; set; }

        /// 设置或获取 
        /// </summary>
        public DateTime? ChangePasswordDate { get; set; }

        /// 设置或获取 
        /// </summary>
        public bool? MultiUserLogin { get; set; }

        /// 设置或获取 
        /// </summary>
        public int? LogOnCount { get; set; }

        /// 设置或获取 
        /// </summary>
        public bool? UserOnLine { get; set; }

        /// 设置或获取 
        /// </summary>
        public string Question { get; set; }

        /// 设置或获取 
        /// </summary>
        public string AnswerQuestion { get; set; }

        /// 设置或获取 
        /// </summary>
        public bool? CheckIPAddress { get; set; }

        /// 设置或获取 
        /// </summary>
        public string Language { get; set; }

        /// 设置或获取 
        /// </summary>
        public string Theme { get; set; }

    }
}