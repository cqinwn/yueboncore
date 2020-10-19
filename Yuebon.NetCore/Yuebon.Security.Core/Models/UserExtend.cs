using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 用户表，数据实体对象
    /// </summary>
    [Table("Sys_UserExtend")]
    [Serializable]
    public class UserExtend : BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public UserExtend()
        {
        }

        #region Property Members
        /// <summary>
        /// 账户
        /// </summary>
        public virtual string UserId { get; set; }

        /// <summary>
        /// 名片
        /// </summary>
        public virtual string CardContent { get; set; }

        /// <summary>
        /// 手机
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
        /// 地区
        /// </summary>
        public virtual string IndustryId { get; set; }

        /// <summary>
        /// 公开情况
        /// </summary>
        public virtual int OpenType { get; set; }

        /// <summary>
        /// IsOtherShare
        /// </summary>
        [DataMember]
        public virtual bool IsOtherShare { get; set; }

        /// <summary>
        /// sharetitle
        /// </summary>
        [DataMember]
        public virtual string ShareTitle { get; set; }
        /// <summary>
        /// 主页
        /// </summary>
        [DataMember]
        public virtual string WebUrl { get; set; }
        /// <summary>
        /// 公司简介
        /// </summary>
        [DataMember]
        public virtual string CompanyDesc { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public virtual string CardTheme { get; set; }

        /// <summary>
        /// VIP
        /// </summary>
        public virtual string VipGrade { get; set; }

        /// <summary>
        /// 是否认证
        /// </summary>
        public virtual bool IsAuthentication { get; set; }

        /// <summary>
        /// 认证类型
        /// </summary>
        public virtual int AuthenticationType { get; set; }        

        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        [MaxLength(50)]
        public virtual string CompanyId { get; set; }

        /// <summary>
        /// 部门id
        /// </summary>
        [MaxLength(50)]
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        public virtual string DeleteUserId { get; set; }
        #endregion

    }
}