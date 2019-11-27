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
    public class OperateTrajectoryDetailInputDto : IInputDto<string>
    {

        #region Property Members
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 内容id
        /// </summary>
        public virtual string ContentId { get; set; }

        /// <summary>
        /// 内容主题
        /// </summary>
        public virtual string ContentTitle { get; set; }

        /// <summary>
        /// 原作者
        /// </summary>
        public virtual string AuthorUserId { get; set; }

        /// <summary>
        /// 内容分类
        /// </summary>
        public virtual string ContentType { get; set; }

        /// <summary>
        /// 离开时间
        /// </summary>
        public virtual DateTime? LeaveTime { get; set; }


        /// <summary>
        /// 浏览时长
        /// </summary>
        public virtual int Duration { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public virtual string OperateType { get; set; }


        /// <summary>
        /// 是否发送
        /// </summary>
        public virtual bool IsSendMsg { get; set; }
        #endregion

    }
}
