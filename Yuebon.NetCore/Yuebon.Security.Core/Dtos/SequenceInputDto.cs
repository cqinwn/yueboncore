using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 单据编码输入对象模型
    /// </summary>
    [AutoMap(typeof(Sequence))]
    [Serializable]
    public class SequenceInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// 设置或获取名称
        /// </summary>
        public string SequenceName { get; set; }

        /// 设置或获取分隔符
        /// </summary>
        public string SequenceDelimiter { get; set; }

        /// 设置或获取序号重置规则
        /// </summary>
        public string SequenceReset { get; set; }

        /// 设置或获取步长
        /// </summary>
        public int Step { get; set; }

        /// 设置或获取当前值
        /// </summary>
        public int CurrentNo { get; set; }

        /// 设置或获取当前编码
        /// </summary>
        public string CurrentCode { get; set; }

        /// 设置或获取当前重置依赖
        /// </summary>
        public string CurrentReset { get; set; }

        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }

        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }

    }
}