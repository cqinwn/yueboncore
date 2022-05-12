using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 单据编码输出对象模型
    /// </summary>
    [Serializable]
    public class SequenceOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取名称
        /// </summary>
        [MaxLength(50)]
        public string SequenceName { get; set; }

        /// <summary>
        /// 设置或获取分隔符
        /// </summary>
        [MaxLength(50)]
        public string SequenceDelimiter { get; set; }

        /// <summary>
        /// 设置或获取序号重置规则
        /// </summary>
        [MaxLength(50)]
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
        [MaxLength(200)]
        public string CurrentCode { get; set; }

        /// <summary>
        /// 设置或获取当前重置依赖
        /// </summary>
        [MaxLength(50)]
        public string CurrentReset { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(200)]
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
