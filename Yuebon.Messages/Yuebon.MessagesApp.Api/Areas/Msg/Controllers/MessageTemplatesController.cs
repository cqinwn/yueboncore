using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Linq;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;

namespace Yuebon.MessagesApp.Api.Areas.Msg.Controllers
{
    /// <summary>
    /// 消息模板
    /// </summary>
    [Route("api/Msg/[controller]")]
    public class MessageTemplatesController : AreaApiController<MessageTemplates, IMessageTemplatesService>
    {
        public MessageTemplatesController(IMessageTemplatesService _iService) : base(_iService)
        {
        }

        /// <summary>
        /// 获取微信小程序订阅消息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListByUseInWxApplet")]
        public IActionResult GetListByUseInWxApplet()
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                string sqlwhere = "UseInWxApplet=1";
                List<MessageTemplates> tempList = iService.GetListWhere(sqlwhere).AsToList();
                List<MessageTemplatesOuputDto> list = tempList.MapTo<MessageTemplatesOuputDto>();
                result.ResData = list;
                result.ErrCode = ErrCode.successCode;
            }
            return ToJsonContent(result);
        }
    }
}
