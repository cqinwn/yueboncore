using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.CodeGenerator.Dtos
{
    /// <summary>
    /// 数据库信息输出对象模型
    /// </summary>
    [Serializable]
    public class DatabaseOutputDto
    {
        /// <summary>
        /// 设置或获取编号,主键
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string Desc { get; set; }
        /// <summary>
        /// 设置或获取数据库连接
        /// </summary>
        [MaxLength(600)]
        public string Connection { get; set; }
        /// <summary>
        /// 设置或获取
        /// </summary>
        public int? DbType { get; set; }
        /// <summary>
        /// 设置或获取最后修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 设置或获取删除标志
        /// </summary>
        public bool? DeleteMark { get; set; }

    }
}
