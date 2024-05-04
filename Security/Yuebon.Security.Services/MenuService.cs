using Yuebon.Commons.Core.App;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Log;
using Yuebon.Commons.Tree;

namespace Yuebon.Security.Services;

/// <summary>
/// �˵�
/// </summary>
public class MenuService: BaseService<Menu, MenuOutputDto>, IMenuService
{
    private readonly IMenuRepository _MenuRepository;
    private readonly IUserRepository userRepository;
    private readonly ISystemTypeRepository systemTypeRepository;
    private readonly IRoleAuthorizeRepository roleAuthorizeRepository;
    private readonly IRoleRepository _roleRepository;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="menuRepository"></param>
    /// <param name="_userRepository"></param>
    /// <param name="_roleAuthorizeRepository"></param>
    /// <param name="_systemTypeRepository"></param>
    /// <param name="roleRepository"></param>
    public MenuService(IMenuRepository menuRepository,IUserRepository _userRepository, IRoleAuthorizeRepository _roleAuthorizeRepository, ISystemTypeRepository _systemTypeRepository, IRoleRepository roleRepository)
    {
        repository=menuRepository;
        _MenuRepository = menuRepository;
        userRepository = _userRepository;
        roleAuthorizeRepository = _roleAuthorizeRepository;
        systemTypeRepository = _systemTypeRepository;
        _roleRepository= roleRepository;
    }

    /// <summary>
    /// �����û���ȡ���ܲ˵�
    /// </summary>
    /// <param name="userId">�û�ID</param>
    /// <returns></returns>
    public List<Menu> GetMenuByUser(long userId)
    {
        List<Menu> result = new List<Menu>();
        List<Menu> allMenuls = new List<Menu>();
        List<Menu> subMenuls = new List<Menu>();
        string where = string.Format("Layers=1");
        IEnumerable<Menu> allMenus = _MenuRepository.GetAllByIsNotDeleteAndEnabledMark();
        allMenuls = allMenus.ToList();
        
        var user = userRepository.GetById(userId);
        if (user == null)
            return result;
        var userRoles = user.RoleId;
        where = string.Format("ItemType = 1 and ObjectType = 1 and ObjectId='{0}'",userRoles);
        var Menus = roleAuthorizeRepository.GetListWhere(where);
        foreach (RoleAuthorize item in Menus)
        {
            Menu MenuEntity = allMenuls.Find(t => t.Id == item.ItemId);
            if (MenuEntity != null)
            {
                result.Add(MenuEntity);
            }
        }
        return result.OrderBy(t => t.SortCode).ToList();
    }


    /// <summary>
    /// ��ȡ���ܲ˵�������Vue �����б�
    /// </summary>
    /// <param name="systemTypeId">��ϵͳId</param>
    /// <returns></returns>
    public async Task<List<MenuTreeTableOutputDto>> GetAllMenuTreeTable(long systemTypeId)
    {
        string where = "1=1";
        List<MenuTreeTableOutputDto> reslist = new List<MenuTreeTableOutputDto>();
        if (systemTypeId!=0)
        {
            IEnumerable<Menu> elist = await _MenuRepository.GetListWhereAsync("SystemTypeId=" + systemTypeId);
            List<Menu> list = elist.OrderBy(t => t.SortCode).ToList();
            List<Menu> oneMenuList = list.FindAll(t => t.ParentId == 0);
            foreach (Menu item in oneMenuList)
            {
                MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();

                menuTreeTableOutputDto = item.MapTo<MenuTreeTableOutputDto>();
                menuTreeTableOutputDto.Id = item.Id;
                menuTreeTableOutputDto.FullName = item.FullName;
                menuTreeTableOutputDto.EnCode = item.EnCode;
                menuTreeTableOutputDto.UrlAddress = item.UrlAddress;
                menuTreeTableOutputDto.EnabledMark = item.EnabledMark;
                menuTreeTableOutputDto.Children = GetSubMenus(list, item.Id).ToList<MenuTreeTableOutputDto>();
                reslist.Add(menuTreeTableOutputDto);
            }

        }
        else
        {
            IEnumerable<SystemType> listSystemType = await systemTypeRepository.GetListWhereAsync(where);

            foreach (SystemType systemType in listSystemType)
            {
                MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();
                menuTreeTableOutputDto.Id = systemType.Id;
                menuTreeTableOutputDto.FullName = systemType.FullName;
                menuTreeTableOutputDto.EnCode = systemType.EnCode;
                menuTreeTableOutputDto.UrlAddress = systemType.Url;
                menuTreeTableOutputDto.EnabledMark = systemType.EnabledMark;

                menuTreeTableOutputDto.SystemTag = true;

                IEnumerable<Menu> elist = await _MenuRepository.GetListWhereAsync("SystemTypeId=" + systemType.Id);
                if (elist.Count() > 0)
                {
                    List<Menu> list = elist.OrderBy(t => t.SortCode).ToList();
                    menuTreeTableOutputDto.Children = GetSubMenus(list, 0).ToList<MenuTreeTableOutputDto>();
                }
                reslist.Add(menuTreeTableOutputDto);
            }
        }
        return reslist;
    }


    /// <summary>
    /// ��ȡ�Ӳ˵����ݹ����
    /// </summary>
    /// <param name="data"></param>
    /// <param name="parentId">����Id</param>
    /// <returns></returns>
    private List<MenuTreeTableOutputDto> GetSubMenus(List<Menu> data, long parentId)
    {
        List<MenuTreeTableOutputDto> list = new List<MenuTreeTableOutputDto>();
        MenuTreeTableOutputDto menuTreeTableOutputDto = new MenuTreeTableOutputDto();
        var ChilList = data.FindAll(t => t.ParentId == parentId);
        foreach (Menu entity in ChilList)
        {
            menuTreeTableOutputDto = entity.MapTo<MenuTreeTableOutputDto>();
            menuTreeTableOutputDto.Children = GetSubMenus(data, entity.Id).OrderBy(t => t.SortCode).MapTo<MenuTreeTableOutputDto>();
            list.Add(menuTreeTableOutputDto);
        }
        return list;
    }

    /// <summary>
    /// ���ݽ�ɫID�ַ��������ŷֿ�)��ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
    /// </summary>
    /// <param name="roleIds">��ɫID</param>
    /// <param name="typeID">ϵͳ����ID</param>
    /// <param name="isMenu">�Ƿ��ǲ˵�</param>
    /// <returns></returns>
    public List<Menu> GetFunctions(List<long> roleIds, long typeID,bool isMenu=false)
    {
        return _MenuRepository.GetFunctions(roleIds, typeID, isMenu).ToList();
    }


    /// <summary>
    /// ����ϵͳ����ID����ȡ��Ӧ�Ĳ��������б�
    /// </summary>
    /// <param name="typeID">ϵͳ����ID</param>
    /// <returns></returns>
    public List<Menu> GetFunctions(long typeID)
    {
        return _MenuRepository.GetFunctions(typeID).ToList();
    }


    /// <summary>
    /// ���ݸ������ܱ����ѯ�����Ӽ����ܣ���Ҫ����ҳ�������ťȨ��
    /// </summary>
    /// <param name="enCode">�˵����ܱ���</param>
    /// <returns></returns>
    public async Task<IEnumerable<MenuOutputDto>> GetListByParentEnCode(string enCode)
    {
        string where = string.Format("EnCode='{0}'", enCode);
        Menu function = await repository.GetWhereAsync(where);
        where = string.Format("ParentId='{0}'", function.ParentId);
        IEnumerable<Menu> list = await repository.GetAllByIsNotEnabledMarkAsync(where);
        return list.MapTo<MenuOutputDto>().ToList();
    }
    /// <summary>
    /// ����������ɾ��
    /// </summary>
    /// <param name="idsInfo">����Id����</param>
    /// <returns></returns>
    public CommonResult DeleteBatchWhere(DeletesInputDto idsInfo)
    {
        CommonResult result = new CommonResult();
        string where = string.Empty;
        for (int i = 0; i < idsInfo.Ids.Length; i++)
        {
            if (idsInfo.Ids[0] != null)
            {
                where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                IEnumerable<Menu> list = _MenuRepository.GetListWhere(where);
                if (list.Count()>0)
                {
                    result.ErrMsg = "���ܴ����Ӽ����ݣ�����ɾ��";
                    return result;
                }
            }
        }
        where = "id in (" +String.Join("," ,idsInfo.Ids)+ ")";
        bool bl = repository.DeleteBatchWhere(where);
        if (bl)
        {
            result.ErrCode ="0";
        }
        return result;
    }

    /// <summary>
    /// ����������ɾ��
    /// </summary>
    /// <param name="idsInfo">����Id����</param>
    /// <returns></returns>
    public async Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto idsInfo)
    {
        CommonResult result = new CommonResult();
        string where =string.Empty;
        for (int i =0;i< idsInfo.Ids.Length;i++)
        {
            if (idsInfo.Ids[0].ToString().Length>0)
            {
                where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                IEnumerable<Menu> list = _MenuRepository.GetListWhere(where);
                if (list.Count()>0)
                {
                    result.ErrMsg = "���ܴ����Ӽ����ݣ�����ɾ��";
                    return result;
                }
            }
        }
        where = "id in (" + String.Join(",", idsInfo.Ids) + ")";
        bool bl = await repository.DeleteBatchWhereAsync(where);
        if (bl)
        {
            result.ErrCode = "0";
        }
        return result;
    }




    /// <summary>
    /// �����û���ɫIDs����ȡ��Ӧ�Ĺ����б�
    /// </summary>
    /// <param name="systemId">ϵͳ����ID/��ϵͳID</param>
    /// <returns></returns>
    public List<UserVisitMenus> GetFunctionsBySystem(long systemId)
    {
        List<UserVisitMenus> functions = new List<UserVisitMenus>();
        functions = GetFunctions(systemId).ToList().MapTo<UserVisitMenus>();
        return functions;
    }



    /// <summary>
    /// �����û�ID����ȡ��Ӧ�Ĺ����б�
    /// </summary>
    /// <param name="userID">�û�ID</param>
    /// <param name="typeID">ϵͳ���ID</param>
    /// <returns></returns>
    public async Task<List<UserVisitMenus>> GetFunctionsByUser(long userId, long typeID)
    {
       
        List<long> roleIds =await _roleRepository.GetRoleIdsByUserId(userId);
        List<UserVisitMenus> functions = new List<UserVisitMenus>();
        if (roleIds.Count != 0)
        {
            functions = GetFunctions(roleIds, typeID).ToList().MapTo<UserVisitMenus>();
        }
        return functions;
    }
    #region ��ȡ Vue Router
    /// <summary>
    /// �����û���ɫ��ȡ�˵���VueRouterģʽ
    /// </summary>
    /// <param name="roleIds">��ɫID</param>
    /// <param name="systemCode">ϵͳ���ʹ�����ϵͳ����</param>
    /// <returns></returns>
    public List<VueRouterModel> GetVueRouter(List<long> roleIds, string systemCode)
    {
        List<VueRouterModel> list = new List<VueRouterModel>();
        try
        {
            SystemType systemType = systemTypeRepository.GetByCode(systemCode);
            List<Menu> listMenu = GetMenusByRole(roleIds, systemType.Id).OrderBy(t => t.SortCode).ToList();
            List<MenuOutputDto> listTree = BuildTreeMenus(listMenu, 0);
            list = BuildMenus(listTree);
        }
        catch (Exception ex)
        {
            Log4NetHelper.Error("�����û���ɫ����ϵͳ�����ȡ�˵��쳣", ex);
        }
        return list;
    }


    /// <summary>
    /// �����˵���
    /// </summary>
    /// <param name="menus">�˵��б�</param>
    /// <param name="parentId">����Id</param>
    /// <returns></returns>
    public List<MenuOutputDto> BuildTreeMenus(List<Menu> menus, long parentId)
    {
        List<MenuOutputDto> resultList = new List<MenuOutputDto>();
        List<Menu> childNodeList = menus.FindAll(t => t.ParentId == parentId);
        foreach (Menu menu in childNodeList)
        {
            MenuOutputDto menuOutputDto = new MenuOutputDto();
            menuOutputDto = menu.MapTo<MenuOutputDto>();
            List<Menu> subChildNodeList = menus.FindAll(t => t.ParentId == menu.Id);
            if (subChildNodeList.Count > 0)
            {
                menuOutputDto.SubMenu = BuildTreeMenus(menus, menu.Id);
            }
            resultList.Add(menuOutputDto);
        }

        return resultList;
    }
    /// <summary>
    /// ����ǰ��·������Ҫ�Ĳ˵�
    /// </summary>
    /// <param name="menus">�˵��б�</param>
    /// <returns></returns>
    public List<VueRouterModel> BuildMenus(List<MenuOutputDto> menus)
    {
        List<VueRouterModel> routers = new List<VueRouterModel>();
        foreach (MenuOutputDto menu in menus)
        {
            VueRouterModel router = new VueRouterModel();
            router.hidden = menu.IsShow ? false : true;
            router.name = GetRouteName(menu);
            router.path = GetRouterPath(menu);
            router.component = GetComponent(menu);
            Meta meta = new Meta(menu.FullName, menu.Icon == null ? "" : menu.Icon, menu.IsCache);
            if (!menu.MenuType.Contains("F") && Appsettings.app(new string[] { "AppSetting", "OpenGlobal" }).ToBool())
            {
                meta.title = menu.EnCode;
            }
            if (!menu.IsShow && menu.MenuType.Contains("M"))
            {
                meta.activeMenu = menu.ActiveMenu;
            }
            router.meta = meta;
            List<MenuOutputDto> cMenus = menu.SubMenu;
            if (cMenus != null && menu.MenuType == "C")
            {
                router.alwaysShow = true;
                router.redirect = "noRedirect";
                router.children = BuildMenus(cMenus);
            }
            else if (IsMeunDoc(menu))
            {
                List<VueRouterModel> childrenList = new List<VueRouterModel>();
                VueRouterModel childrenRouter = new VueRouterModel();
                childrenRouter.path = menu.UrlAddress;
                childrenRouter.component = menu.Component;
                childrenRouter.name = menu.EnCode;
                childrenRouter.meta = new Meta(menu.FullName, menu.Icon == null ? "" : menu.Icon, menu.IsCache);
                childrenRouter.meta = meta;
                childrenList.Add(childrenRouter);
                router.children = childrenList;
            }
            else if (IsMeunFrame(menu) && cMenus != null)
            {
                if (!menu.IsShow)
                {
                    router.hidden = true;
                }
                router.children = BuildMenus(cMenus);
            }
            routers.Add(router);
        }

        return routers;
    }
    /// <summary>
    /// ��ȡ·������
    /// </summary>
    /// <param name="menu">�˵���Ϣ</param>
    /// <returns></returns>
    public String GetRouteName(MenuOutputDto menu)
    {
        String routerName = menu.EnCode;
        // ������������һ��Ŀ¼������ΪĿ¼��
        if (IsMeunDoc(menu))
        {
            routerName = "";
        }
        return routerName;
    }
    /// <summary>
    /// ��ȡ·�ɵ�ַ
    /// </summary>
    /// <param name="menu">�˵���Ϣ</param>
    /// <returns></returns>
    public String GetRouterPath(MenuOutputDto menu)
    {
        String routerPath = menu.UrlAddress;
        // ������������һ��Ŀ¼������ΪĿ¼��
        if (0 == menu.ParentId && menu.MenuType == "C" && !menu.IsFrame)
        {
            routerPath = menu.UrlAddress;// "/" + menu.EnCode;
        }
        // ������������һ��Ŀ¼������Ϊ�˵���
        else if (IsMeunDoc(menu))
        {
            routerPath = "/";
        }
        return routerPath;
    }
    /// <summary>
    /// ��ȡ�����Ϣ
    /// </summary>
    /// <param name="menu">�˵���Ϣ</param>
    /// <returns></returns>
    public String GetComponent(MenuOutputDto menu)
    {
        String component = "Layout";
        if (!string.IsNullOrEmpty(menu.Component) && IsMeunFrame(menu) && !IsMeunDoc(menu))
        {
            component = menu.Component;
        }
        else if (string.IsNullOrEmpty(menu.Component) && IsParentView(menu))
        {
            component = "ParentView";
        }
        return component;
    }
    /// <summary>
    /// �Ƿ�Ϊ�˵��ڲ���ת,������һ��Ŀ¼
    /// </summary>
    /// <param name="menu">�˵���Ϣ</param>
    /// <returns></returns>
    public bool IsMeunDoc(MenuOutputDto menu)
    {
        return menu.ParentId == 0 && menu.MenuType == "M" && !menu.IsFrame;
    }
    /// <summary>
    /// �Ƿ�Ϊ�˵��ڲ���ת
    /// </summary>
    /// <param name="menu">�˵���Ϣ</param>
    /// <returns></returns>
    public bool IsMeunFrame(MenuOutputDto menu)
    {
        return menu.MenuType == "M" && !menu.IsFrame;
    }
    /// <summary>
    /// �Ƿ�Ϊparent_view���
    /// </summary>
    /// <param name="menu">�˵���Ϣ</param>
    /// <returns></returns>
    public bool IsParentView(MenuOutputDto menu)
    {
        return menu.ParentId != 0 && menu.MenuType == "C";
    }
    #endregion


    /// <summary>
    /// �����û���ȡ���ܲ˵�
    /// </summary>
    /// <param name="roleIds">�û���ɫID</param>
    /// <param name="systemId">ϵͳ����ID/��ϵͳID</param>
    /// <returns></returns>
    private List<Menu> GetMenusByRole(List<long> roleIds, long systemId)
    {
        List<Menu> menuListResult = new List<Menu>();
        if (roleIds == null)
        {
            menuListResult = GetFunctions(null, systemId, true);
        }
        else
        {
            menuListResult = GetFunctions(roleIds, systemId, true);
        }
        return menuListResult;
    }


    /// <summary>
    /// ���ݹ��ܲ˵�Id���ϲ�ѯ
    /// </summary>
    /// <param name="ids">Id����</param>
    /// <returns></returns>
    public async Task<List<Menu>> GetMenusByIds(List<long> ids)
    {
        return await _baseRepository.Db.Queryable<Menu>().Where(m => ids.Contains(m.Id)).ToListAsync();
    }
}