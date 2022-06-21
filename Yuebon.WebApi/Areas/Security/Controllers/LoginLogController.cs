using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.AspNetCore.Mvc;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 登录日志
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class LoginLogController : AreaApiController<LoginLog, LoginLogOutputDto, LoginLogInputDto, ILoginLogService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public LoginLogController(ILoginLogService _iService) : base(_iService)
        {
            iService = _iService;
        }

        /// <summary>
        /// 异步分页查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost("FindWithPagerSearchAsync")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> FindWithPagerSearchAsync(SearchLoginLogModel search)
        {
            CommonResult<PageResult<LoginLogOutputDto>> result = new CommonResult<PageResult<LoginLogOutputDto>>();
            result.ResData = await iService.FindWithPagerSearchAsync(search);
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }
    }
}
