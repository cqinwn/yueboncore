using System;
using System.Collections.Generic;
using Yuebon.Commons.IServices;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.Security.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAreaService:IService<Area, AreaOutputDto>
    {

        #region 用于uniapp下拉选项
        /// <summary>
        /// 获取所有可用的地区，用于uniapp下拉选项
        /// </summary>
        /// <returns></returns>
        List<AreaPickerOutputDto> GetAllByEnable();
        /// <summary>
        /// 获取省、市、县/区三级可用的地区，用于uniapp下拉选项
        /// </summary>
        /// <returns></returns>
        List<AreaPickerOutputDto> GetProvinceToAreaByEnable();
        #endregion
    }
}
