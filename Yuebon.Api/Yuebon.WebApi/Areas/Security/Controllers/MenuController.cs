using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 模块菜单
    /// 
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class MenuController : AreaApiController<Menu, IMenuService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public MenuController(IMenuService _iService) : base(_iService)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Menu info)
        {
            if (info != null)
            {

            //留给子类对参数对象进行修改
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            }
        }

        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Menu info)
        {
            //留给子类对参数对象进行修改 
            info.LastModifyTime = DateTime.Now;
            info.LastModifyUserId = CurrentUser.UserId;
        }
    }
}