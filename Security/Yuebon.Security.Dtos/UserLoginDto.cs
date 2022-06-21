namespace Yuebon.Security.Dtos
{
    [Serializable]
    public class UserLoginDto
    {
        #region Property Members

        /// <summary>
        /// ID
        /// </summary>
        public virtual string UserId { get; set; }
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
        /// 性别,1=男，0=未知，2=女
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
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }

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
        /// 部门主键
        /// </summary>
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 角色主键
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 岗位主键
        /// </summary>
        public virtual string DutyId { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        public virtual bool? IsAdministrator { get; set; }
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
        /// 排序码
        /// </summary>
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }


        /// <summary>
        /// 有效标志
        /// </summary>
        public virtual bool EnabledMark { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 登录IP地址
        /// </summary>
        public virtual string CurrentLoginIP { get; set; }
        /// <summary>
        /// 角色编码，多个角色，使用“,”分格
        /// </summary>
        public string Role { get; set; }
        #endregion

    }
}
