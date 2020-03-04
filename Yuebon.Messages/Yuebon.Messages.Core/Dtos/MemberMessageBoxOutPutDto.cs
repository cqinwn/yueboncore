using Dapper.Contrib.Extensions;
using System;
using Yuebon.Commons.Models;

namespace Yuebon.Messages.Dtos
{
    /// <summary>
    /// 会员消息
    /// </summary>
    [Serializable]
    public class MemberMessageBoxOutPutDto 
    {
        #region Field Members

        private string m_id;
        private long m_ContentId = 0; //消息内容Id          
        private string m_Sernder; //发送者      
        private string m_msgContent;
        private string m_Accepter; //接受者          
        private bool m_IsRead = false; //是否已读          
        private DateTime m_ReadDate; //          

        #endregion

        #region Property Members

        /// <summary>
        /// 消息内容Id
        /// </summary>
        public virtual string Id
        {
            get
            {
                return this.m_id;
            }
            set
            {
                this.m_id = value;
            }
        }
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
        /// 内容
        /// </summary>
        public virtual string MsgContent
        {
            get
            {
                return this.m_msgContent;
            }
            set
            {
                this.m_msgContent = value;
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

        public virtual DateTime ReadDate
        {
            get
            {
                return this.m_ReadDate;
            }
            set
            {
                this.m_ReadDate = value;
            }
        }


        #endregion
    }
}
