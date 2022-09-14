﻿namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 文件管理
    /// </summary>
    [Route("api/Security/[controller]")]
    [ApiController]
    public class UploadFileController : AreaApiController<UploadFile, UploadFileOutputDto, UploadFileInputDto, IUploadFileService>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        public UploadFileController(IUploadFileService _iService) : base(_iService)
        {
            iService = _iService;
        }


        /// <summary>
        /// 异步批量物理删除
        /// </summary>
        /// <param name="info">主键Id数组</param>
        [HttpDelete("DeleteBatchAsync")]
        [YuebonAuthorize("Delete")]
        public override async Task<IActionResult> DeleteBatchAsync(DeletesInputDto info)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            where = "id in (" + String.Join(",", info.Ids) + ")";

            if (!string.IsNullOrEmpty(where))
            {
                foreach (long item in info.Ids)
                {
                    if (string.IsNullOrEmpty(item.ToString())) continue;
                    UploadFile uploadFile = iService.GetById(item);
                    YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
                    SysSetting sysSetting = yuebonCacheHelper.Get("SysSetting").ToJson().ToObject<SysSetting>();
                    if (uploadFile != null)
                    {
                        if (System.IO.File.Exists(sysSetting.LocalPath + "/" + uploadFile.FilePath))
                            System.IO.File.Delete(sysSetting.LocalPath + "/" + uploadFile.FilePath);
                        if (!string.IsNullOrEmpty(uploadFile.Thumbnail))
                        {
                            if (System.IO.File.Exists(sysSetting.LocalPath + "/" + uploadFile.Thumbnail))
                                System.IO.File.Delete(sysSetting.LocalPath + "/" + uploadFile.Thumbnail);
                        }
                    }
                }
                bool bl = await iService.DeleteBatchWhereAsync(where).ConfigureAwait(false);
                if (bl)
                {
                    result.ErrCode = ErrCode.successCode;
                    result.ErrMsg = ErrCode.err0;
                }
                else
                {
                    result.ErrMsg = ErrCode.err43003;
                    result.ErrCode = "43003";
                }
            }
            return ToJsonContent(result);
        }

    }
}