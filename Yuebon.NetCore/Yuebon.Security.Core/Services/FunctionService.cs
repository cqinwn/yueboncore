using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Dtos;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Pages;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    public class FunctionService: BaseService<Function, FunctionOutputDto, string>, IFunctionService
    {
        private readonly IFunctionRepository functionRepository;
        private readonly IUserRepository userRepository;
        private readonly ISystemTypeRepository systemTypeRepository;
        private readonly ILogService _logService;
        public FunctionService(IFunctionRepository repository, ISystemTypeRepository _systemTypeRepository, ILogService logService) : base(repository)
        {
            functionRepository = repository;
            systemTypeRepository = _systemTypeRepository;
            _logService = logService;
            functionRepository.OnOperationLog += _logService.OnOperationLog;
        }

        /// <summary>
        /// 根据角色ID字符串（逗号分开)和系统类型ID，获取对应的操作功能列表
        /// </summary>
        /// <param name="roleIDs">角色ID</param>
        /// <param name="typeID">系统类型ID</param>
        /// <returns></returns>
        public IEnumerable<Function> GetFunctions(string roleIDs, string typeID)
        {
            return functionRepository.GetFunctions(roleIDs, typeID);
        }

        /// <summary>
        /// 根据父级功能编码查询所有子集功能，主要用于页面操作按钮权限
        /// </summary>
        /// <param name="enCode">菜单功能编码</param>
        /// <returns></returns>
        public async Task<IEnumerable<FunctionOutputDto>> GetListByParentEnCode(string enCode)
        {
            string where = string.Format("EnCode='{0}'",enCode);
            Function function = await functionRepository.GetWhereAsync(where);
            where = string.Format("ParentId='{0}'", function.ParentId);
            IEnumerable<Function> list = await functionRepository.GetAllByIsNotEnabledMarkAsync(where);
            return list.MapTo<FunctionOutputDto>().ToList();
        }



        /// <summary>
        /// 获取功能菜单适用于Vue 树形列表
        /// </summary>
        /// <param name="systemTypeId">子系统Id</param>
        /// <returns></returns>
        public async Task<List<FunctionTreeTableOutputDto>> GetAllFunctionTreeTable(string systemTypeId)
        {
            string where = "1=1";
            List<FunctionTreeTableOutputDto> reslist = new List<FunctionTreeTableOutputDto>();
            if (!string.IsNullOrEmpty(systemTypeId))
            {
                IEnumerable<Function> elist = await functionRepository.GetListWhereAsync("SystemTypeId='" + systemTypeId + "'");
                List<Function> list = elist.OrderBy(t => t.SortCode).ToList();
                List<Function> oneMenuList = list.FindAll(t => t.ParentId == "");
                foreach (Function item in oneMenuList)
                {
                    FunctionTreeTableOutputDto menuTreeTableOutputDto = new FunctionTreeTableOutputDto();
                    menuTreeTableOutputDto = item.MapTo<FunctionTreeTableOutputDto>();
                    menuTreeTableOutputDto.Children = GetSubMenus(list, item.Id).ToList<FunctionTreeTableOutputDto>();
                    reslist.Add(menuTreeTableOutputDto);
                }
            }
            else
            {
                IEnumerable<SystemType> listSystemType = await systemTypeRepository.GetListWhereAsync(where);
                foreach (SystemType systemType in listSystemType)
                {
                    FunctionTreeTableOutputDto menuTreeTableOutputDto = new FunctionTreeTableOutputDto();
                    menuTreeTableOutputDto.Id = systemType.Id;
                    menuTreeTableOutputDto.FullName = systemType.FullName;
                    menuTreeTableOutputDto.EnCode = systemType.EnCode;
                    menuTreeTableOutputDto.UrlAddress = systemType.Url;
                    menuTreeTableOutputDto.EnabledMark = systemType.EnabledMark;

                    menuTreeTableOutputDto.SystemTag = true;

                    IEnumerable<Function> elist = await functionRepository.GetListWhereAsync("SystemTypeId='" + systemType.Id + "'");
                    if (elist.Count() > 0)
                    {
                        List<Function> list = elist.OrderBy(t => t.SortCode).ToList();
                        menuTreeTableOutputDto.Children = GetSubMenus(list, "").ToList<FunctionTreeTableOutputDto>();
                    }
                    reslist.Add(menuTreeTableOutputDto);
                }
            }
            return reslist;
        }


        /// <summary>
        /// 获取子功能，递归调用
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        private List<FunctionTreeTableOutputDto> GetSubMenus(List<Function> data, string parentId)
        {
            List<FunctionTreeTableOutputDto> list = new List<FunctionTreeTableOutputDto>();
            FunctionTreeTableOutputDto menuTreeTableOutputDto = new FunctionTreeTableOutputDto();
            var ChilList = data.FindAll(t => t.ParentId == parentId);
            foreach (Function entity in ChilList)
            {
                menuTreeTableOutputDto = entity.MapTo<FunctionTreeTableOutputDto>();
                menuTreeTableOutputDto.Children = GetSubMenus(data, entity.Id).OrderBy(t => t.SortCode).MapTo<FunctionTreeTableOutputDto>();
                list.Add(menuTreeTableOutputDto);
            }
            return list;
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="search">查询的条件</param>
        /// <returns>指定对象的集合</returns>
        public override async Task<PageResult<FunctionOutputDto>> FindWithPagerAsync(SearchInputDto<Function> search)
        {
            bool order = search.Order == "asc" ? false : true;
            string where = GetDataPrivilege(false);
            if (!string.IsNullOrEmpty(search.EnCode))
            {
                Function function = await repository.GetWhereAsync("EnCode='" + search.EnCode + "'");
                if (function != null)
                {
                    where += " and ParentId='" + function.Id + "'";
                }
            }
            if (!string.IsNullOrEmpty(search.Keywords))
            {
                where += " and (FullName like '%" + search.Keywords + "%' or EnCode like '%" + search.Keywords + "%')";
            }
            PagerInfo pagerInfo = new PagerInfo
            {
                CurrenetPageIndex = search.CurrenetPageIndex,
                PageSize = search.PageSize
            };
            List<Function> list = await repository.FindWithPagerAsync(where, pagerInfo, search.Sort, order);
            PageResult<FunctionOutputDto> pageResult = new PageResult<FunctionOutputDto>
            {
                CurrentPage = pagerInfo.CurrenetPageIndex,
                Items = list.MapTo<FunctionOutputDto>(),
                ItemsPerPage = pagerInfo.PageSize,
                TotalItems = pagerInfo.RecordCount
            };
            return pageResult;
        }
    }
}