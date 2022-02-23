using AutoMapper;
using System;
using Yuebon.Commons.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 单据编码输入对象模型
    /// </summary>
    [AutoMap(typeof(Sequence))]
    [Serializable]
    public class SequenceInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取名称
        /// </summary>
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取分隔符
        /// </summary>
        public string SequenceDelimiter { get; set; }

        /// <summary>
        /// 设置或获取序号重置规则
        /// </summary>
        public string SequenceReset { get; set; }

        /// <summary>
        /// 设置或获取步长
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        /// 设置或获取当前值
        /// </summary>
        public int CurrentNo { get; set; }

        /// <summary>
        /// 设置或获取当前编码
        /// </summary>
        public string CurrentCode { get; set; }

        /// <summary>
        /// 设置或获取当前重置依赖
        /// </summary>
        public string CurrentReset { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool? EnabledMark { get; set; }
    }
}
