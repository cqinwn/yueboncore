using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Net.TencentIp;

namespace Yuebon.Commons.Net
{
    /// <summary>
    /// IP地址
    /// </summary>
    public class IpAddressUtil
    {
        /// <summary>
        /// Ip地址段是否包含另外一个IP地址
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
        /// Ip地址集合是否包含另外一个IP地址
        /// </summary>
        /// <param name="ipRules">Ip地址集合List</param>
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
        /// Ip地址集合是否包含另外一个IP地址
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
        /// 是否为ip
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
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
                TencentIpResult ipResult = jsonText.ToObject<TencentIpResult>();
                if (ipResult.status == 0)
                {
                    string nation = ipResult.result.ad_info.nation.ToString();//国家
                    string province = ipResult.result.ad_info.province.ToString();//省份
                    string city = ipResult.result.ad_info.city.ToString();//城市
                    string district = ipResult.result.ad_info.district.ToString();//区/县
                    string adcode = ipResult.result.ad_info.adcode.ToString();//行政区划代码
                    string resultStr = "";
                    if (nation is { Length: > 0 })
                    {
                        resultStr += nation;
                    }
                    if (province is { Length: > 0 })
                    {
                        resultStr += province;
                    }
                    if (city is { Length: > 0 })
                    {
                        resultStr += city;
                    }
                    if (district is { Length: > 0 })
                    {
                        resultStr += district;
                    }
                    return resultStr;
                }
                else
                {
                    Log4NetHelper.Error(strIP + "获取地区接口调用异常。" + ipResult.message);
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
