using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 广告输入DTO
    /// </summary>
   public class AdvertInputDto : IInputDto<string>
    {
        #region Property Advert
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 广告位名称
        /// </summary>
        public virtual string Title
        {
            get; set;
        }

        /// <summary>
        /// 广告类型
        /// </summary>
        public virtual string Type
        {
            get;
            set;
        }
        /// <summary>
        /// 广告位代码
        /// </summary>
        public virtual string EnCode
        {
            get; set;
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
        /// 数量
        /// </summary>
        public virtual int ViewNum
        {
            get;
            set;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public virtual int ViewWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 高度
        /// </summary>
        public virtual int ViewHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 广告链接打开方式
        /// </summary>
        public virtual string Target
        {
            get;
            set;
        }


        /// <summary>
        /// 有效标志
        /// </summary>		
        public virtual bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public virtual bool? DeleteMark { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        [MaxLength(50)]
        public virtual string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        [MaxLength(50)]
        public virtual string DeptId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public virtual DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        public virtual string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        public virtual string DeleteUserId { get; set; }

        #endregion
    }
}
