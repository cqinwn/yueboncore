using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.AspNetCore.SSO
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserAuthInfo
    {
        public string sub{get;set; }
        public int auth_time { get; set; }
        public string idp { get; set; }
        public string UserId { get; set; }
        public string name { get; set; }
        public string Account { get; set; }
        public string nickname { get; set; }
        public string role { get; set; }
        public string amr { get; set; }
    }
}
