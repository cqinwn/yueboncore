using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 包括用户及用户可访问的机构/资源/模块/角色
    /// </summary>
    public class UserWithAccessedCtrls
    {

        public UserLoginDto User { get; set; }
        /// <summary>
        /// 用户可以访问到的模块（包括所属角色与自己的所有模块）
        /// </summary>
        public List<FunctionOutputDto> Modules { get; set; }

        /// <summary>
        /// 用户可以访问的资源
        /// </summary>
        public List<RoleData> RoleDatas { get; set; }

        /// <summary>
        ///  用户所属机构
        /// </summary>
        public List<Organize> Organizes { get; set; }

        /// <summary>
        /// 用户所属角色
        /// </summary>
        public List<Role> Roles { get; set; }
    }
}
