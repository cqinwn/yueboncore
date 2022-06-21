using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 定义多租户实体信息
    /// </summary>
    public interface IMustHaveTenant
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        long TenantId {
            get;
            set;
        }
    }
}
