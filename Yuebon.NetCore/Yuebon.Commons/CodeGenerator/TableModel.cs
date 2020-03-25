using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.CodeGenerator
{
    /// <summary>
    /// 表内容模型
    /// </summary>
    public class TableModel
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 字段序号
        /// </summary>
        public string FieldColorder { get; set; }


        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string IsIdentity { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string Pkey { get; set; }
        /// <summary>
        /// 字段数据类型
        /// </summary>
        public string FieldDataType { get; set; }
        /// <summary>
        /// 字段长度
        /// </summary>
        public string FieldLength { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public string FieldDecimalDigit { get; set; }
        /// <summary>
        /// 是否可以为空
        /// </summary>
        public string FieldIsNull { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string FieldDefaultValue { get; set; }
        /// <summary>
        /// 字段描述
        /// </summary>
        public string FieldDescription { get; set; }
    }
}
