using System;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public interface ILogService:IService<Log, LogOutputDto, string>
    {
        /// <summary>
        /// 根据相关信息，写入用户的操作日志记录
        /// 主要用于写数据库日志
        /// </summary>
        /// <param name="tableName">操作表名称</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="note">操作详细表述</param>
        /// <returns></returns>
         bool OnOperationLog(string tableName, string operationType, string note);

        /// <summary>
        /// 根据相关信息，写入用户的操作日志记录
        /// 主要用于写操作模块日志
        /// </summary>
        /// <param name="module">操作模块名称</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="note">操作详细表述</param>
        /// <param name="currentUser">操作用户</param>
        /// <returns></returns>
        bool OnOperationLog(string module, string operationType,  string note, YuebonCurrentUser currentUser);
    }
}
