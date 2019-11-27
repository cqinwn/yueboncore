using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using Yuebon.Commons.Models;

namespace Yuebon.CMS.Models
{
    /// 广告，数据实体对象
    /// </summary>
    [Table("CMS_Banner")]
    [Serializable]
    public class Banner : BaseEntity<string>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        #region Field Banner
        
        private string m_Title; //广告名称          
        private string m_AdId; //广告位ID
        private string m_SubTitle; //副标题
        private string m_Zhaiyao;  //摘要
        private string m_Description; //描述          
        private DateTime m_StartTime; //开始时间          
        private DateTime m_EndTime; //结束时间          
        private string m_FilePath; //广告文件路径          
        private string m_LinkUrl; //链接URL         

        #endregion

        #region Property Banner

        /// <summary>
        /// 广告名称
        /// </summary>
        public virtual string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

        /// <summary>
        /// 广告位ID
        /// </summary>
        public virtual string AdId
        {
            get
            {
                return this.m_AdId;
            }
            set
            {
                this.m_AdId = value;
            }
        }

        /// <summary>
        /// 副标题
        /// </summary>
        public virtual string SubTitle
        {
            get
            {
                return this.m_SubTitle;
            }
            set
            {
                this.m_SubTitle = value;
            }
        }

        /// <summary>
        /// 摘要
        /// </summary>
        public virtual string Zhaiyao
        {
            get
            {
                return this.m_Zhaiyao;
            }
            set
            {
                this.m_Zhaiyao = value;
            }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description
        {
            get
            {
                return this.m_Description;
            }
            set
            {
                this.m_Description = value;
            }
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
            get
            {
                return this.m_FilePath;
            }
            set
            {
                this.m_FilePath = value;
            }
        }

        /// <summary>
        /// 链接URL
        /// </summary>
        public virtual string LinkUrl
        {
            get
            {
                return this.m_LinkUrl;
            }
            set
            {
                this.m_LinkUrl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int? SortCode
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
