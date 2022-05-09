using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Core.App;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 业务编码规则
    /// </summary>
    public class  SequenceApp
    {
        ISequenceService iService = Appsettings.GetService<ISequenceService>();
        static object locker = new object(); 
        /// <summary>
        /// 获取新的业务单据编码
        /// </summary>
        /// <param name="name">单据编码规则名称</param>
        public  string GetSequenceNext(string name)
        {
            lock (locker)
            {
                CommonResult commonResult = new CommonResult();
                commonResult = iService.GetSequenceNext(name);
                if (commonResult.Success)
                {
                    return commonResult.ResData.ToString();
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
