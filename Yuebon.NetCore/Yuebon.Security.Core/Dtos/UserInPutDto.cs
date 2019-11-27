using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserInPutDto: IInputDto<string>
    {

        #region Property Members

        /// <summary>
        /// 用户主键
        /// </summary>
        [DataMember]
        public virtual string Id { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        [DataMember]
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public virtual string RealName { get; set; }

        /// <summary>
        /// 呢称
        /// </summary>
        [DataMember]
        public virtual string NickName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [DataMember]
        public virtual string HeadIcon { get; set; }

        /// <summary>
        /// 性别,1=男，0=未知，2=女
        /// </summary>
        [DataMember]
        public virtual int? Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [DataMember]
        public virtual DateTime? Birthday { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [DataMember]
        public virtual string MobilePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DataMember]
        public virtual string Email { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [DataMember]
        public virtual string WeChat { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [DataMember]
        public virtual string Country { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        [DataMember]
        public virtual string Province { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [DataMember]
        public virtual string City { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        [DataMember]
        public virtual string District { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        [DataMember]
        public virtual string language { get; set; }
        /// <summary>
        /// OpenId
        /// </summary>
        [DataMember]
        public virtual string OpenId { get; set; }
        /// <summary>
        /// 第三方登录系统类型
        /// </summary>
        public virtual string OpenIdType{ get; set; }
        /// <summary>
        /// 会员等级
        /// </summary>
        public string MemberGradeId { get; set; }

        /// <summary>
        /// 上级推广员
        /// </summary>
        public string ReferralUserId { get; set; }

        /// <summary>
        /// 用户在微信开放平台的唯一标识符
        /// </summary>
        public string UnionId { get; set; }
        
        /// <summary>
        /// 主管主键
        /// </summary>
        [DataMember]
        public virtual string ManagerId { get; set; }

        /// <summary>
        /// 安全级别
        /// </summary>
        [DataMember]
        public virtual int? SecurityLevel { get; set; }

        /// <summary>
        /// 个性签名
        /// </summary>
        [DataMember]
        public virtual string Signature { get; set; }

        /// <summary>
        /// 组织主键
        /// </summary>
        [DataMember]
        public virtual string OrganizeId { get; set; }

        /// <summary>
        /// 部门主键
        /// </summary>
        [DataMember]
        public virtual string DepartmentId { get; set; }

        /// <summary>
        /// 角色主键
        /// </summary>
        [DataMember]
        public virtual string RoleId { get; set; }

        /// <summary>
        /// 岗位主键
        /// </summary>
        [DataMember]
        public virtual string DutyId { get; set; }

        /// <summary>
        /// 是否管理员
        /// </summary>
        [DataMember]
        public virtual bool? IsAdministrator { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        [DataMember]
        public virtual int? SortCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public virtual string Description { get; set; }


        #endregion
    }
}
