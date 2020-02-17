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
    [Serializable]
    [AutoMap(typeof(User))]
    public class UserOutPutDto:IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 用户主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string RealName { get; set; }

        /// <summary>
        /// 呢称
        /// </summary>
        public virtual string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public virtual string HeadIcon { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual int? Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public virtual DateTime? Birthday { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public virtual string MobilePhone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string UserPassword { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public virtual string WeChat { get; set; }
        /// <summary>
        /// 是否会员
        /// </summary>
        public virtual bool? IsMember { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string MemberGradeId { get; set; }

        /// <summary>
        /// 上级推广员
        /// </summary>
        public string ReferralUserId { get; set; }

        /// <summary>
        /// 主管主键
        /// </summary>
        public virtual string ManagerId { get; set; }

        /// <summary>
        /// 安全级别
        /// </summary>
        public virtual int? SecurityLevel { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        public virtual string Signature { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        public virtual string OrganizeId { get; set; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public virtual string OrganizeName { get; set; }

        /// <summary>
        /// 部门主键
        /// </summary>
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public virtual string DepartmentName { get; set; }

        /// <summary>
        /// 角色主键
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual string RoleName { get; set; }

        /// <summary>
        /// 岗位主键
        /// </summary>
        public virtual string DutyId { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        public virtual string DutyName { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public virtual bool? IsAdministrator { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

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
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual string DeleteUserId { get; set; }
        #endregion
    }
}
