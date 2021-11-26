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
    /// ��֯����
    /// </summary>
    public class OrganizeService: BaseService<Organize, OrganizeOutputDto, string>, IOrganizeService
    {
        private readonly IOrganizeRepository _repository;
        private readonly ILogService _logService;
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logService"></param>
        public OrganizeService(IOrganizeRepository repository, ILogService logService, IUserRepository userRepository) : base(repository)
        {
            _repository = repository;
            _logService = logService;
            _userRepository = userRepository;
        }


        /// <summary>
        /// ��ȡ��֯����������Vue �����б�
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrganizeOutputDto>> GetAllOrganizeTreeTable()
        {
            List<OrganizeOutputDto> reslist = new List<OrganizeOutputDto>();
            IEnumerable<Organize> elist = await _repository.GetAllAsync();
            List<Organize> list = elist.OrderBy(t => t.SortCode).ToList();
            List<Organize> oneMenuList = list.FindAll(t => t.ParentId == "");
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
        /// ��ȡ�Ӽ����ݹ����
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId">����Id</param>
        /// <returns></returns>
        private List<OrganizeOutputDto> GetSubOrganizes(List<Organize> data, string parentId)
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
        /// ��ȡ���ڵ���֯
        /// </summary>
        /// <param name="id">��֯Id</param>
        /// <returns></returns>
        public Organize GetRootOrganize(string id)
        {
           return _repository.GetRootOrganize(id);
        }


        /// <summary>
        /// ����������ɾ��
        /// </summary>
        /// <param name="idsInfo">����Id����</param>
        /// <param name="trans">�������</param>
        /// <returns></returns>
        public CommonResult DeleteBatchWhere(DeletesInputDto idsInfo, IDbTransaction trans = null)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                if (idsInfo.Ids[0] != null)
                {
                    if (_userRepository.GetCountByWhere(string.Format("OrganizeId='{0}' or DepartmentId='{0}'", idsInfo.Ids[0])) > 0)
                    {
                        result.ErrMsg = "�û��������û����ݣ�����ɾ��";
                        return result;
                    }
                    IEnumerable<Organize> list = _repository.GetListWhere(string.Format("ParentId='{0}'", idsInfo.Ids[0]));
                    if (list.Count() > 0)
                    {
                        result.ErrMsg = "�û��������Ӽ����ݣ�����ɾ��";
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
        /// ����������ɾ��
        /// </summary>
        /// <param name="idsInfo">����Id����</param>
        /// <param name="trans">�������</param>
        /// <returns></returns>
        public async Task<CommonResult> DeleteBatchWhereAsync(DeletesInputDto idsInfo, IDbTransaction trans = null)
        {
            CommonResult result = new CommonResult();
            string where = string.Empty;
            for (int i = 0; i < idsInfo.Ids.Length; i++)
            {
                if (idsInfo.Ids[0].ToString().Length > 0)
                {
                    if(_userRepository.GetCountByWhere(string.Format("OrganizeId='{0}' or DepartmentId='{0}'", idsInfo.Ids[0])) > 0)
                    {
                        result.ErrMsg = "�û��������û����ݣ�����ɾ��";
                        return result;
                    }
                    where = string.Format("ParentId='{0}'", idsInfo.Ids[0]);
                    IEnumerable<Organize> list = _repository.GetListWhere(where);
                    if (list.Count()>0)
                    {
                        result.ErrMsg = "�û��������Ӽ����ݣ�����ɾ��";
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