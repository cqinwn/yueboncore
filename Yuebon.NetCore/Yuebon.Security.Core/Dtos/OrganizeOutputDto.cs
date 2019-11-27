using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Dtos
{
    [Serializable]
   public class OrganizeOutputDto : IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 组织主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        public virtual string ParentId { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public virtual int? Layers { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public virtual string EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public virtual string ShortName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual string CategoryId { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        public virtual string ManagerId { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string TelePhone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public virtual string MobilePhone { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public virtual string WeChat { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public virtual string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// 归属区域
        /// </summary>
        public virtual string AreaId { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public virtual bool? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public virtual bool? AllowDelete { get; set; }

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
