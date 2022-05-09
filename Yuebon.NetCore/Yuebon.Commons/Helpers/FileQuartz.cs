using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Yuebon.Commons.Enums;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Options;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 定时任务日志文件
    /// </summary>
    public class FileQuartz
    {
        private static string _rootPath { get; set; }

        private static string _logPath { get; set; }
        /// <summary>
        /// 创建作业所在根目录及日志文件夹 
        /// </summary>
        /// <returns></returns>
        public static string CreateQuartzRootPath()
        {
            if (!string.IsNullOrEmpty(_rootPath))
                return _rootPath;
            _rootPath = AppDomain.CurrentDomain.BaseDirectory;
            _rootPath = _rootPath.ReplacePath();
            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }
            _rootPath = _rootPath +  "Logs\\Quartz\\";
            _rootPath = _rootPath.ReplacePath();
            //生成日志文件夹
            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }
            return _rootPath;
        }

        /// <summary>
        /// 初始化任务日志文件路径
        /// </summary>
        /// <param name="jobName">任务名称</param>
        public static void InitTaskJobLogPath(long jobName)
        {
            if (string.IsNullOrEmpty(_logPath))
            {
                CreateQuartzRootPath();
            }
            _logPath = _rootPath + jobName;
            _logPath = _logPath.ReplacePath();
            //生成日志文件夹
            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
        }
        /// <summary>
        /// 任务启动日志
        /// </summary>
        /// <param name="content"></param>
        public static void WriteStartLog(string content)
        {
            content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + content;
            if (!content.EndsWith("\r\n"))
            {
                content += "\r\n";
            }
            FileHelper.WriteFile(FileQuartz.LogPath, "start.txt", content, true);
        }
        /// <summary>
        /// 任务操作日志
        /// </summary>
        /// <param name="jobAction"></param>
        /// <param name="trigger"></param>
        /// <param name="taskName"></param>
        /// <param name="groupName"></param>
        public static void WriteJobAction(JobAction jobAction, ITrigger trigger, string taskName, string groupName)
        {
            WriteJobAction(jobAction, taskName, groupName, trigger == null ? "未找到作业" : "OK");
        }
        /// <summary>
        /// 任务操作日志
        /// </summary>
        /// <param name="jobAction"></param>
        /// <param name="taskName"></param>
        /// <param name="groupName"></param>
        /// <param name="content"></param>
        public static void WriteJobAction(JobAction jobAction, string taskName, string groupName, string content = null)
        {
            content = $"{jobAction.ToString()} --  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}  --分组：{groupName},作业：{taskName},消息:{content ?? "OK"}\r\n";
            FileHelper.WriteFile(FileQuartz.LogPath, "action.txt", content, true);
        }

        /// <summary>
        /// 任务错误日志
        /// </summary>
        /// <param name="content"></param>
        public static void WriteErrorLog(string content)
        {
            content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "," + content;
            if (!content.EndsWith("\r\n"))
            {
                content += "\r\n";
            }
            FileHelper.WriteFile(FileQuartz.LogPath, "Error.txt", content, true);
        }
        
        /// <summary>
        /// 根目录
        /// </summary>
        public static string RootPath
        {
            get { return _rootPath; }
        }
        /// <summary>
        /// 日志目录
        /// </summary>
        public static string LogPath
        {
            get { return _logPath; }
        }
    }
}
