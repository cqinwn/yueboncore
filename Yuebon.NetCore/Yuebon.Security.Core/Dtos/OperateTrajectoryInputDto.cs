using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    ///  输入DTO：APP信息
    /// </summary>
    public class OperateTrajectoryInputDto : IInputDto<string>
    {

        #region Property Members
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 内容id
        /// </summary>
        public virtual string ContentId { get; set; }

        /// <summary>
        /// 内容主题
        /// </summary>
        public virtual string ContentTitle { get; set; }

        /// <summary>
        /// 原作者
        /// </summary>
        public virtual string AuthorUserId { get; set; }

        /// <summary>
        /// 内容分类
        /// </summary>
        public virtual string ContentType { get; set; }

        /// <summary>
        /// 是否点赞
        /// </summary>
        public virtual bool IsGood { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public virtual bool IsFavorite { get; set; }

        /// <summary>
        /// 是否评星
        /// </summary>
        public virtual bool IsStar { get; set; }


        /// <summary>
        /// 总浏览时长
        /// </summary>
        public virtual int TotalDuration { get; set; }


        /// <summary>
        /// 总浏览次数
        /// </summary>
        public virtual int TotalBrowse { get; set; }

        /// <summary>
        /// 总下载次数
        /// </summary>
        public virtual int TotalDownload { get; set; }

        /// <summary>
        /// 总回复次数
        /// </summary>
        public virtual int TotalMsg { get; set; }

        /// <summary>
        /// 是否XX扩展
        /// </summary>
        public virtual bool IsExt1 { get; set; }

        /// <summary>
        /// 是否XX扩展
        /// </summary>
        public virtual bool IsExt2 { get; set; }

        /// <summary>
        /// 是否XX扩展
        /// </summary>
        public virtual bool IsExt3 { get; set; }

        /// <summary>
        /// 总XX次数
        /// </summary>
        public virtual int TotalExt1 { get; set; }

        /// <summary>
        /// 总XX次数
        /// </summary>
        public virtual int TotalExt2 { get; set; }

        /// <summary>
        /// 总XX次数
        /// </summary>
        public virtual int TotalExt3 { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        #endregion

    }
}
