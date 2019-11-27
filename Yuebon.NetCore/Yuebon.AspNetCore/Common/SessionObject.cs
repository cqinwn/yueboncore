using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Common
{ 
    /// <summary>
    /// SessionObject是登录之后，给客户端传回的对象
    /// </summary>
    public class SessionObject
    {
        /// <summary>
        /// SessionKey
        /// </summary>
        public string SessionKey { get; set; }
        /// <summary>
        /// 当前登录的用户的信息
        /// </summary>
        public User LogonUser { get; set; }
    }
}
