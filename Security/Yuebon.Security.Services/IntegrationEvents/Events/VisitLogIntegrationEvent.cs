using Yuebon.EventBus.Events;

namespace Yuebon.Security.Services.IntegrationEvents.Events
{
    public class VisitLogIntegrationEvent : IntegrationEvent
    {

        #region Property Members
        public long PreId { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public virtual DateTime? Date { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string Account { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public virtual string RealName { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public virtual string IPAddress { get; set; }

        /// <summary>
        /// 系统模块
        /// </summary>
        public virtual string ModuleName { get; set; }
        /// <summary>
        /// 请求名称
        /// </summary>
        public virtual string MethodName { get; set; }
        /// <summary>
        /// 请求方式
        /// </summary
        public virtual string RequestMethod { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public virtual string? RequestParameter { get; set; }

        /// <summary>
        /// 请求
        /// </summary>
        public virtual string RequestUrl { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        public virtual string Browser { get; set; }

        /// <summary>
        /// 操作系统
        /// </summary>
        public virtual string OS { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public virtual bool? Result { get; set; }
        /// <summary>
        /// 耗时
        /// </summary>
        public virtual long? ElapsedTime { get; set; }


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
        public virtual long? CreatorUserId { get; set; }


        /// <summary>
        /// 删除时间
        /// </summary>
        public virtual DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 删除用户
        /// </summary>
        public virtual long? DeleteUserId { get; set; }
        #endregion

    }
}
