using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;

namespace Yuebon.Commons.Net
{
    /// <summary>
    /// IP地址
    /// </summary>
    public class IpAddressUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="clientIp"></param>
        /// <returns></returns>
        public static bool ContainsIp(string rule, string clientIp)
        {
            var ip = ParseIp(clientIp);

            var range = new IpAddressRange(rule);
            if (range.Contains(ip))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipRules"></param>
        /// <param name="clientIp"></param>
        /// <returns></returns>
        public static bool ContainsIp(List<string> ipRules, string clientIp)
        {
            var ip = ParseIp(clientIp);
            if (ipRules != null && ipRules.Any())
            {
                foreach (var rule in ipRules)
                {
                    var range = new IpAddressRange(rule);
                    if (range.Contains(ip))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipRules"></param>
        /// <param name="clientIp"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool ContainsIp(List<string> ipRules, string clientIp, out string rule)
        {
            rule = null;
            var ip = ParseIp(clientIp);
            if (ipRules != null && ipRules.Any())
            {
                foreach (var r in ipRules)
                {
                    var range = new IpAddressRange(r);
                    if (range.Contains(ip))
                    {
                        rule = r;
                        return true;
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public static IPAddress ParseIp(string ipAddress)
        {
            return IPAddress.Parse(ipAddress);
        }
        /// <summary>
        /// 根据腾讯地图接口查询IP所属地区
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public static string GetCityByIp(string strIP)
        {
            try
            {
                string url = "https://apis.map.qq.com/ws/location/v1/ip?ip="+ strIP+"&key=Y6VBZ-CFZ2D-Q6A4K-HOCK4-VA3MT-UCFK6";
                string jsonText = HttpRequestHelper.HttpGet(url);
                JObject jo = JObject.Parse(jsonText);
                if (jo["status"].ToString() == "0")
                {
                    var nation = jo["result"]["ad_info"]["nation"].ToString();
                    var province = jo["result"]["ad_info"]["province"].ToString();
                    var city = jo["result"]["ad_info"]["city"].ToString();
                    var district = jo["result"]["ad_info"]["district"].ToString();
                    var adcode = jo["result"]["ad_info"]["adcode"].ToString();
                    if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city))
                    {
                        return "未知";

                    }
                    return nation + province + city + district;
                }
                else
                {
                    return "未知";
                }
            }
            catch(Exception ex)
            {
                Log4NetHelper.Error(strIP+"获取地区异常。"+ex.Message);
                return "未知";
            }
        }
    }
}
