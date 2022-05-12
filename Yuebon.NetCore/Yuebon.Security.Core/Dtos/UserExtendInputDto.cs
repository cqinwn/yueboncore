using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(UserExtend))]
    [Serializable]
    public class UserExtendInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取名片内容
        /// </summary>
        public string CardContent { get; set; }

        /// <summary>
        /// 设置或获取电话
        /// </summary>
        public string Telphone { get; set; }

        /// <summary>
        /// 设置或获取地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 设置或获取公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 设置或获取职位名称
        /// </summary>
        public string PositionTitle { get; set; }

        /// <summary>
        /// 设置或获取个人微信二维码
        /// </summary>
        public string WechatQrCode { get; set; }

        /// <summary>
        /// 设置或获取行业
        /// </summary>
        public string IndustryId { get; set; }

        /// <summary>
        /// 设置或获取隐私：0-不公开，1-公开；2-部分公开
        /// </summary>
        public int? OpenType { get; set; }

        /// <summary>
        /// 设置或获取是否允许他人转发你的名片
        /// </summary>
        public bool? IsOtherShare { get; set; }

        /// <summary>
        /// 设置或获取转发标题
        /// </summary>
        public string ShareTitle { get; set; }

        /// <summary>
        /// 设置或获取网址
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// 设置或获取公司简介
        /// </summary>
        public string CompanyDesc { get; set; }

        /// <summary>
        /// 设置或获取名片样式
        /// </summary>
        public string CardTheme { get; set; }

        /// <summary>
        /// 设置或获取Vip等级
        /// </summary>
        public string VipGrade { get; set; }

        /// <summary>
        /// 设置或获取是否认证
        /// </summary>
        public bool? IsAuthentication { get; set; }

        /// <summary>
        /// 设置或获取认证类型1-企业；2-个人
        /// </summary>
        public int? AuthenticationType { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool EnabledMark { get; set; }


    }
}
