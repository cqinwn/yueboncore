using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// 图片相册，数据实体对象
    /// </summary>
    [Table("CMS_Albums")]
    [Serializable]
    public class Albums: BaseEntity<string>
    {
        public Albums() {
        }

        #region Property Albums

        /// <summary>
        /// 频道ID
        /// </summary>
        [MaxLength(255)]
        public virtual string Channel
        {
            get; set;
        }

        /// <summary>
        /// 内容ID
        /// </summary>
        [MaxLength(255)]
        public virtual string ContentId
        {
            get; set;
        }

        /// <summary>
        /// 缩略图地址
        /// </summary>
        [MaxLength(255)]
        public virtual string ThumbPath
        {
            get; set;
        }

        /// <summary>
        /// 原图地址
        /// </summary>
        [MaxLength(255)]
        public virtual string OriginalPath
        {
            get; set;
        }

        /// <summary>
        /// 图片描述
        /// </summary>
        [MaxLength(255)]
        public virtual string Remark
        {
            get; set;
        }

        /// <summary>
        /// 上传时间
        /// </summary>		
        public virtual DateTime? AddTime
        {
            get;
            set;
        }

        #endregion
    }
}
