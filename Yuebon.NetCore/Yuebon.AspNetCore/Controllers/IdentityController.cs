using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Yuebon.AspNetCore.Controllers
{
    /// <summary>
    /// Identity控制器
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var claims= HttpContext.User.Claims;

            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
