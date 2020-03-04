using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// 消息内容，数据实体对象
    /// </summary>
    [Table("Sys_MessageMailBox")]
    [Serializable]
    public class MessageMailBox : BaseEntity<string>
    {
        #region Field Members
     
        private string m_Title; //          
        private string m_Description; //          
        private bool m_IsMsgRemind = false; //是否短信提醒          
        private bool m_IsSend = false; //是否发送          
        private DateTime m_SendDate; //          
        private bool m_IsCompel = false; //是否是强制消息          
        private bool m_DeleteMark = false; //是否发送          
        private DateTime m_CreatorTime; //          
        private string m_CreatorUserId; //          
        private string m_CompanyId; //          
        private string m_DeptId; //          
        private DateTime m_LastModifyTime; //          
        private string m_LastModifyUserId; //          
        private DateTime m_DeleteTime; //          
        private string m_DeleteUserId; //          

        #endregion

        #region Property Members

        /// <summary>
        /// 消息标题
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
        /// 消息内容
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
        /// 是否短信提醒
        /// </summary>
        public virtual bool IsMsgRemind
        {
            get
            {
                return this.m_IsMsgRemind;
            }
            set
            {
                this.m_IsMsgRemind = value;
            }
        }

        /// <summary>
        /// 是否发送
        /// </summary>
        public virtual bool IsSend
        {
            get
            {
                return this.m_IsSend;
            }
            set
            {
                this.m_IsSend = value;
            }
        }
        /// <summary>
        /// 发送日期
        /// </summary>
        public virtual DateTime SendDate
        {
            get
            {
                return this.m_SendDate;
            }
            set
            {
                this.m_SendDate = value;
            }
        }

        /// <summary>
        /// 是否是强制消息
        /// </summary>
        public virtual bool IsCompel
        {
            get
            {
                return this.m_IsCompel;
            }
            set
            {
                this.m_IsCompel = value;
            }
        }

        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual bool DeleteMark
        {
            get
            {
                return this.m_DeleteMark;
            }
            set
            {
                this.m_DeleteMark = value;
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreatorTime
        {
            get
            {
                return this.m_CreatorTime;
            }
            set
            {
                this.m_CreatorTime = value;
            }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public virtual string CreatorUserId
        {
            get
            {
                return this.m_CreatorUserId;
            }
            set
            {
                this.m_CreatorUserId = value;
            }
        }

        public virtual string CompanyId
        {
            get
            {
                return this.m_CompanyId;
            }
            set
            {
                this.m_CompanyId = value;
            }
        }

        public virtual string DeptId
        {
            get
            {
                return this.m_DeptId;
            }
            set
            {
                this.m_DeptId = value;
            }
        }

        public virtual DateTime LastModifyTime
        {
            get
            {
                return this.m_LastModifyTime;
            }
            set
            {
                this.m_LastModifyTime = value;
            }
        }

        public virtual string LastModifyUserId
        {
            get
            {
                return this.m_LastModifyUserId;
            }
            set
            {
                this.m_LastModifyUserId = value;
            }
        }

        public virtual DateTime DeleteTime
        {
            get
            {
                return this.m_DeleteTime;
            }
            set
            {
                this.m_DeleteTime = value;
            }
        }

        public virtual string DeleteUserId
        {
            get
            {
                return this.m_DeleteUserId;
            }
            set
            {
                this.m_DeleteUserId = value;
            }
        }


        #endregion
    }
}
