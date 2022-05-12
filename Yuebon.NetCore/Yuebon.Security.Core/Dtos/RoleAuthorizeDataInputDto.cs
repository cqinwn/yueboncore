using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 角色授权输入模型
    /// </summary>
    [Serializable]
    public class RoleAuthorizeDataInputDto
    {
        /// <summary>
        /// 设置角色功能
        /// </summary>
        public long[] RoleFunctios { get; set; }

        /// <summary>
        /// 设置角色可访问系统
        /// </summary>
        public long[] RoleSystem { get; set; }
        /// <summary>
        /// 设置角色可访问数据
        /// </summary>
        public long[] RoleData { get; set; }

        /// <summary>
        /// 设置角色Id
        /// </summary>
        public long RoleId { get; set; }
    }
}
