using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Dtos;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Models;
using Yuebon.Commons.Repositories;
using Yuebon.Commons.Services;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.IServices;
using Yuebon.Security.Models;

namespace Yuebon.Security.Services
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public class OrganizeService: BaseService<Organize, OrganizeOutputDto>, IOrganizeService
    {
        private readonly IOrganizeRepository _repository;
        private readonly ILogService _logService;
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public OrganizeService(IOrganizeRepository organizeRepository, ILogService logService, IUserRepository userRepository)
        {
            repository = organizeRepository;
            _repository = organizeRepository;
            _logService = logService;
            _userRepository = userRepository;
        }


        /// <summary>
        /// 获取组织机构适用于Vue 树形列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrganizeOutputDto>> GetAllOrganizeTreeTable()
        {
            List<OrganizeOutputDto> reslist = new List<OrganizeOutputDto>();
            IEnumerable<Organize> elist = await _repository.GetAllAsync();
            List<Organize> list = elist.OrderBy(t => t.SortCode).ToList();
            List<Organize> oneMenuList = list.FindAll(t => t.ParentId == 0);
            foreach (Organize item in oneMenuList)
            {
                OrganizeOutputDto menuTreeTableOutputDto = new OrganizeOutputDto();
                menuTreeTableOutputDto = item.MapTo<OrganizeOutputDto>();
                menuTreeTableOutputDto.Children = GetSubOrganizes(list, item.Id).ToList<OrganizeOutputDto>();
                reslist.Add(menuTreeTableOutputDto);
            }

            return reslist;
        }


        /// <summary>
        /// 获取子集，递归调用
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        private List<OrganizeOutputDto> GetSubOrganizes(List<Organize> data, long parentId)
        {
            List<OrganizeOutputDto> list = new List<OrganizeOutputDto>();
            OrganizeOutputDto OrganizeOutputDto = new OrganizeOutputDto();
            var ChilList = data.FindAll(t => t.ParentId == parentId);
            foreach (Organize entity in ChilList)
            {
                OrganizeOutputDto = entity.MapTo<OrganizeOutputDto>();
                OrganizeOutputDto.Children = GetSubOrganizes(data, entity.Id).OrderBy(t => t.SortCode).MapTo<OrganizeOutputDto>();
                list.Add(OrganizeOutputDto);
            }
            return list;
        }

        /// <summary>
        /// 获取根节点组织
        /// </summary>
        /// <param name="id">组织Id</param>
        /// <returns></returns>
        public Organize GetRootOrganize(long? id)
        {
           return _repository.GetRootOrganize(id);
        }


        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="idsInfo">主键Id集合</param>
        /// <returns></returns>
        public CommonResult DeleteBatchWhere(DeletesInputDto idsInfo)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                if (idsInfo.Ids[0] != null)
                {
                    if (_userRepository.GetCountByWhere(string.Format("OrganizeId='{0}' or DepartmentId='{0}'", idsInfo.Ids[0])) > 0)
                    {
                        result.ErrMsg = "该机构已有用户数据，不能删除";
                        return result;
                    }
                    IEnumerable<Organize> list = _repository.GetListWhere(string.Format("ParentId='{0}'", idsInfo.Ids[0]));
                    if (list.Count() > 0)
                    {
                        result.ErrMsg = "该机构存在子集数据，不能删除";
                        return result;
                    }
                }
            }
            where = "id in ('" + idsInfo.Ids.Join(",").Trim(',').Replace(",", "','") + "')";
            bool bl = repository.DeleteBatchWhere(where);
            if (bl)
            {
                result.ErrCode = "0";
            }
            return result;
        }

        /// <summary>
        /// 按条件批量删除
        /// </summary>
        /// <param name="idsInfo">主键Id集合</param>
        /// <returns></returns>
        public async Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto idsInfo)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                if (idsInfo.Ids[0].ToString().Length > 0)
                {
                    if(_userRepository.GetCountByWhere(string.Format("OrganizeId='{0}' or DepartmentId='{0}'", idsInfo.Ids[0])) > 0)
                    {
                        result.ErrMsg = "该机构已有用户数据，不能删除";
                        return result;
                    }
                    where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                    IEnumerable<Organize> list = _repository.GetListWhere(where);
                    if (list.Count()>0)
                    {
                        result.ErrMsg = "该机构存在子集数据，不能删除";
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