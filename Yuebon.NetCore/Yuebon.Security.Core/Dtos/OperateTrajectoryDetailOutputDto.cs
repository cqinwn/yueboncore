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
    public class OperateTrajectoryDetailOutputDto :IOutputDto
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

        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            set;
            get;
        }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            set;
            get;
        }

        /// <summary>
        /// 头像 
        /// </summary>
        public string HeadIcon
        {
            set;
            get;
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string ShowAddTime
        {
            set;
            get;
        }

        /// <summary>
        /// 浏览时间
        /// </summary>
        public string BrowseTime
        {
            set;
            get;
        }

        /// <summary>
        /// 数据条数
        /// </summary>
        public int? RecordCount
        {
            set;
            get;
        }
    }
}
