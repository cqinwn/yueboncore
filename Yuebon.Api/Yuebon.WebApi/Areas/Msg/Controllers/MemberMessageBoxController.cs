using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Yuebon.AspNetCore.Controllers;
using Yuebon.AspNetCore.Models;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Pages;
using Yuebon.Messages.Application;
using Yuebon.Messages.Dtos;
using Yuebon.Messages.IServices;
using Yuebon.Messages.Models;

namespace Yuebon.WebApi.Areas.Msg.Controllers
{
    /// <summary>
    /// 消息接口
    /// </summary>
    [Route("api/Msg/[controller]")]
    public class MemberMessageBoxController : AreaApiController<MemberMessageBox, IMemberMessageBoxService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="service">服务</param>
        public MemberMessageBoxController(IMemberMessageBoxService service) : base(service)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        [HttpGet("GetMemberMsgListByPage")]
        public IActionResult GetMemberMsgListByPage(string start, string length)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                MemberMessageBoxApp app = new MemberMessageBoxApp();

                string condition = "";
                string fieldToSort = "";
                bool descflag = true;
                string strWhere = " Accepter='"+CurrentUser.UserId+"' ";

                #region 构造filter条件                

                condition = strWhere;

                fieldToSort += " IsRead desc,Id ";
                #endregion


                PagerInfo pagerInfo = GetPagerInfo();
                List<MemberMessageBoxOutPutDto> list = iService.FindWithPager(condition, pagerInfo, fieldToSort, descflag).MapTo<MemberMessageBoxOutPutDto>();

                if (list != null)
                {  
                    //构造成Json的格式传递
                    result.ResData = new
                    {
                        recordsTotal = pagerInfo.RecordCount,
                        recordsFiltered = pagerInfo.RecordCount,
                        data = list
                    };
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isread"></param>
        /// <returns></returns>
        [HttpGet("UpdateIsReadStatus")]
        public IActionResult UpdateIsReadStatus(string id, int isread)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                MemberMessageBoxApp app = new MemberMessageBoxApp();
                bool updateresult = app.UpdateIsReadStatus(id, isread,CurrentUser.UserId);
                if (updateresult)
                {

                    result.ResData = true;
                    result.Success = true;
                }
                else
                {
                    result.ErrMsg = ErrCode.err50001;
                    result.ErrCode = "50001";
                }
            }
            return ToJsonContent(result);
        }
       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isread">2:全部,0:未读,1：已读</param>
        /// <returns></returns>
        [HttpGet("GetTotalCounts")]
        public IActionResult GetTotalCounts(int isread)
        {
            CommonResult result = new CommonResult();
            result = CheckToken();
            if (result.ErrCode == ErrCode.successCode)
            {
                MemberMessageBoxApp app = new MemberMessageBoxApp();
                int total = app.GetTotalCounts(isread, CurrentUser.UserId);
                if (total>=0)
                {

                    result.ResData = total;
                    result.Success = true;
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
