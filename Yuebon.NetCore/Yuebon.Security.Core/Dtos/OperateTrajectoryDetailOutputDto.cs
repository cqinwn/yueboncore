using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 商操作轨迹明细表输出对象模型
    /// </summary>
    [Serializable]
    public class OperateTrajectoryDetailOutputDto
    {
        /// <summary>
        /// 设置或获取主键
        /// </summary>
        [MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string ContentId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(400)]
        public string ContentTitle { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string AuthorUserId { get; set; }
        /// <summary>
        /// 设置或获取内容类型：商机-opp,文章：art；文库：doc
        /// </summary>
        [MaxLength(50)]
        public string ContentType { get; set; }
        /// <summary>
        /// 设置或获取离开时间
        /// </summary>
        public DateTime? LeaveTime { get; set; }
        /// <summary>
        /// 设置或获取访问时长，精确到秒
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 设置或获取访问进入时间，创建时间。
        /// </summary>
        public DateTime? CreatorTime { get; set; }
        /// <summary>
        /// 设置或获取访问人
        /// </summary>
        [MaxLength(50)]
        public string CreatorUserId { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string OperateType { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool IsSendMSg { get; set; }



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
