using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Security.Models;

namespace Yuebon.Security.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(User))]
    public class UserFocusOutPutDto : IOutputDto
    {

        #region Property Members

        /// <summary>
        /// 用户主键
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// 关注的用户ID
        /// </summary>
        public virtual string FocusUserId { get; set; }

        /// <summary>
        /// 关注人
        /// </summary>
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 关注时间
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        #endregion
    }
}
