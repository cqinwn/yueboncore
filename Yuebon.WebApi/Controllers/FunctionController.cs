using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Commons.Log;
using Yuebon.Commons.Models;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Controllers
{
    /// <summary>
    /// 功能模块接口
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FunctionController: AreaApiController<Menu, MenuOutputDto, MenuInputDto, IMenuService, string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public FunctionController(IMenuService _iService) : base(_iService)
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
                if (CurrentUser != null)
                {
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    List<MenuOutputDto> functions = new List<MenuOutputDto>();
                    functions = JsonConvert.DeserializeObject<List<MenuOutputDto>>(yuebonCacheHelper.Get("User_Function_" + CurrentUser.UserId).ToJson());
                    MenuOutputDto functionOutputDto = functions.Find(s => s.EnCode == enCode);
                    List<MenuOutputDto> nowFunList = new List<MenuOutputDto>();
                    if (functionOutputDto != null)
                    {
                        nowFunList = functions.FindAll(s => s.ParentId == functionOutputDto.Id).OrderBy(s=>s.SortCode).ToList();
                    }
                    result.ErrCode = ErrCode.successCode;
                    result.ResData = nowFunList;
                }
                else
                {
                    result.ErrCode = "40008";
                    result.ErrMsg = ErrCode.err40008;
                }
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