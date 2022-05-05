using Microsoft.EntityFrameworkCore;
using SqlSugar;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 系统应用表，数据实体对象
    /// </summary>
    [SugarTable("Sys_APP")]
    [Comment("系统应用表")]
    [Serializable]
    public class APP :BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
        public APP()
        {
        }

        #region Property APP


        /// <summary>
        /// 应用Id
        /// </summary>
        [MaxLength(50)]
        [Comment("应用Id")]
        [Description("应用Id")]
        [Required]
        public virtual string AppId { get; set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        [MaxLength(256)]
        [Description("应用密钥")]
        [Comment("应用密钥")]
        [Required]
        public virtual string AppSecret { get; set; }

        /// <summary>
        /// 消息加解密密钥
        /// </summary>
        [MaxLength(256)]
        [Description("消息加解密密钥")]
        [Comment("消息加解密密钥")]
        [Required]
        public virtual string EncodingAESKey { get; set; }

        /// <summary>
        /// 授权请求地址url
        /// </summary>
        [MaxLength(512)]
        [Description("授权请求地址url")]
        [Comment("授权请求地址url")]
        public virtual string RequestUrl { get; set; }

        /// <summary>
        /// Token令牌
        /// </summary>
        [Display(Name = "Token令牌")]
        [MaxLength(64)]
        [Description("Token令牌")]
        [Comment("Token令牌")]
        public virtual string Token { get; set; }
        /// <summary>
        /// 是否开启消息加解密
        /// </summary>
        [Display(Name = "是否开启消息加解密")]
        [Description("是否开启消息加解密")]
        [Comment("是否开启消息加解密")]
        public virtual bool IsOpenAEKey { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        [Description("描述")]
        [MaxLength(200)]
        [Comment("描述")]
        public virtual string Description { get; set; }
        

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户组织主键")]
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        [MaxLength(50)]
        [Comment("创建用户部门主键")]
        public virtual string DeptId { get; set; }

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