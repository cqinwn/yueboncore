using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.Extend;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// �˵�
    /// </summary>
    public class MenuService: BaseService<Menu, MenuOutputDto>, IMenuService
    {
        private readonly IMenuRepository _MenuRepository;
        private readonly IUserRepository userRepository;
        private readonly ISystemTypeRepository systemTypeRepository;
        private readonly IRoleAuthorizeRepository roleAuthorizeRepository;
        private readonly ILogService _logService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="_userRepository"></param>
        /// <param name="_roleAuthorizeRepository"></param>
        /// <param name="_systemTypeRepository"></param>
        /// <param name="logService"></param>
        public MenuService(IMenuRepository menuRepository,IUserRepository _userRepository, IRoleAuthorizeRepository _roleAuthorizeRepository, ISystemTypeRepository _systemTypeRepository, ILogService logService)
        {
            repository=menuRepository;
            _MenuRepository = menuRepository;
            userRepository = _userRepository;
            roleAuthorizeRepository = _roleAuthorizeRepository;
            systemTypeRepository = _systemTypeRepository;
            _logService = logService;
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
            
            var user = userRepository.Get(userId);
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
            if (!string.IsNullOrEmpty(systemTypeId.ToString()))
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
        public List<Menu> GetFunctions(string roleIds, long typeID,bool isMenu=false)
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
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
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
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
            bool bl = await repository.DeleteBatchWhereAsync(where);
            if (bl)
            {
                result.ErrCode = "0";
            }
            return result;
        }
    }
}