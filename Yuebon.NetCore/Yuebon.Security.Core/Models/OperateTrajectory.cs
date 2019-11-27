using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.Security.Models
{
    /// <summary>
    /// 行政区域表，数据实体对象
    /// </summary>
    [Table("Sys_OperateTrajectory")]
    [Serializable]
    public class OperateTrajectory : BaseEntity<string>, ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public OperateTrajectory()
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
        /// 是否点赞
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsGood { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsFavorite { get; set; }

        /// <summary>
        /// 是否评星
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsStar { get; set; }


        /// <summary>
        /// 总浏览时长
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalDuration { get; set; }


        /// <summary>
        /// 总浏览次数
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalBrowse { get; set; }

        /// <summary>
        /// 总下载次数
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalDownload { get; set; }

        /// <summary>
        /// 总回复次数
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalMsg { get; set; }

        /// <summary>
        /// 是否XX扩展
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsExt1 { get; set; }

        /// <summary>
        /// 是否XX扩展
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsExt2 { get; set; }

        /// <summary>
        /// 是否XX扩展
        /// </summary>
        [MaxLength(50)]
        public virtual bool IsExt3 { get; set; }

        /// <summary>
        /// 总XX次数
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalExt1{ get; set; }

        /// <summary>
        /// 总XX次数
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalExt2 { get; set; }

        /// <summary>
        /// 总XX次数
        /// </summary>
        [MaxLength(50)]
        public virtual int TotalExt3 { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        #endregion

    }
}