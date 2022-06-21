namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(User))]
    [Serializable]
    public class UserInputDto
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? NickName { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? HeadIcon { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? MobilePhone { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? WeChat { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long? ManagerId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? SecurityLevel { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? Signature { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? Province { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? District { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long OrganizeId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long DepartmentId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public long? DutyId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsAdministrator { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsMember { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public virtual string? language { get; set; }
        /// <summary>
        /// OpenId
        /// </summary>
        public virtual string? OpenId { get; set; }
        /// <summary>
        /// 第三方登录系统类型
        /// </summary>
        public virtual string? OpenIdType { get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string? MemberGradeId { get; set; }

        /// <summary>
        /// 上级推广员
        /// </summary>
        public long? ReferralUserId { get; set; }

        /// <summary>
        /// 用户在微信开放平台的唯一标识符
        /// </summary>
        public string? UnionId { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool EnabledMark { get; set; }

        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string? Description { get; set; }


    }
}
