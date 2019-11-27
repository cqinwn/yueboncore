using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    public class BannerInputDto : IInputDto<string>
    {
        #region Property BannerDto
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; set; }
        /// <summary>
		/// 标题
        /// </summary>	
        public virtual string Title
        {
            get;
            set;
        }
        /// <summary>
		/// 广告位ID
        /// </summary>	
        public virtual string AdId
        {
            get;
            set;
        }
        /// <summary>
		/// 广告位名称
        /// </summary>		
        public virtual string ADTitle
        {
            get;
            set;
        }
        /// <summary>
		/// 副标题
        /// </summary>		
        public virtual string SubTitle
        {
            get;
            set;
        }
        /// <summary>
		/// 摘要
        /// </summary>		
        public virtual string Zhaiyao
        {
            get;
            set;
        }
        /// <summary>
		/// 描述
        /// </summary>		
        public virtual string Description
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public virtual DateTime? EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 广告文件路径
        /// </summary>		
        public virtual string FilePath
        {
            get;
            set;
        }
        /// <summary>
        /// 链接路径
        /// </summary>		
        public virtual string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public virtual int? SortCode
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public virtual bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// 是否删除
        /// </summary>	
        public virtual bool? DeleteMark
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? CreatorTime
        {
            get;
            set;
        }
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual string DeleteUserId { get; set; }
        #endregion
    }
}
