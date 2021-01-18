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
        public string[] RoleFunctios { get; set; }

        /// <summary>
        /// 设置角色可访问系统
        /// </summary>
        public string[] RoleSystem { get; set; }
        /// <summary>
        /// 设置角色可访问数据
        /// </summary>
        public string[] RoleData { get; set; }

        /// <summary>
        /// 设置角色Id
        /// </summary>
        public string RoleId { get; set; }
    }
}
