using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{

    /// <summary>
    /// 用户搜索条件
    /// </summary>
    public class SearchUserModel : SearchInputDto<User>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public string RoleId
        {
            get; set;
        }
        /// <summary>
        /// 注册或添加时间 开始
        /// </summary>
        public string CreatorTime1
        {
            get; set;
        }
        /// <summary>
        /// 注册或添加时间 结束
        /// </summary>
        public string CreatorTime2
        {
            get; set;
        }

    }
}
