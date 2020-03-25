using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 操作轨迹表输出对象模型
    /// </summary>
    [Serializable]
    public class OperateTrajectoryOutputDto
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
        /// 设置或获取 
        /// </summary>
        [MaxLength(50)]
        public string ContentType { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsGood { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsFavorite { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsStar { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int TotalDuration { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalBrowse { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? TotalMsg { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? TotalDownload { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExt1 { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExt2 { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public bool? IsExt3 { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalExt1 { get; set; }
        /// <summary>
        /// 设置或获取浏览总时长
        /// </summary>
        public int? TotalExt2 { get; set; }
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public int? TotalExt3 { get; set; }
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
        /// 数据条数
        /// </summary>
        public int? RecordCount
        {
            set;
            get;
        }


        /// <summary>
        /// 文章图片
        /// </summary>
        public string ArticleImg
        {
            set;
            get;
        }

        /// <summary>
        /// 职位图片
        /// </summary>
        public string JobImg
        {
            set;
            get;
        }

        /// <summary>
        /// 商机图片
        /// </summary>
        public string OppImg
        {
            set;
            get;
        }

    }
}
