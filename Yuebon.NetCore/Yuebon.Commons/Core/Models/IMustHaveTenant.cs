using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Core.Models
{
    /// <summary>
    /// 多租户实体接口
    /// </summary>
    public interface IMustHaveTenant
    {
        /// <summary>
        /// 租户Id
        /// </summary>
        string TenantId {
            get;
            set;
        }
    }
}
