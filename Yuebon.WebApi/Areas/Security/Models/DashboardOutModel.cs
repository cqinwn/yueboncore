using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yuebon.WebApi.Areas.Security.Models
{
    /// <summary>
    /// 控制台首页显示内容
    /// </summary>
    [Serializable]
    public class DashboardOutModel
    {
        /// <summary>
        /// 许可使用公司名称
        /// </summary>
        public string CertificatedCompany
        {
            get;
            set;
        }
        /// <summary>
        /// 系统访问Url
        /// </summary>
        public string WebUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string MachineName
        {
            get;
            set;
        }
        /// <summary>
        /// 操作系统
        /// </summary>
        public string OSName
        {
            get;
            set;
        }
        /// <summary>
        /// 正在其上运行应用的操作系统。
        /// </summary>
        public string OSDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 获取正在其上运行应用的 .NET 安装的名称。
        /// </summary>
        public string FrameworkDescription
        {
            get;
            set;
        }
        /// <summary>
        /// 获取正在其上运行当前应用的平台体系结构。
        /// </summary>
        public string OSArchitecture
        {
            get;
            set;
        }
        /// <summary>
        /// 获取当前正在运行的应用的进程架构。
        /// </summary>
        public string ProcessArchitecture
        {
            get;
            set;
        }
        /// <summary>
        /// 获取当前计算机上的处理器数。
        /// </summary>
        public int ProcessorCount
        {
            get;
            set;
        }

        /// <summary>
        /// 获取操作系统的内存页的字节数。
        /// </summary>
        public int SystemPageSize
        {
            get;
            set;
        }
        /// <summary>
        /// 获取映射到进程上下文的物理内存量。
        /// </summary>
        public long WorkingSet
        {
            get;
            set;
        }
        /// <summary>
        /// 获取系统启动后经过的毫秒数。
        /// </summary>
        public int TickCount
        {
            get;
            set;
        }

        /// <summary>
        /// 运行时长
        /// </summary>
        public string RunTimeLength
        {
            get;
            set;
        }
        /// <summary>
        /// 部署目录
        /// </summary>
        public string Directory
        {
            get;
            set;
        }
        /// <summary>
        /// 系统版本
        /// </summary>
        public string SystemVersion
        {
            get;
            set;
        }
        /// <summary>
        /// 系统版本
        /// </summary>
        public string Version
        {
            get;
            set;
        }
        /// <summary>
        /// 软件厂商
        /// </summary>
        public string Manufacturer
        {
            get;
            set;
        }
        /// <summary>
        /// 网址
        /// </summary>
        public string WebSite
        {
            get;
            set;
        }
        /// <summary>
        /// 更新地址
        /// </summary>
        public string UpdateUrl
        {
            get;
            set;
        }
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public string IPAdress
        {
            get;
            set;
        }
        /// <summary>
        /// 服务器端口
        /// </summary>
        public string Port
        {
            get;
            set;
        }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 总用户数
        /// </summary>
        public int TotalUser
        {
            get;
            set;
        }

        /// <summary>
        /// 总模块数
        /// </summary>
        public int TotalModule
        {
            get;
            set;
        }
        /// <summary>
        /// 总上传文件数
        /// </summary>
        public int TotalUploadFile
        {
            get;
            set;
        }

        /// <summary>
        /// 总日志数
        /// </summary>
        public int TotalLog
        {
            get;
            set;
        }
        /// <summary>
        /// 总岗位角色数
        /// </summary>
        public int TotalRole
        {
            get;
            set;
        }
    }
}
