using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    public class ArticleCommentsGoodInputDto : IInputDto<string>
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
        public virtual string CommentsId { get; set; }

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
