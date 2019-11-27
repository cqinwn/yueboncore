using Dapper.Contrib.Extensions;
using System;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章点赞表
    /// </summary>
    [DataContract]
    [Table("CMS_ArticleBrowseTrajectory")]
    [Serializable]
    public class ArticleBrowseTrajectory : BaseEntity<string>, ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public ArticleBrowseTrajectory()
		{
            this.Id = System.Guid.NewGuid().ToString();
            this.Duration = 0;
        }


        #region Property Members


        /// <summary>
        /// 商机ID
        /// </summary>
        [DataMember]
        public virtual string ArticleId { get; set; }

        /// <summary>
        /// 离开时间
        /// </summary>
		[DataMember]
        public virtual DateTime? LeaveTime { get; set; }

        /// <summary>
        /// 访问时长，精确到秒
        /// </summary>
		[DataMember]
        public virtual int Duration { get; set; }

        /// <summary>
        /// 访问进入时间，创建时间。
        /// </summary>
		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 访问人
        /// </summary>
		[DataMember]
        public virtual string CreatorUserId { get; set; }


        #endregion

    }
}