using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Security.Dtos;

namespace Yuebon.AspNetCore.SSO
{
    [Serializable]
    public class UserAuthSession
    {
        /// <summary>
        /// 授权token码
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// appkey
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string MemberGradeId { get; set; }

        /// <summary>
        /// 上级推广员
        /// </summary>
        public string ReferralUserId { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 角色编码，多个角色，使用“,”分格
        /// </summary>
        public string Role { get; set; }


        /// <summary>
        /// 手机号码
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 其他对象
        /// </summary>
        public object OtherOpenObj { get; set; }

        /// <summary>
        /// 微信登录SessionId
        /// </summary>
        public string WxSessionId { get; set; }


    }
}
