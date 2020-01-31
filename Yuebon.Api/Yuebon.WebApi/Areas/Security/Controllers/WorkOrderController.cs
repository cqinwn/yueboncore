using Microsoft.AspNetCore.Mvc;
using Yuebon.AspNetCore.Controllers;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 工单接口控制器
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class WorkOrderController : AreaApiController<WorkOrder, IWorkOrderService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public WorkOrderController(IWorkOrderService _iService) : base(_iService)
        {
            iService = _iService;
        }

    }
}