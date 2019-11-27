using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yuebon.WebApp.Commons;
using Yuebon.WebApp.Models;
using Yuebon.WebApp.ViewModels;
using Yuebon.Commons.Helpers;
using Yuebon.Infrastructure.IServices;
using Yuebon.Commons.Json;
using Yuebon.Commons.Models;
using Yuebon.Security.Models;
using Yuebon.Commons.Extend;
using System;
using Yuebon.Commons.Log;
using Yuebon.Commons.Extensions;
using System.Reflection;
using Yuebon.Commons.Cache;
using System.Linq;
using Yuebon.Security.Dtos;
using Yuebon.Security.Application.SSO;
using Yuebon.Commons.IoC;
using Yuebon.Shop.Dtos;

namespace Yuebon.WebApp.Controllers
{
    /// <summary>
    /// 基本控制器，增删改查
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    /// <typeparam name="TService">Service类型</typeparam>
    public class BusinessFController<T, TService> : Controller
        where T : class
        where TService : IService<T>
    {
        


        /// <summary>
        /// 服务接口
        /// </summary>
        public TService iService;

        #region 构造函数及常用
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_iService"></param>
        public BusinessFController(TService _iService)
        {
            iService = _iService;
        }
        #endregion



        #region 异常处理及记录
        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            base.OnActionExecuting(filterContext);
        }
        #endregion


        #region 辅助方法
        
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
        #endregion
    }
}