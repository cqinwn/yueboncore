using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    ///  输入DTO：APP信息
    /// </summary>
    public class AppInputDto : IInputDto<string>
    {
        /// <summary>
        /// 获取或设置 应用编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 获取或设置 应用Id
        /// </summary>
        public virtual string AppId { get; set; }

        /// <summary>
        /// 获取或设置 应用密钥
        /// </summary>
        public virtual string AppSecret { get; set; }

        /// <summary>
        /// 获取或设置 消息加解密密钥
        /// </summary>
        public virtual string EncodingAESKey { get; set; }

        /// <summary>
        /// 获取或设置 服务器地址url
        /// </summary>
        public virtual string RequestUrl { get; set; }

        /// <summary>
        /// 获取或设置 Token令牌
        /// </summary>
        public virtual string Token { get; set; }
        /// <summary>
        /// 获取或设置 是否开启消息加解密
        /// </summary>
        public virtual bool IsOpenAEKey { get; set; }

        /// <summary>
        /// 获取或设置 描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 获取或设置 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 获取或设置 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        ///获取或设置  创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 获取或设置 创建用户组织主键
        /// </summary>
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 获取或设置 创建用户部门主键
        /// </summary>
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 获取或设置 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 获取或设置 删除用户
        /// </summary>
        public virtual string DeleteUserId { get; set; }
    }
}
