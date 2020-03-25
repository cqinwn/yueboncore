using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输出对象模型
    /// </summary>
    [Serializable]
    public class UserExtendOutputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取用户Id
        /// </summary>
        [MaxLength(50)]
        public string UserId { get; set; }
        /// <summary>
        /// 设置或获取名片内容
        /// </summary>
        [MaxLength(2147483647)]
        public string CardContent { get; set; }
        /// <summary>
        /// 设置或获取电话
        /// </summary>
        [MaxLength(50)]
        public string Telphone { get; set; }
        /// <summary>
        /// 设置或获取地址
        /// </summary>
        [MaxLength(250)]
        public string Address { get; set; }
        /// <summary>
        /// 设置或获取公司名称
        /// </summary>
        [MaxLength(250)]
        public string CompanyName { get; set; }
        /// <summary>
        /// 设置或获取职位名称
        /// </summary>
        [MaxLength(250)]
        public string PositionTitle { get; set; }
        /// <summary>
        /// 设置或获取个人微信二维码
        /// </summary>
        [MaxLength(250)]
        public string WechatQrCode { get; set; }
        /// <summary>
        /// 设置或获取行业
        /// </summary>
        [MaxLength(500)]
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
        [MaxLength(250)]
        public string ShareTitle { get; set; }
        /// <summary>
        /// 设置或获取网址
        /// </summary>
        [MaxLength(250)]
        public string WebUrl { get; set; }
        /// <summary>
        /// 设置或获取公司简介
        /// </summary>
        [MaxLength(2147483647)]
        public string CompanyDesc { get; set; }
        /// <summary>
        /// 设置或获取名片样式
        /// </summary>
        [MaxLength(250)]
        public string CardTheme { get; set; }
        /// <summary>
        /// 设置或获取Vip等级
        /// </summary>
        [MaxLength(50)]
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
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? DeleteMark { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string CompanyId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string DeptId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string LastModifyUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string DeleteUserId { get; set; }

    }
}
