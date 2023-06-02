using NPOI.SS.Formula.Functions;
using Yuebon.Commons.Extensions;
using Yuebon.TMS.Dtos;
using Yuebon.TMS.IServices;
using Yuebon.TMS.Models;

namespace Yuebon.TMSApi.Areas.TMS.Controllers
{
    /// <summary>
    /// 运输计划接口
    /// </summary>
    [ApiController]
    [Route("api/TMS/[controller]")]
    public partial class TransportplanController : AreaApiController<Transportplan, TransportplanOutputDto,TransportplanInputDto,ITransportplanService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public TransportplanController(ITransportplanService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Transportplan info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.TenantId=CurrentUser.TenantId??0;
            info.PrintCount=0;
            info.DeleteMark = false;
            
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Transportplan info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Transportplan info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }

        /// <summary>
        /// 异步新增数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("CreateFromWms")]
        [YuebonAuthorize("Add")]
        public virtual async Task<IActionResult> CreateFromWmsAsync(WmsToTransportplanInputDto tinfo)
        {
            CommonResult result = new CommonResult();
            Transportplan info = tinfo.MapTo<Transportplan>();
            OnBeforeInsert(info);
            long ln = await iService.InsertAsync(info).ConfigureAwait(false);
            if (ln > 0)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43001;
                result.ErrCode = "43001";
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("UpdateFromWms")]
        [YuebonAuthorize("Edit")]
        public virtual async Task<IActionResult> UpdateFromWmsAsync(WmsToTransportplanInputDto tinfo)
        {
            CommonResult result = new CommonResult();
            if (!string.IsNullOrEmpty(tinfo.TransportNo))
            {
                Transportplan info =await iService.GetByTransportNo(tinfo.TransportNo);
                info.PlanReceiptdate = tinfo.PlanReceiptdate;
                OnBeforeUpdate(info);
                bool blResult = await iService.UpdateAsync(info);
                if (blResult)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43001;
                    result.ErrCode = "43001";
                }
            }
            return ToJsonContent(result);
        }
    }
}