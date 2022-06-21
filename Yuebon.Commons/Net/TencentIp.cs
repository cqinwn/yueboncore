namespace Yuebon.Commons.Net.TencentIp
{
    /// <summary>
    /// 通过终端设备IP地址获取其当前所在地理位置，精确到市级，常用于显示当地城市天气预报、初始化用户城市等非精确定位场景。
    /// 响应结果
    /// </summary>
    public class TencentIpResult
    {
        /// <summary>
        /// 状态状态码，
        /// 0为正常,
        /// 310请求参数信息有误，
        /// 311Key格式错误,
        /// 306请求有护持信息请检查字符串,
        /// 110请求来源未被授权
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 对status的描述
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// IP定位结果
        /// </summary>
        public IpResult result { get; set; }

    }
    /// <summary>
    /// IP定位结果
    /// </summary>
    public class IpResult
    {
        /// <summary>
        /// 用于定位的IP地址
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 定位坐标
        /// </summary>
        public Location location { get; set; }
        /// <summary>
        /// 定位行政区划信息
        /// </summary>
        public Adinfo ad_info { get; set; }

    }
    /// <summary>
    /// 定位坐标
    /// </summary>
    public class Location
    {
        /// <summary>
        /// 纬度
        /// </summary>
        public decimal lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public decimal lng { get; set; }

    }
    /// <summary>
    /// 定位行政区划信息
    /// </summary>
    public class Adinfo
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string nation { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string district { get; set; }
        /// <summary>
        /// 行政区划代码
        /// </summary>
        public int adcode { get; set; }

    }
}
