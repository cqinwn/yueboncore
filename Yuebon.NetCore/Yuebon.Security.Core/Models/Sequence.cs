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
    /// 单据编码，数据实体对象
    /// </summary>
    [Table("Sys_Sequence")]
    [Serializable]
    public class Sequence:BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
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
