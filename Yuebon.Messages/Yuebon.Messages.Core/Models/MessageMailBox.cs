using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// 发送消息表，数据实体对象
    /// </summary>
    [Table("Sys_MessageMailBox")]
    [Comment("发送消息表")]
    [Serializable]
    public class MessageMailBox:BaseEntity, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        //public string Id { get; set; }

        /// <summary>
        /// 设置或获取 标题
        /// </summary>
        [MaxLength(50)]
        [Comment("标题")]
        public string Title { get; set; }

        /// <summary>
        /// 设置或获取是否短信提醒
        /// </summary>
        [Comment("是否短信提醒")]
        public bool? IsMsgRemind { get; set; }

        /// <summary>
        /// 设置或获取是否发送
        /// </summary>
        [Comment("是否发送")]
        public bool? IsSend { get; set; }

        /// <summary>
        /// 设置或获取 发送时间
        /// </summary>
        [Comment("发送时间")]
        public DateTime SendDate { get; set; }

        /// <summary>
        /// 设置或获取是否是强制消息
        /// </summary>
        [Comment("是否是强制消息")]
        public bool? IsCompel { get; set; }

        /// <summary>
        /// 消息内容描述
        /// </summary>
        [MaxLength(2000)]
        [Comment("消息内容描述")]
        public virtual string Description { get; set; }

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
        /// 删除标志
        /// </summary>
        [Comment("删除标志")]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        [Comment("有效标志")]
        public virtual bool? EnabledMark { get; set; }

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


    }
}
