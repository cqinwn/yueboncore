using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    
    /// <summary>
    /// 
    /// </summary>

    [AutoMap(typeof(User))]
    public class UserNameCardOutPutDto : IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 用户主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public virtual string UserId { get; set; }

        /// <summary>
        /// 名片详情
        /// </summary>
        public virtual string CardContent { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string Telphone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public virtual string PositionTitle { get; set; }

        /// <summary>
        /// 微信二维码
        /// </summary>
        public virtual string WeChatQrCode { get; set; }
        /// <summary>
        /// 行业代码
        /// </summary>
        public virtual string IndustryId { get; set; }

        /// <summary>
        /// 公开标识
        /// </summary>
        public virtual int OpenType { get; set; }

        /// <summary>
        /// IsOtherShare
        /// </summary>
        public virtual bool? IsOtherShare { get; set; }
        /// <summary>
        /// ShareTitle
        /// </summary>
        public virtual string ShareTitle { get; set; }
        /// <summary>
        /// 主页
        /// </summary>
        public string WebUrl { get; set; }

        /// <summary>
        /// 公司描述
        /// </summary>
        public string CompanyDesc { get; set; }

        /// <summary>
        /// 名片主题
        /// </summary>
        public virtual string CardTheme { get; set; }

        /// <summary>
        /// vip等级
        /// </summary>
        public virtual string VipGrade { get; set; }

        /// <summary>
        /// 是否认证
        /// </summary>
        public virtual bool? IsAuthentication { get; set; }

        /// <summary>
        /// 认证类型
        /// </summary>
        public virtual int? AuthenticationType { get; set; }

        /// <summary>
        /// 可以标识 
        /// </summary>
        public virtual bool? EnabledMark { get; set; }

        /// <summary>
        /// 删除标识 
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        public virtual string CompanyId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime DeleteTime { get; set; }

        /// <summary>
        /// 删除 人
        /// </summary>
        public virtual string DeleteUserId { get; set; }

        /// <summary>
        /// 真实名称
        /// </summary>
        public virtual string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public virtual string HeadIcon { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public virtual string MobilePhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public virtual string EMail { get; set; }

        /// <summary>
        /// 微信 
        /// </summary>
        public virtual string WeChat { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public virtual string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public virtual string City { get; set; }


        /// <summary>
        /// 地区
        /// </summary>
        public virtual string District { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Gender { get; set; }

        /// <summary>
        /// 用户主表id
        /// </summary>
        public virtual string MUserId { get; set; }
        #endregion
    }
}
