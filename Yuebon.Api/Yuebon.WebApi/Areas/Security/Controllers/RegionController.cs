using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Models;
using Yuebon.Security.Application;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 地区信息
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : AreaApiController<Area, IAreaService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public RegionController(IAreaService _iService) : base(_iService)
        {
        }
        /// <summary>
        /// 获取所有可用的分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllByEnable")]
        public IActionResult GetPrByEnable()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                List<AreaPickerOutputDto> listOutputDto = new AreaApp().GetProvinceToAreaByEnable();
                if (listOutputDto != null)
                {
                    result.ResData = listOutputDto;
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
