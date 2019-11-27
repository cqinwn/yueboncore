using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yuebon.Commons.Cache;
using Yuebon.Commons.Json;
using Yuebon.Commons.Mapping;
using Yuebon.Commons.Tree;
using Yuebon.Security.Dtos;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;
using Yuebon.Security.Repositories;

namespace Yuebon.Security.Application
{
    /// <summary>
    /// 地区
    /// </summary>
    public class AreaApp
    {
        private IAreaRepository service = new AreaRepository();

        #region 适配于管理后端
        /// <summary>
        /// 树形展开treeview需要,数据字典管理页面
        /// </summary>
        /// <returns></returns>
        public List<TreeViewModel> ItemsTreeViewJson()
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            List<Area> listFunction = service.GetListWhere("Layers in (0,1,2)").OrderBy(t => t.SortCode).ToList();
            list = TreeViewJson(listFunction, "");
            return list;
        }

        //public List<TreeViewModel> AreaTreeViewJson()
        //{
            //string where = "1=1 and Layers in(0,1,2)";
            //bool order = orderByDir == "asc" ? false : true;
            //if (!string.IsNullOrEmpty(keywords))
            //{
            //    where += string.Format(" and (FullName like '%{0}%' or EnCode like '%{0}%')", keywords);
            //}
            //List<AreaOutputDto> list = iService.GetListWhere(where).OrderBy(t => t.SortCode).ToList().MapTo<AreaOutputDto>();

            //return ToJsonContent(list);

            //List<TreeViewModel> list = new List<TreeViewModel>();
            //List<Area> listFunction = service.GetListWhere("Layers in (3,4)").OrderBy(t => t.SortCode).ToList();
            //list = TreeViewJson(listFunction, "");
            //return list;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeViewModel> TreeViewJson(List<Area> data, string parentId)
        {
            List<TreeViewModel> list = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Area entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.nodes = ChildrenTreeViewList(data, entity.Id);
                treeViewModel.tags = entity.Id;
                list.Add(treeViewModel);
            }
            return list;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeViewModel> ChildrenTreeViewList(List<Area> data, string parentId)
        {
            List<TreeViewModel> listChildren = new List<TreeViewModel>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Area entity in ChildNodeList)
            {
                TreeViewModel treeViewModel = new TreeViewModel();
                treeViewModel.nodeId = entity.Id;
                treeViewModel.pid = entity.ParentId;
                treeViewModel.text = entity.FullName;
                treeViewModel.nodes = ChildrenTreeViewList(data, entity.Id);
                treeViewModel.tags = entity.Id;
                listChildren.Add(treeViewModel);
            }
            return listChildren;
        }
        #endregion

        #region 用于uniapp下拉选项
        /// <summary>
        /// 获取所有可用的地区，用于uniapp下拉选项
        /// </summary>
        /// <returns></returns>
        public List<AreaPickerOutputDto> GetAllByEnable()
        {
            List<AreaPickerOutputDto> list = new List<AreaPickerOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            list=JsonConvert.DeserializeObject<List<AreaPickerOutputDto>>(yuebonCacheHelper.Get("Area_Enable_Uniapp").ToJson());
            if (list == null||list.Count<=0)
            {
                List<Area> listFunction = service.GetAllByIsNotDeleteAndEnabledMark("Layers in (0,1,2)").OrderBy(t => t.SortCode).ToList();
                list = UniappViewJson(listFunction, "");
                yuebonCacheHelper.Add("Area_Enable_Uniapp", list);
            }
            return list;
        }
        /// <summary>
        /// 获取省、市、县/区三级可用的地区，用于uniapp下拉选项
        /// </summary>
        /// <returns></returns>
        public List<AreaPickerOutputDto> GetProvinceToAreaByEnable()
        {
            List<AreaPickerOutputDto> list = new List<AreaPickerOutputDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            list = JsonConvert.DeserializeObject<List<AreaPickerOutputDto>>(yuebonCacheHelper.Get("Area_ProvinceToArea_Enable_Uniapp").ToJson());
            if (list == null || list.Count <= 0)
            {
                List<Area> listFunctionTemp = service.GetAllByIsNotDeleteAndEnabledMark("Layers in (1,2,3)").OrderBy(t => t.Id).ToList();
                List<Area> listFunction = new List<Area>();
                foreach (Area item in listFunctionTemp)
                {
                    if (item.Layers == 1) { item.ParentId = ""; }
                    listFunction.Add(item);
                }

                list = UniappViewJson(listFunction, "");
                yuebonCacheHelper.Add("Area_ProvinceToArea_Enable_Uniapp", list);
            }
            return list;
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="data"></param>
       /// <param name="parentId"></param>
       /// <returns></returns>
        public List<AreaPickerOutputDto> UniappViewJson(List<Area> data, string parentId)
        {
            List<AreaPickerOutputDto> list = new List<AreaPickerOutputDto>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Area entity in ChildNodeList)
            {
                AreaPickerOutputDto treeViewModel = new AreaPickerOutputDto();
                treeViewModel.value = entity.Id;
                treeViewModel.label = entity.FullName;
                treeViewModel.children = ChildrenUniappViewList(data, entity.Id);
                list.Add(treeViewModel);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<AreaPickerOutputDto> ChildrenUniappViewList(List<Area> data, string parentId)
        {
            List<AreaPickerOutputDto> listChildren = new List<AreaPickerOutputDto>();
            var ChildNodeList = data.FindAll(t => t.ParentId == parentId).ToList();
            foreach (Area entity in ChildNodeList)
            {
                AreaPickerOutputDto treeViewModel = new AreaPickerOutputDto();
                treeViewModel.value = entity.Id;
                treeViewModel.label = entity.FullName;
                treeViewModel.children = ChildrenUniappViewList(data, entity.Id);
                listChildren.Add(treeViewModel);
            }
            return listChildren;
        }
        #endregion

        #region 适用于select2省市县区级联选择
        /// <summary>
        /// 获取省可用的地区，用于select2下拉选项
        /// </summary>
        /// <returns></returns>
        public List<AreaSelect2OutDto> GetProvinceAll()
        {
            List<AreaSelect2OutDto> list = new List<AreaSelect2OutDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            list = JsonConvert.DeserializeObject<List<AreaSelect2OutDto>>(yuebonCacheHelper.Get("Area_ProvinceToArea_Select2").ToJson());
            if (list == null || list.Count <= 0)
            {
                list = service.GetAllByIsNotDeleteAndEnabledMark("Layers =1").OrderBy(t => t.Id).ToList().MapTo<AreaSelect2OutDto>();
               
                yuebonCacheHelper.Add("Area_ProvinceToArea_Select2", list);
            }
            return list;
        }
        /// <summary>
        /// 获取城市，用于select2下拉选项
        /// </summary>
        /// <param name="id">省份Id</param>
        /// <returns></returns>
        public List<AreaSelect2OutDto> GetCityByProvinceId(string id)
        {
            List<AreaSelect2OutDto> list = new List<AreaSelect2OutDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            list = JsonConvert.DeserializeObject<List<AreaSelect2OutDto>>(yuebonCacheHelper.Get("Area_CityToArea_Enable_Select2"+id).ToJson());
            if (list == null || list.Count <= 0)
            {
                string sqlWhere = string.Format("ParentId='{0}'", id);
                list = service.GetAllByIsNotDeleteAndEnabledMark(sqlWhere).OrderBy(t => t.Id).ToList().MapTo<AreaSelect2OutDto>();

                yuebonCacheHelper.Add("Area_CityToArea_Enable_Select2"+id, list);
            }
            return list;
        }

        /// <summary>
        /// 获取县区，用于select2下拉选项
        /// </summary>
        /// <param name="id">城市Id</param>
        /// <returns></returns>
        public List<AreaSelect2OutDto> GetDistrictByCityId(string id)
        {
            List<AreaSelect2OutDto> list = new List<AreaSelect2OutDto>();
            YuebonCacheHelper yuebonCacheHelper = new YuebonCacheHelper();
            list = JsonConvert.DeserializeObject<List<AreaSelect2OutDto>>(yuebonCacheHelper.Get("Area_DistrictToArea_Enable_Select2"+id).ToJson());
            if (list == null || list.Count <= 0)
            {
                string sqlWhere = string.Format("ParentId='{0}'", id);
                list = service.GetAllByIsNotDeleteAndEnabledMark(sqlWhere).OrderBy(t => t.Id).ToList().MapTo<AreaSelect2OutDto>();

                yuebonCacheHelper.Add("Area_DistrictToArea_Enable_Select2"+id, list);
            }
            return list;
        }
        #endregion
    }
}
