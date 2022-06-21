using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.CodeGenerator.Dtos
{
    /// <summary>
    /// 表字段输出对象模型
    /// </summary>
    [Serializable]
    public class CodeColumnsOutputDto
    {
        /// <summary>
        /// 设置或获取编号,主键
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string ClassProperName { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string DbColumnName { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? Required { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? IsIdentity { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? IsPrimaryKey { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string CodeType { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public long? CodeTableId { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string DefaultValue { get; set; }

    }
}
