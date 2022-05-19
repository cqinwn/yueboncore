using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Dtos;
using Yuebon.CodeGenerator.Models;
using System.ComponentModel.DataAnnotations;

namespace Yuebon.CodeGenerator.Dtos
{
    /// <summary>
    /// 表信息输入对象模型
    /// </summary>
    [AutoMap(typeof(CodeTable))]
    [Serializable]
    public class CodeTableInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取编号,主键
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        public int? DbId { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string ClassName { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string TableName { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string Description { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        public bool? IsLock { get; set; }

    }
}
