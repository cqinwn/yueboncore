using Dapper.Contrib.Extensions;
using System;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Models
{
    /// <summary>
    /// 会员消息列表，数据实体对象
    /// </summary>
    [Table("Sys_MemberMessageBox")]
    [Serializable]
    public class MemberMessageBox : BaseEntity<string>
    {
        #region Field Members
         
        private long m_ContentId = 0; //消息内容Id          
        private string m_Sernder; //发送者          
        private string m_Accepter; //接受者          
        private bool m_IsRead = false; //是否已读          
        private DateTime m_ReadDate; //          

        #endregion

        #region Property Members


        /// <summary>
        /// 消息内容Id
        /// </summary>
        public virtual long ContentId
        {
            get
            {
                return this.m_ContentId;
            }
            set
            {
                this.m_ContentId = value;
            }
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        public virtual string MsgContent
        {
            get;
            set;
        }
        
        /// <summary>
        /// 发送者
        /// </summary>
        public virtual string Sernder
        {
            get
            {
                return this.m_Sernder;
            }
            set
            {
                this.m_Sernder = value;
            }
        }

        /// <summary>
        /// 接受者
        /// </summary>
        public virtual string Accepter
        {
            get
            {
                return this.m_Accepter;
            }
            set
            {
                this.m_Accepter = value;
            }
        }

        /// <summary>
        /// 是否已读
        /// </summary>
        public virtual bool IsRead
        {
            get
            {
                return this.m_IsRead;
            }
            set
            {
                this.m_IsRead = value;
            }
        }

        public virtual DateTime? ReadDate
        {
            get;
            set;
        }


        #endregion
    }
}
