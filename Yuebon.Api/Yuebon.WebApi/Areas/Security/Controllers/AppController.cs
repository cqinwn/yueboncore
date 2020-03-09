using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// App应用
    /// 
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class AppController : AreaApiController<APP, IAPPService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aPPService"></param>
        public AppController(IAPPService aPPService) : base(aPPService)
        {
        }
        /// <summary>
        /// 根据主键Id获取一个对象信息
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("GetById")]
        [AllowAnonymous]
        public override IActionResult GetById(string id)
        {
            CommonResult result = new CommonResult();

            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                IList<AppOutputDto> list = iService.SelectApp();
                APP info = new APPApp().GetAPP(id);
                AppOutputDto appOutputDto = info.MapTo<AppOutputDto>();
                if (info != null)
                {
                    result.ResData = appOutputDto;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [HttpGet("FindWithPagerRelationUser")]
        public IActionResult FindWithPagerRelationUser(string start, string length)
        {
            CommonResult result = new CommonResult();

            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                PagerInfo pagerInfo = GetPagerInfo();
                List<object> list = iService.FindWithPagerRelationUser("", pagerInfo,"t1.Id",true);
                if (list.Count >0)
                {
                    result.ResData = list;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            }
            return ToJsonContent(result);
        }
    }
}
