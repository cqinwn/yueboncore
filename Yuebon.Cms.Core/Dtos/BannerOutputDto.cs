using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Dtos
{
    [Serializable]
    public class BannerOutputDto : IOutputDto
    {
        #region Property BannerDto
        /// <summary>
        /// 主键
        /// </summary>
        public  string Id { get; set; }
        /// <summary>
		/// 标题
        /// </summary>	
        public  string Title
        {
            get;
            set;
        }
        /// <summary>
		/// 广告位ID
        /// </summary>	
        public  string AdId
        {
            get;
            set;
        }
        /// <summary>
		/// 广告位名称
        /// </summary>		
        public  string ADTitle
        {
            get;
            set;
        }
        /// <summary>
		/// 副标题
        /// </summary>		
        public  string SubTitle
        {
            get;
            set;
        }
        /// <summary>
		/// 摘要
        /// </summary>		
        public  string Zhaiyao
        {
            get;
            set;
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
        /// 开始时间
        /// </summary>
        public  DateTime? StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public  DateTime? EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// 广告文件路径
        /// </summary>		
        public  string FilePath
        {
            get;
            set;
        }
        /// <summary>
        /// 链接路径
        /// </summary>		
        public  string LinkUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 排序
        /// </summary>		
        public  int? SortCode
        {
            get;
            set;
        }
        /// <summary>
        /// 状态
        /// </summary>		
        public  bool EnabledMark
        {
            get;
            set;
        }
        /// <summary>
        /// 是否删除
        /// </summary>	
        public  bool? DeleteMark
        {
            get;
            set;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public  DateTime? CreatorTime
        {
            get;
            set;
        }
        public  string CreatorUserId { get; set; }

        /// <summary>
        /// 创建用户组织主键
        /// </summary>
        public  string CompanyId { get; set; }
        /// <summary>
        /// 创建用户部门主键
        /// </summary>
        public  string DeptId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public  DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 最后修改用户
        /// </summary>
        public  string LastModifyUserId { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public  DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public  string DeleteUserId { get; set; }
        #endregion
    }
}
