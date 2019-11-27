using Dapper.Contrib.Extensions;
using System;
using System.Runtime.Serialization;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// <summary>
    /// 文章评论表
    /// </summary>
    [DataContract]
    [Table("CMS_ArticleComments")]
    [Serializable]
    public class ArticleComments : BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    { 
        /// <summary>
        /// 默认构造函数（需要初始化属性的在此处理）
        /// </summary>
	    public ArticleComments()
		{
            this.Id = System.Guid.NewGuid().ToString();
            this.TotalGood = 0;
            this.EnabledMark = 1;
            this.DeleteMark = false;
        }

        #region Property Members

        /// <summary>
        /// 文章ID
        /// </summary>
		[DataMember]
        public virtual string ArticleNewsId { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
		[DataMember]
        public virtual string ParentID { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
		[DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 总点赞量
        /// </summary>
		[DataMember]
        public virtual int TotalGood { get; set; }

        /// <summary>
        /// 有效标识
        /// </summary>
		[DataMember]
        public virtual short EnabledMark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
		[DataMember]
        public virtual bool? DeleteMark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
		[DataMember]
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
		[DataMember]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
		[DataMember]
        public virtual string CompanyId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
		[DataMember]
        public virtual string DeptId { get; set; }

        /// <summary>
        /// 最后一次修改时间
        /// </summary>
		[DataMember]
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后一次修改用户ID
        /// </summary>
		[DataMember]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
		[DataMember]
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户ID
        /// </summary>
		[DataMember]
        public virtual string DeleteUserId { get; set; }


        #endregion

    }
}