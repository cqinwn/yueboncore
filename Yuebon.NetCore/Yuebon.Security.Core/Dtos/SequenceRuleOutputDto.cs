using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 序号编码规则表输出对象模型
    /// </summary>
    [Serializable]
    public class SequenceRuleOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取编码规则名称
        /// </summary>
        [MaxLength(200)]
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取规则排序
        /// </summary>
        public int RuleOrder { get; set; }

        /// <summary>
        /// 设置或获取规则类别，timestamp、const、bumber
        /// </summary>
        [MaxLength(200)]
        public string RuleType { get; set; }

        /// <summary>
        /// 设置或获取规则参数，如YYMMDD
        /// </summary>
        [MaxLength(200)]
        public string RuleValue { get; set; }

        /// <summary>
        /// 设置或获取补齐方向，left或right
        /// </summary>
        [MaxLength(200)]
        public string PaddingSide { get; set; }

        /// <summary>
        /// 设置或获取补齐宽度
        /// </summary>
        public int PaddingWidth { get; set; }

        /// <summary>
        /// 设置或获取填充字符
        /// </summary>
        [MaxLength(1)]
        public string PaddingChar { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取删除标记
        /// </summary>
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// 设置或获取创建时间
        /// </summary>
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 设置或获取创建人
        /// </summary>
        [MaxLength(50)]
        public long CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        [MaxLength(50)]
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取修改人
        /// </summary>
        [MaxLength(50)]
        public long LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        [MaxLength(50)]
        public long DeleteUserId { get; set; }


    }
}
