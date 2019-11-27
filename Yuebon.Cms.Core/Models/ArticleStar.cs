using Dapper.Contrib.Extensions;
using System;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章星级表
    /// </summary>
    [DataContract]
    [Table("CMS_ArticleStar")]
    [Serializable]
    public class ArticleStar : BaseEntity<string>, ICreationAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public ArticleStar()
		{
            this.Id = System.Guid.NewGuid().ToString();
            this.StarScore = 0;
        }

        #region Property Members

        /// <summary>
        /// 文章ID
        /// </summary>
		[DataMember]
        public virtual string ArticleNewsId { get; set; }

        /// <summary>
        /// 星级评分
        /// </summary>
		[DataMember]
        public virtual decimal StarScore { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
		[DataMember]
        public virtual string CreatorUserId { get; set; }


        #endregion

    }
}