using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    public class ArticleNewsInputDto : IInputDto<string>
    {
        #region Property Advert
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
		/// 标题
        /// </summary>	
        public virtual string Title
        {
            get;
            set;
        }
        /// <summary>
		/// 分类编号
        /// </summary>		
        public virtual string CategoryId
        {
            get;
            set;
        }
        /// <summary>
		/// 分类名称
        /// </summary>		
        public virtual string CategoryName
        {
            get;
            set;
        }
        /// <summary>
        /// 主图URL
        /// </summary>		
        [MaxLength(256)]
        public virtual string ImgUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 详细内容
        /// </summary>		
        public virtual string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>		
        public virtual string UploadTempId
        {
            get;
            set;
        }

        #endregion
    }
}