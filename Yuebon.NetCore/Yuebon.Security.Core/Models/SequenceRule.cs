using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using Yuebon.Commons.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 序号编码规则表，数据实体对象
    /// </summary>
    [Table("Sys_SequenceRule")]
    [Serializable]
    public class SequenceRule:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
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
        public string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取部门
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 设置或获取修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 设置或获取修改人
        /// </summary>
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// 设置或获取删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 设置或获取删除人
        /// </summary>
        public string DeleteUserId { get; set; }


    }
}
