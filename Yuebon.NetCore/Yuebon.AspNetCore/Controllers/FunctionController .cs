using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// 功能接口
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FunctionController : AreaApiController<Function, FunctionOutputDto, IFunctionService,string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public FunctionController(IFunctionService _iService) : base(_iService)
        {
            iService = _iService;
        }

        /// <summary>
        /// 根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限
        /// </summary>
        /// <param name="enCode">菜单功能编码</param>
        /// <returns></returns>
        [HttpGet("GetListByParentEnCode")]
        [YuebonAuthorize("")]
        public async Task<IActionResult> GetListByParentEnCode(string enCode)
        {
            CommonResult result = new CommonResult();
            try
            {
                YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                List<FunctionOutputDto> functions = new List<FunctionOutputDto>();
                functions = JsonConvert.DeserializeObject<List<FunctionOutputDto>>(yuebonCacheHelper.Get("User_Function_" + CurrentUser.UserId).ToJson());
                FunctionOutputDto functionOutputDto = functions.Find(s => s.EnCode == enCode);
                List<FunctionOutputDto> nowFunList = new List<FunctionOutputDto>();
                if (functionOutputDto != null)
                {
                   nowFunList = functions.FindAll(s => s.ParentId == functionOutputDto.Id);
                }
                result.ErrCode = ErrCode.successCode;
                result.ResData = nowFunList;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限,代码生成异常", ex);
                result.ErrCode = ErrCode.failCode;
                result.ErrMsg = "获取模块功能异常";
            }
            return ToJsonContent(result);
        }
    }
}