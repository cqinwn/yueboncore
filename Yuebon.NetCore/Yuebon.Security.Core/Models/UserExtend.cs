
using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 用户扩展信息表，数据实体对象
    /// </summary>
    [SugarTable("Sys_UserExtend")]
    [Comment("用户扩展信息表")]
    [Serializable]
    public class UserExtend : BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public UserExtend()
        {
        }

        #region Property Members
        /// <summary>
        /// 账户ID
        /// </summary>
        [MaxLength(50)]
        [Comment("账户ID")]
        public virtual string UserId { get; set; }

        /// <summary>
        /// 名片
        /// </summary>
        [MaxLength(500)]
        [Comment("名片")]
        public virtual string CardContent { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(50)]
        [Comment("手机")]
        public virtual string Telphone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(500)]
        [Comment("地址")]
        public virtual string Address { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [MaxLength(100)]
        [Comment("公司名称")]
        public virtual string CompanyName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [MaxLength(50)]
        [Comment("职位")]
        public virtual string PositionTitle { get; set; }

        /// <summary>
        /// 微信二维码
        /// </summary>
        [MaxLength(50)]
        [Comment("微信二维码")]
        public virtual string WeChatQrCode { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        [MaxLength(50)]
        [Comment("地区")]
        public virtual string IndustryId { get; set; }

        /// <summary>
        /// 公开情况
        /// </summary>
        [Comment("公开情况")]
        public virtual int OpenType { get; set; }

        /// <summary>
        /// 是否可分享
        /// </summary>
        [DataMember]
        [Comment("IsOtherShare")]
        public virtual bool IsOtherShare { get; set; }

        /// <summary>
        /// 分享标题
        /// </summary>
        [DataMember]
        [MaxLength(50)]
        [Comment("分享标题")]
        public virtual string ShareTitle { get; set; }
        /// <summary>
        /// 主页
        /// </summary>
        [DataMember]
        [MaxLength(250)]
        [Comment("主页")]
        public virtual string WebUrl { get; set; }
        /// <summary>
        /// 公司简介
        /// </summary>
        [DataMember]
        [MaxLength(1500)]
        [Comment("公司简介")]
        public virtual string CompanyDesc { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        [MaxLength(250)]
        [Comment("主题")]
        public virtual string CardTheme { get; set; }

        /// <summary>
        /// VIP级别
        /// </summary>
        [MaxLength(50)]
        [Comment("VIP级别")]
        public virtual string VipGrade { get; set; }

        /// <summary>
        /// 是否认证
        /// </summary>
        [Comment("是否认证")]
        public virtual bool IsAuthentication { get; set; }

        /// <summary>
        /// 认证类型
        /// </summary>
        [Comment("认证类型")]
        public virtual int AuthenticationType { get; set; }


        /// <summary>
        /// 删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [Comment("创建日期")]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户主键")]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 设置或获取创建人组织
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人公司ID")]
        public string CompanyId { get; set; }

        /// <summary>
        /// 设置或获取创建人部门ID
        /// </summary>
        [MaxLength(50)]
        [Comment("创建人部门ID")]
        public string DeptId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [Comment("最后修改时间")]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        [Comment("最后修改用户")]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        [Comment("删除时间")]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        [Comment("删除用户")]
        public virtual string DeleteUserId { get; set; }
        #endregion

    }
}