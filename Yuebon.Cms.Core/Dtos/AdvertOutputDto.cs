using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    /// <summary>
    /// 广告输出DTO
    /// </summary>
   [Serializable]
    public class AdvertOutputDto : IOutputDto
    {
        #region Property Advert
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 广告位名称
        /// </summary>
        public  string Title
        {
            get; set;
        }

        /// <summary>
        /// 广告类型
        /// </summary>
        public  string Type
        {
            get;
            set;
        }

        /// <summary>
        /// 广告位代码
        /// </summary>
        public  string EnCode
        {
            get; set;
        }
        /// <summary>
        /// 描述
        /// </summary>
        public  string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public  int ViewNum
        {
            get;
            set;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public  int ViewWidth
        {
            get;
            set;
        }

        /// <summary>
        /// 高度
        /// </summary>
        public  int ViewHeight
        {
            get;
            set;
        }

        /// <summary>
        /// 广告链接打开方式
        /// </summary>
        public  string Target
        {
            get;
            set;
        }


        /// <summary>
        /// 有效标志
        /// </summary>		
        public  bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// 删除标志
        /// </summary>
        public  bool? DeleteMark { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public  DateTime? CreatorTime { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        [MaxLength(50)]
        public  string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        [MaxLength(50)]
        public  string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        [MaxLength(50)]
        public  string DeptId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public  DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        [MaxLength(50)]
        public  string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public  DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        [MaxLength(50)]
        public  string DeleteUserId { get; set; }

        #endregion
    }
}
