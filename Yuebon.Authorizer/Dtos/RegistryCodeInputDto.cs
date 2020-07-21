using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Yuebon.Commons.Models;
using Yuebon.Authorizer.Models;

namespace Yuebon.Authorizer.Dtos
{
    /// <summary>
    /// 输入对象模型
    /// </summary>
    [AutoMap(typeof(RegistryCode))]
    [Serializable]
    public class RegistryCodeInputDto: IInputDto<string>
    {
        /// <summary>
        /// 设置或获取 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 设置或获取公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 设置或获取联系人
        /// </summary>
        public string LinkMan { get; set; }

        /// <summary>
        /// 设置或获取电话
        /// </summary>
        public string TelPhone { get; set; }

        /// <summary>
        /// 设置或获取软件名称
        /// </summary>
        public string SoftName { get; set; }

        /// <summary>
        /// 设置或获取版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 设置或获取机器码
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// 设置或获取开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 设置或获取到期日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 设置或获取注册码
        /// </summary>
        public string RegistryCode { get; set; }

        /// <summary>
        /// 设置或获取公钥
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 设置或获取私钥
        /// </summary>
        public string PrivateKey { get; set; }

        /// <summary>
        /// 设置或获取备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 设置或获取授权状态
        /// </summary>
        public string AuthorizeStatus { get; set; }

        /// <summary>
        /// 设置或获取是否可用
        /// </summary>
        public bool EnabledMark { get; set; }


    }
}
