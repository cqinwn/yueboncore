using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Helpers;
using Yuebon.Core.Models;

namespace Yuebon.Core.Models
{
    /// <summary>
    /// string型主键实体
    /// </summary>
    public class StringEntity:Entity
    {
        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        [Column("Id")]
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "编号,主键")]
        public virtual string Id { get; set; }


        /// <summary>
        /// 判断主键是否为空
        /// </summary>
        /// <returns></returns>
        public override bool KeyIsNull()
        {
            if (Id == null)
            {
                return true;
            }
            else
            {
                return string.IsNullOrEmpty(Id.ToString());
            }
        }

        /// <summary>
        /// 创建默认的主键值
        /// </summary>
        public override void GenerateDefaultKeyVal()
        {
            Id = GuidUtils.CreateNo();
        }
    }
}
