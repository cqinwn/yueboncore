using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuebon.Core.Models
{
    /// <summary>
    /// 租户实体
    /// </summary>
    public abstract class TenantEntity: BaseEntity,IMustHaveTenant
    {
        /// <summary>
        /// 设置或获取 租户
        /// </summary>
        [SugarColumn(ColumnDescription = "租户")]
        public virtual long TenantId { get; set; }
    }
}
