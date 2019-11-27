using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 行政区域表，数据实体对象
    /// </summary>
    [Table("Sys_OperateTrajectoryDetail")]
    [Serializable]
    public class OperateTrajectoryDetail : BaseEntity<string>, ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public OperateTrajectoryDetail()
		{
            this.Id = System.Guid.NewGuid().ToString();

        }

        #region Property Members
        ///// <summary>
        ///// 主键
        ///// </summary>
        //[MaxLength(50)]
        //[ExplicitKey]
        //public virtual string Id { get; set; }

        /// <summary>
        /// 内容id
        /// </summary>
        [MaxLength(50)]
        public virtual string ContentId { get; set; }

        /// <summary>
        /// 内容主题
        /// </summary>
        [MaxLength(50)]
        public virtual string ContentTitle{ get; set; }

        /// <summary>
        /// 原作者
        /// </summary>
        [MaxLength(50)]
        public virtual string AuthorUserId { get; set; }

        /// <summary>
        /// 内容分类
        /// </summary>
        [MaxLength(50)]
        public virtual string ContentType { get; set; }

        /// <summary>
        /// 离开时间
        /// </summary>
        [MaxLength(50)]
        public virtual DateTime? LeaveTime { get; set; }

        
        /// <summary>
        /// 浏览时长
        /// </summary>
        [MaxLength(50)]
        public virtual int Duration { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [MaxLength(50)]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [MaxLength(50)]
        public virtual string OperateType { get; set; }


        /// <summary>
        /// 是否发送
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsSendMsg { get; set; }
        #endregion

    }
}