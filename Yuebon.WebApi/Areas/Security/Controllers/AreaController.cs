using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.Threading;
using Yuebon.Commons.Pages;
using Yuebon.Security.Dtos;
using Yuebon.Security.Models;

namespace Yuebon.WebApi.Areas.Security.Controllers
{
    /// <summary>
    /// 地区接口
    /// </summary>
    [ApiController]
    [SwaggerTag("Area")]
    [Route("api/Security/[controller]")]
    public class AreaController : AreaApiController<Area, AreaOutputDto, AreaInputDto, IAreaService>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_iService"></param>
        public AreaController(IAreaService _iService) : base(_iService)
        {
            iService = _iService;
        }
        /// <summary>
        /// 新增前处理数据
        /// </summary>
        /// <param name="info"></param>
        protected override void OnBeforeInsert(Area info)
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
        protected override void OnBeforeUpdate(Area info)
        {
            info.LastModifyUserId = CurrentUser.UserId;
            info.LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 在软删除数据前对数据的修改操作
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        protected override void OnBeforeSoftDelete(Area info)
        {
            info.DeleteMark = true;
            info.DeleteTime = DateTime.Now;
            info.DeleteUserId = CurrentUser.UserId;
        }
        /// <summary>
        /// 根据父级Id获取下一级地区
        /// </summary>
        /// <param name="parentId">父级Id</param>
        /// <returns></returns>
        [HttpGet("GetAllSubAreaByParentId")]
        [YuebonAuthorize("")]
        public async Task<IActionResult> GetAllSubAreaByParentId(long parentId)
        {
            CommonResult result = new CommonResult();
            try
            {
                IEnumerable<Area> list = await iService.GetListWhereAsync("ParentId="+parentId);
                result.Success = true;
                result.ErrCode = ErrCode.successCode;
                result.ResData = list.OrderBy(a=>a.EnCode);
            }
            catch (Exception ex)
            {
                Log4NetHelper.Error("获取行政区划异常", ex);
                result.ErrMsg = ErrCode.err40110;
                result.ErrCode = "40110";
            }
            return ToJsonContent(result);
        }

        /// <summary>
        /// 采集高德数据 
        ///规则：设置显示下级行政区级数（行政区级别包括：国家、省/直辖市、市、区/县4个级别）
        /// 可选值：0、1、2、3 
        /// 0：不返回下级行政区；
        /// 1：返回下一级行政区；
        /// 2：返回下两级行政区；
        /// 3：返回下三级行政区；
        /// </summary>
        /// <returns></returns>
        [HttpPost("CollectData")]
        [YuebonAuthorize("Edit")]
        public  async Task<IActionResult> CollectDataAsync()
        {
            CommonResult result = new CommonResult();
            await iService.DeleteBatchWhereAsync("1=1");
            GaodeAreaResult gaodeArea = HttpClientHelper.Get<GaodeAreaResult>(null,"https://restapi.amap.com/v3/config/district?keywords=&subdistrict=1&key=71af1e07b1d5f1a73cfa1910b6036c24");
            List<Area> list = new List<Area>();
            if (gaodeArea.status == "1")
            {
                GaodeAreaDistrict[] gaodeAreas = gaodeArea.districts;

                foreach (GaodeAreaDistrict item in gaodeAreas)
                {
                    Area area = new Area();
                    string province = string.Empty, city = string.Empty, district = string.Empty, street = string.Empty;
                    area.FullName = item.name;
                    if (item.citycode.ToString() != "[]")
                    {
                        area.AreaCode = item.citycode.ToString();
                    }
                    area.EnCode = item.adcode;
                    area.Level = item.level;
                    if (item.level == "country")
                    {
                        area.Layers = 1;
                        area.FullIdPath = item.name;
                    }
                    else if (item.level == "province")
                    {
                        area.Layers = 2;
                        province = item.name;
                        area.FullIdPath = province;
                    }
                    else if (item.level == "city")
                    {
                        area.Layers = 3;
                        city = item.name;
                        area.FullIdPath = province + city;
                    }
                    else if (item.level == "district")
                    {
                        area.Layers = 4;
                        district = item.name;
                        area.FullIdPath = province + city + district;
                    }
                    else if (item.level == "street")
                    {
                        area.Layers = 5;
                        street = item.name;
                        area.FullIdPath = province + city + district + street;
                    }
                    OnBeforeInsert(area);
                    area.ParentId = 0;
                    area.Id = 1000000;
                    area.Province = province;
                    area.EnabledMark = true;
                    area.City = city;
                    area.District = district;
                    area.Town = street;
                    list.Add(area);
                    if (item.districts != null)
                    {
                        await InsertArea(item.districts, area.Id, list, province, city, district, street);
                       
                    }
                    
                    int insertNum = 0, updateNum = 0;
                    iService.InsertOrUpdate(list, out insertNum, out updateNum);
                }
                IEnumerable<Area> dbList = await iService.GetAllAsync();

                foreach (Area item in dbList)
                {
                    if (item.EnCode != "100000")
                    {
                        list.Clear();
                        Thread.Sleep(200);
                        gaodeArea = HttpClientHelper.Get<GaodeAreaResult>(null, "https://restapi.amap.com/v3/config/district?keywords=" + item.EnCode + "&subdistrict=3&key=71af1e07b1d5f1a73cfa1910b6036c24");
                        if (gaodeArea.status == "1")
                        {
                            GaodeAreaDistrict[] subGoodeAreas = gaodeArea.districts;

                            foreach (GaodeAreaDistrict itemTemp in subGoodeAreas)
                            {
                                if (itemTemp.districts != null)
                                {
                                    await InsertArea(itemTemp.districts, item.Id, list, item.FullName, item.City, item.District, item.Town);
                                }
                            }

                            int insertNum = 0, updateNum = 0;
                            iService.InsertOrUpdate(list, out insertNum, out updateNum);
                        }
                    }
                }
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

        private async Task<List<Area>> InsertArea(GaodeAreaDistrict[] gaodeAreas, long parentId, List<Area> list, string province, string city, string district, string street)
        {
            foreach (GaodeAreaDistrict item in gaodeAreas)
            {
                Area area = new Area();
                area.FullName = item.name;
                if (item.citycode.ToString() != "[]")
                {
                    area.AreaCode = item.citycode.ToString();
                }
                area.EnCode = item.adcode;
                area.Level = item.level;
                if (item.level == "country")
                {
                    area.Layers = 1; 
                    area.FullIdPath = item.name;
                }
                else if (item.level == "province")
                {
                    area.Layers = 2;
                    province = item.name;
                    area.FullIdPath = province;
                }
                else if (item.level == "city")
                {
                    area.Layers = 3;
                    city = item.name;
                    area.FullIdPath = province + city;
                }
                else if (item.level == "district")
                {
                    area.Layers = 4;
                    district = item.name;
                    area.FullIdPath = province + city + district;
                }
                else if (item.level == "street")
                {
                    area.Layers = 5;
                    street = item.name;
                    area.FullIdPath = province + city + district + street;
                }
                OnBeforeInsert(area);
                area.ParentId = parentId;
                area.Province = province;
                area.EnabledMark = true;
                area.City = city;
                area.District = district;
                area.Town = street;
                list.Add(area);
                if (item.districts != null)
                {
                  await  InsertArea(item.districts,area.Id, list, province, city, district, street);
                }
            }
            return list;
        }

    }
}