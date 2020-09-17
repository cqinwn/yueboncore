using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.IoC;
using Yuebon.Commons.Models;
using Yuebon.Security.IServices;

namespace Yuebon.Security.Application
{
    public class  SequenceApp
    {
        ISequenceService iService = IoCContainer.Resolve<ISequenceService>();
        /// <summary>
        /// 获取新的单据编码
        /// </summary>
        /// <param name="name">单据编码规则名称</param>
        public  string GetSequenceNext(string name)
        {
            CommonResult commonResult = new CommonResult();
            commonResult =iService.GetSequenceNext(name);
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
