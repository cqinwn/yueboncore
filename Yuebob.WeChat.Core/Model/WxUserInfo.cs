using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.WeChat.Model
{
    /// <summary>
    /// 微信用户信息实体对象
    /// </summary>
   public class WxUserInfo
    {
        /// <summary>
        /// 设置或获取昵称
        /// </summary>
        public string nickName
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取用户头像图片的 URL
        /// </summary>
        public string avatarUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取用户性别
        /// </summary>
        public int gender
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取用户所在国家
        /// </summary>
        public string country
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取用户所在省份
        /// </summary>
        public string province
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取所在城市
        /// </summary>
        public string city
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取用户所在国家
        /// </summary>
        public string language
        {
            get;
            set;
        }

        /// <summary>
        /// 设置或获取用户openId
        /// </summary>
        public string openId
        {
            get;
            set;
        }

        /// <summary>
        /// 设置或获取用户openIdType
        /// </summary>
        public string openIdType
        {
            get;
            set;
        }

        /// <summary>
        /// 设置或获取推广者ReferralUserId
        /// </summary>
        public string ReferralUserId
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取包括敏感数据在内的完整用户信息的加密数据
        /// </summary>
        public string EncryptedData
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取加密算法的初始向量
        /// </summary>
        public string Iv
        {
            get;
            set;
        }
        /// <summary>
        /// 设置或获取微信登录的SessionId
        /// </summary>
        public string SessionId
        {
            get;
            set;
        }

    }
}
