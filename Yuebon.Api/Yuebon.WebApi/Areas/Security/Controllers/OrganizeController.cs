using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 组织结构接口控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/Security/[controller]")]
    public class OrganizeController : AreaApiController<Organize, IOrganizeService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public OrganizeController(IOrganizeService _iService) : base(_iService)
        {
        }
    }
}