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
        /// 
        /// </summary>
        public string OSDescription
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
