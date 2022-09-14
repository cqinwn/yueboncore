using Yuebon.Commons.Tree;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 数据字典接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class ItemsController : AreaApiController<Items, ItemsOutputDto, ItemsInputDto, IItemsService>
    {

        private readonly IItemsDetailService itemsDetailService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_itemsDetailService"></param>
        public ItemsController(IItemsService _iService, IItemsDetailService _itemsDetailService) : base(_iService)
        {
            iService = _iService;
            itemsDetailService=_itemsDetailService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Items info)
        {            
            info.Id = IdGeneratorHelper.IdSnowflake();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
            info.DeleteMark = false;
            if (info.SortCode == null)
            {
                info.SortCode = 99;
            }
        }
        
        /// <summary>
        /// 在更新数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeUpdate(Items info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Items info)
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
        [HttpPost("Insert")]
        [YuebonAuthorize("Add")]
        public override async Task<IActionResult> InsertAsync(ItemsInputDto tinfo)
        {
            CommonResult result = new CommonResult();
            Items isExsit = await iService.GetByEnCodAsynce(tinfo.EnCode);
            if (isExsit != null)
            {
                result.ErrMsg = "字典分类编码不能重复";
                return ToJsonContent(result);
            }
            Items info = tinfo.MapTo<Items>();
            OnBeforeInsert(info);
            long ln = await iService.InsertAsync(info);
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
        /// 按字典分类编码查询树形展开，新增、修改需要
        /// </summary>
        /// <param name="itemCode">数据字典分类编码</param>
        /// <returns></returns>
        [HttpGet("FindTreeSelectJson")]
        [NoPermissionRequired]
        public async Task<IActionResult> FindTreeSelectJson(string itemCode)
        {
            CommonResult result = new CommonResult();
            List<ItemsDetailOutputDto> list = await itemsDetailService.GetItemDetailsByItemCode(itemCode);
            var treeList = new List<TreeSelectModel>();
            foreach (ItemsDetailOutputDto item in list)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.ItemCode;
                treeModel.text = item.ItemName;
                treeModel.parentId = item.ParentId.ToString();
                treeList.Add(treeModel);
            }
            result.ErrCode = ErrCode.err0;
            result.ResData = treeList.TreeSelectJson();
            return ToJsonContent(result);
        }

        /// <summary>
        /// 按字典分类编码查询,Vue element select新增、修改需要
        /// </summary>
        /// <param name="itemCode">数据字典分类编码</param>
        /// <returns></returns>
        [HttpGet("GetListByItemCode")] 
        [NoPermissionRequired]
        public async Task<IActionResult> GetListByItemCode(string itemCode)
        {
            CommonResult result = new CommonResult();
            IEnumerable<ItemsDetailOutputDto> list = await itemsDetailService.GetItemDetailsByItemCode(itemCode);
            result.ErrCode = ErrCode.successCode;
            result.ResData = list;
            return ToJsonContent(result);
        }


        /// <summary>
        /// 异步更新数据
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [YuebonAuthorize("Edit")]
        public override async Task<IActionResult> UpdateAsync(ItemsInputDto tinfo)
        {
            CommonResult result = new CommonResult();
            Items isExsit = await iService.GetByEnCodAsynce(tinfo.EnCode, tinfo.Id);
            if (isExsit != null)
            {
                result.ErrMsg = "字典分类编码不能重复";
                return ToJsonContent(result);
            }
            Items info = iService.GetById(tinfo.Id);
            info.FullName = tinfo.FullName;
            info.EnCode = tinfo.EnCode;
            info.ParentId = tinfo.ParentId;
            info.EnabledMark = tinfo.EnabledMark;
            info.IsTree = tinfo.IsTree;
            info.SortCode = tinfo.SortCode;
            info.Description = tinfo.Description;


            OnBeforeUpdate(info);
            bool bl = await iService.UpdateAsync(info);
            if (bl)
            {
                result.ErrCode = ErrCode.successCode;
                result.ErrMsg = ErrCode.err0;
            }
            else
            {
                result.ErrMsg = ErrCode.err43002;
                result.ErrCode = "43002";
            }
            return ToJsonContent(result);
        }
        /// <summary>
        /// 获取功能菜单适用于Vue 树形列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllItemsTreeTable")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllItemsTreeTable()
        {
            CommonResult result = new CommonResult();
            try
            {
                List<Items> list = await iService.GetAllItemsTreeTable();
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ResData = list;
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取菜单异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }
    }
}