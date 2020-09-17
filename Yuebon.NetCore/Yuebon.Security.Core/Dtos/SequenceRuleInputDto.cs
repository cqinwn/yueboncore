using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 序号编码规则表输入对象模型
    /// </summary>
    [AutoMap(typeof(SequenceRule))]
    [Serializable]
    public class SequenceRuleInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取编码规则名称
        /// </summary>
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取规则排序
        /// </summary>
        public int RuleOrder { get; set; }

        /// <summary>
        /// 设置或获取规则类别，timestamp、const、bumber
        /// </summary>
        public string RuleType { get; set; }

        /// <summary>
        /// 设置或获取规则参数，如YYMMDD
        /// </summary>
        public string RuleValue { get; set; }

        /// <summary>
        /// 设置或获取补齐方向，left或right
        /// </summary>
        public string PaddingSide { get; set; }

        /// <summary>
        /// 设置或获取补齐宽度
        /// </summary>
        public int PaddingWidth { get; set; }

        /// <summary>
        /// 设置或获取填充字符
        /// </summary>
        public string PaddingChar { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool EnabledMark { get; set; }


    }
}
