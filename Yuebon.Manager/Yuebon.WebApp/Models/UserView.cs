using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Yuebon.Commons.Helpers;
using Yuebon.Commons.Models;

namespace Yuebon.WebApp.ViewModels
{
    /// <summary>
    /// 用户视图实体对象
    /// </summary>
    [Serializable]
    public class UserView 
    {


        #region Property Members

        /// <summary>
        /// 主键
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
        /// 性别
        /// </summary>
        [DataMember]
        public virtual bool? Gender { get; set; }

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
        /// 主管主键
        /// </summary>
        [DataMember]
        public virtual string ManagerFullName { get; set; }

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
        /// 组织名称
        /// </summary>
        [DataMember]
        public virtual string OrganizeFullName { get; set; }

        /// <summary>
        /// 部门主键
        /// </summary>
        [DataMember]
        public virtual string DepartmentFullName { get; set; }

        /// <summary>
        /// 角色主键
        /// </summary>
        [DataMember]
        public virtual string RoleId { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember]
        public virtual string RoleFullName { get; set; }

        /// <summary>
        /// 岗位主键
        /// </summary>
        [DataMember]
        public virtual string DutyFullName { get; set; }

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

        /// <summary>
        /// 当前登录IP
        /// </summary>
        [DataMember]
        public virtual string CurrentLoginIP { get; set; }
        #endregion

    }
}