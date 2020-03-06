using System;
using System.Collections.Generic;
using System.Text;

namespace Yuebon.Commons.Net
{
    /// <summary>
    /// 从淘宝获取IP信息
    ///
    /// </summary>
    [Serializable]
    public class TaobaoIPInfo
    {
        /// <summary>
        /// 状态码，0为正常,310请求参数信息有误，311Key格式错误,306请求有护持信息请检查字符串,110请求来源未被授权
        /// </summary>
        public string Status
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            get;
            set;
        }
        
        /// <summary>
        /// 返回数据
        /// </summary>
        public TaobaoIPDataInfo Result
        {
            get;
            set;
        }
    }
    /// <summary>
    /// 返回数据
    /// </summary>
    public class TaobaoIPDataInfo
    {
        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip
        {
            get;
            set;
        }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country
        {
            get;
            set;
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string Region
        {
            get;
            set;
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// 县区
        /// </summary>
        public string County
        {
            get;
            set;
        }
        /// <summary>
        /// 运营商
        /// </summary>
        public string Isp
        {
            get;
            set;
        }
    }

    public class LocalhostInfo
    {
        public string Province;
        public string City;
    }
}
