using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Yuebon.WebApp.ViewModels;
using Yuebon.Commons.Json;
using Yuebon.Security.Models;
using Yuebon.Security.Dtos;
namespace Yuebon.WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>

    [Controller]
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前登录的管理员用户属性
        /// </summary>
        public UserLoginDto CurrentUser =new UserLoginDto();

        ///// <summary>
        ///// 
        ///// 当前登录的会员用户属性
        ///// </summary>
        //public MembersDto CurrentMembers = new MembersDto();


        /// <summary>
        /// 把object对象转换为ContentResult
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        protected IActionResult ToJsonContent(object obj)
        {
            string result = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return Content(obj.ToJson());
        }

    }
}