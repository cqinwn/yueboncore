using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    public class ArticleCommentsOntputDto : IOutputDto
    {
        #region Property Members
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
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
        public virtual short DeleteMark { get; set; }

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

        public virtual string Title { get; set; }//标题


        public virtual string CategoryName { get; set; }//分类名称

        public virtual string RealName { get; set; }//扩展字段，对应用户表的用户名称
        public virtual string NickName { get; set; }//扩展字段，对应用户表的用户名称
        public virtual string MobilePhone { get; set; }//扩展字段，对应用户表的用户名称
        public string UserIcon { get; set; } //扩展字段，用户头像
        public string ifGood { get; set; }//是否点过赞
        public List<ArticleCommentsOntputDto> Children { get; set; }
        #endregion
    }
}
