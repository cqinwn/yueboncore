using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Yuebon.Security.Models
{

    [Serializable]
    public class SysSetting
    {
        #region 系统基本信息
        /// <summary>
        /// 系统名称
        /// </summary>
        [XmlElement("SoftName")]
        public string SoftName { get; set; }
        /// <summary>
        /// 系统简介
        /// </summary>
        [XmlElement("SoftSummary")]
        public string SoftSummary { get; set; }
        /// <summary>
        /// 访问域名
        /// </summary>
        [XmlElement("WebUrl")]
        public string WebUrl { get; set; }
        /// <summary>
        /// Logo
        /// </summary>
        [XmlElement("SysLogo")]
        public string SysLogo { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [XmlElement("CompanyName")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [XmlElement("Address")]
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [XmlElement("Telphone")]
        public string Telphone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [XmlElement("Email")]
        public string Email { get; set; }
        /// <summary>
        /// ICP备案号
        /// </summary>
        [XmlElement("ICPCode")]
        public string ICPCode { get; set; }
        /// <summary>
        /// 公安备案号
        /// </summary>
        [XmlElement("PublicSecurityCode")]
        public string PublicSecurityCode { get; set; }
        /// <summary>
        /// 分享标题
        /// </summary>
        [XmlElement("ShareTitle")]
        public string ShareTitle { get; set; }
        /// <summary>
        /// 微信公众号分享图片
        /// </summary>
        [XmlElement("ShareWeChatImage")]
        public string ShareWeChatImage { get; set; }
        /// <summary>
        /// 微信小程序分享图片
        /// </summary>
        [XmlElement("ShareWxAppletImage")]
        public string ShareWxAppletImage { get; set; }

        /// <summary>
        /// 微信推广二维码背景图片
        /// </summary>
        [XmlElement("ShareBackgroundImage")]
        public string ShareBackgroundImage { get; set; }
        #endregion


        #region 功能权限设置
        /// <summary>
        /// URL重写开关
        /// </summary>
        [XmlElement("Staticstatus")]
        public string Staticstatus { get; set; }
        /// <summary>
        /// 静态URL后缀
        /// </summary>
        [XmlElement("Staticextension")]
        public string Staticextension { get; set; }
        /// <summary>
        /// 开启会员功能
        /// </summary>
        [XmlElement("Memberstatus")]
        public string Memberstatus { get; set; }
        /// <summary>
        /// 是否开启网站
        /// </summary>
        [XmlElement("Webstatus")]
        public string Webstatus { get; set; }
        /// <summary>
        /// 网站关闭原因
        /// </summary>
        [XmlElement("Webclosereason")]
        public string Webclosereason { get; set; }
        /// <summary>
        /// 网站统计代码
        /// </summary>
        [XmlElement("Webcountcode")]
        public string Webcountcode { get; set; }
        #endregion


        #region 短信平台设置
        /// <summary>
        /// 短信AP地址
        /// </summary>
        [XmlElement("Smsapiurl")]
        public string Smsapiurl { get; set; }
        /// <summary>
        /// 平台登录账户
        /// </summary>
        [XmlElement("Smsusername")]
        public string Smsusername { get; set; }
        /// <summary>
        /// 平台通讯密钥
        /// </summary>
        [XmlElement("Smspassword")]
        public string Smspassword { get; set; }
        #endregion


        #region 邮件发送设置
        /// <summary>
        /// SMTP服务器
        /// </summary>
        [XmlElement("Emailsmtp")]
        public string Emailsmtp { get; set; }
        /// <summary>
        /// SSL加密连接
        /// </summary>
        [XmlElement("Emailssl")]
        public string Emailssl { get; set; }
        /// <summary>
        /// SMTP端口
        /// </summary>
        [XmlElement("Emailport")]
        public string Emailport { get; set; }
        /// <summary>
        /// 发件人地址
        /// </summary>
        [XmlElement("Emailfrom")]
        public string Emailfrom { get; set; }
        /// <summary>
        /// 邮箱账号
        /// </summary>
        [XmlElement("Emailusername")]
        public string Emailusername { get; set; }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        [XmlElement("Emailpassword")]
        public string Emailpassword { get; set; }
        /// <summary>
        /// 发件人昵称
        /// </summary>
        [XmlElement("Emailnickname")]
        public string Emailnickname { get; set; }
        #endregion


        #region 文件服务器
        /// <summary>
        /// 文件服务器
        /// </summary>
        [XmlElement("Fileserver")]
        public string Fileserver { get; set; }
        /// <summary>
        /// 本地文件存储物理物理路径
        /// </summary>
        [XmlElement("LocalPath")]
        public string LocalPath { get; set; }
        /// <summary>
        /// 阿里云KeyId
        /// </summary>
        [XmlElement("Osssecretid")]
        public string Osssecretid { get; set; }
        /// <summary>
        /// 阿里云SecretKey
        /// </summary>
        [XmlElement("Osssecretkey")]
        public string Osssecretkey { get; set; }
        /// <summary>
        /// 阿里云Bucket
        /// </summary>
        [XmlElement("Ossbucket")]
        public string Ossbucket { get; set; }
        /// <summary>
        /// 阿里云EndPoint
        /// </summary>
        [XmlElement("Ossendpoint")]
        public string Ossendpoint { get; set; }
        /// <summary>
        /// 阿里云绑定域名
        /// </summary>
        [XmlElement("Ossdomain")]
        public string Ossdomain { get; set; }
        #endregion


        #region 文件上传设置
        /// <summary>
        /// 文件上传目录
        /// </summary>
        [XmlElement("Filepath")]
        public string Filepath { get; set; }
        /// <summary>
        /// 文件保存方式
        /// </summary>
        [XmlElement("Filesave")]
        public string Filesave { get; set; }
        /// <summary>
        /// 编辑器图片
        /// </summary>
        [XmlElement("Fileremote")]
        public string Fileremote { get; set; }
        /// <summary>
        /// 文件上传类型
        /// </summary>
        [XmlElement("Fileextension")]
        public string Fileextension { get; set; }
        /// <summary>
        /// 视频上传类型
        /// </summary>
        [XmlElement("Videoextension")]
        public string Videoextension { get; set; }
        /// <summary>
        /// 附件上传大小
        /// </summary>
        [XmlElement("Attachsize")]
        public string Attachsize { get; set; }
        /// <summary>
        /// 视频上传大小
        /// </summary>
        [XmlElement("Videosize")]
        public string Videosize { get; set; }
        /// <summary>
        /// 图片上传大小
        /// </summary>
        [XmlElement("Imgsize")]
        public string Imgsize { get; set; }
        /// <summary>
        /// 图片最大尺寸 高度
        /// </summary>
        [XmlElement("Imgmaxheight")]
        public string Imgmaxheight { get; set; }
        /// <summary>
        /// 图片最大尺寸 宽度
        /// </summary>
        [XmlElement("Imgmaxwidth")]
        public string Imgmaxwidth { get; set; }
        /// <summary>
        /// 缩略图生成尺寸 高度
        /// </summary>
        [XmlElement("Thumbnailheight")]
        public string Thumbnailheight { get; set; }
        /// <summary>
        /// 缩略图生成尺寸 宽度
        /// </summary>
        [XmlElement("Thumbnailwidth")]
        public string Thumbnailwidth { get; set; }
        /// <summary>
        /// 缩略图生成方式
        /// </summary>
        [XmlElement("Thumbnailmode")]
        public string Thumbnailmode { get; set; }
        /// <summary>
        /// 图片水印类型
        /// </summary>
        [XmlElement("Watermarktype")]
        public string Watermarktype { get; set; }
        /// <summary>
        /// 图片水印位置
        /// </summary>
        [XmlElement("Watermarkposition")]
        public string Watermarkposition { get; set; }
        /// <summary>
        /// 图片生成质量
        /// </summary>
        [XmlElement("Watermarkimgquality")]
        public string Watermarkimgquality { get; set; }
        /// <summary>
        /// 图片水印文件
        /// </summary>
        [XmlElement("Watermarkpic")]
        public string Watermarkpic { get; set; }
        /// <summary>
        /// 水印透明度
        /// </summary>
        [XmlElement("Watermarktransparency")]
        public string Watermarktransparency { get; set; }
        /// <summary>
        /// 水印文字
        /// </summary>
        [XmlElement("Watermarktext")]
        public string Watermarktext { get; set; }
        /// <summary>
        /// 文字字体格式
        /// </summary>
        [XmlElement("Watermarkfont")]
        public string Watermarkfont { get; set; }
        /// <summary>
        /// 文字字体大小
        /// </summary>
        [XmlElement("Watermarkfontsize")]
        public string Watermarkfontsize { get; set; }
        #endregion
    }
}
