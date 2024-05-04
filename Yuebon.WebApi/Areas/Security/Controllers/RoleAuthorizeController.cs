using Yuebon.Commons.Linq;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 角色权限接口
    /// </summary>
    [ApiController]
    [Route("api/Security/[controller]")]
    public class RoleAuthorizeController : AreaApiController<RoleAuthorize, RoleAuthorizeOutputDto, RoleAuthorizeInputDto, IRoleAuthorizeService>
    {
        private readonly IMenuService menuService;
        private readonly IRoleDataService roleDataService;
        private readonly IOrganizeService organizeService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_iService"></param>
        /// <param name="_menuService"></param>
        /// <param name="_roleDataService"></param>
        /// <param name="_organizeService"></param>
        public RoleAuthorizeController(IRoleAuthorizeService _iService, IMenuService _menuService, IRoleDataService _roleDataService, IOrganizeService _organizeService) : base(_iService)
        {
            iService = _iService;
            menuService = _menuService;
            roleDataService = _roleDataService;
            organizeService = _organizeService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(RoleAuthorize info)
        {
            info.Id = IdGeneratorHelper.IdSnowflake();
            info.CreatorTime = DateTime.Now;
            info.CreatorUserId = CurrentUser.UserId;
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
        protected override void OnBeforeUpdate(RoleAuthorize info)
        {
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(RoleAuthorize info)
        {
        }

        /// <summary>
        /// 角色分配权限树
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="itemType"></param>
        /// <returns></returns>
        [HttpGet("GetRoleAuthorizeFunction")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetRoleAuthorizeFunction(string roleId, string itemType)
        {
            CommonResult result = new CommonResult();
            List<long> resultlist = new List<long>();
            List<long> roleIds= roleId.Split(',').AsToList().ConvertAll(s=>long.Parse(s));
            List<int> itemTypes=itemType.Split(",").AsToList().ConvertAll(s=>int.Parse(s));
            IEnumerable<RoleAuthorize> list=await iService.GetListRoleAuthorizeByRoleId(roleIds, itemTypes);
            foreach(RoleAuthorize info in list)
            {
                resultlist.Add(info.ItemId);
            }
            result.ResData = resultlist;
            result.ErrCode = ErrCode.successCode;
            return ToJsonContent(result);
        }


        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="roleinfo">功能权限</param>
        /// <returns></returns>
        [HttpPost("SaveRoleAuthorize")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> SaveRoleAuthorize(RoleAuthorizeDataInputDto roleinfo)
        {
            CommonResult result = new CommonResult();
            try
            {                
                //角色访问菜单和功能
                List<RoleAuthorize> inList = new List<RoleAuthorize>();
                List<Menu> menuList = await menuService.GetMenusByIds(roleinfo.RoleFunctios.AsToList());
                foreach (var menu in menuList)
                {
                   // Menu menu = menuService.GetById(item);
                    if (menu != null)
                    {
                        RoleAuthorize info = new RoleAuthorize();
                        info.ObjectId = roleinfo.RoleId;
                        info.ItemType = (menu.MenuType == "C" || menu.MenuType == "M") ? 1 : 2;
                        info.ObjectType = 1;
                        info.ItemId = menu.Id;
                        info.TenantId = Appsettings.User.TenantId;
                        OnBeforeInsert(info);
                        inList.Add(info);
                    }
                }
                //角色访问数据
                List<RoleData> roleDataList = new List<RoleData>();
                foreach (long item in roleinfo.RoleData)
                {
                    RoleData info = new RoleData();
                    info.RoleId = roleinfo.RoleId;
                    info.AuthorizeData = item;
                    info.DType = "dept";
                    info.TenantId = Appsettings.User.TenantId;
                    roleDataList.Add(info);
                }
                //角色访问系统
                foreach (long item in roleinfo.RoleSystem)
                {
                    RoleAuthorize info = new RoleAuthorize();
                    info.ObjectId = roleinfo.RoleId;
                    info.ItemType = 0;
                    info.ObjectType = 1;
                    info.ItemId = item;
                    info.TenantId = Appsettings.User.TenantId;
                    OnBeforeInsert(info);
                    inList.Add(info);
                }
                result.Success = await iService.SaveRoleAuthorize(roleinfo.RoleId,inList, roleDataList,roleinfo.RoleDataScope);
                if (result.Success)
                {
                    result.ErrCode = ErrCode.successCode;
                }
            }
            catch (Exception ex)
            {
                result.ErrMsg = ex.Message;
            }
            return ToJsonContent(result);
        }

        private List<RoleAuthorize> SubFunction(List<ModuleFunctionOutputDto> list, long roleId)
        {
            List<RoleAuthorize> inList = new List<RoleAuthorize>();
            foreach (ModuleFunctionOutputDto item in list)
            {
                RoleAuthorize info = new RoleAuthorize();
                info.ObjectId = roleId;
                info.ItemType = 1;
                info.ObjectType = 1;
                info.ItemId = item.Id;
                OnBeforeInsert(info);
                inList.Add(info);
                inList.Concat(SubFunction(item.Children, roleId));
            }
            return inList;
        }

        /// <summary>
        /// 获取功能菜单适用于Vue Tree树形
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllFunctionTree")]
        [YuebonAuthorize("List")]
        public async Task<IActionResult> GetAllFunctionTree()
        {
            CommonResult result = new CommonResult();
            try
            {
                List<ModuleFunctionOutputDto> list = await iService.GetAllFunctionTree();
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