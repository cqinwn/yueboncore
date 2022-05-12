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

        #region ����uniapp����ѡ��
        /// <summary>
        /// ��ȡ���п��õĵ���������uniapp����ѡ��
        /// </summary>
        /// <returns></returns>
        List<AreaPickerOutputDto> GetAllByEnable();
        /// <summary>
        /// ��ȡʡ���С���/���������õĵ���������uniapp����ѡ��
        /// </summary>
        /// <returns></returns>
        List<AreaPickerOutputDto> GetProvinceToAreaByEnable();
        #endregion
    }
}
