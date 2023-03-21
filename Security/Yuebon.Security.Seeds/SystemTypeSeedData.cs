using Yuebon.Commons.Attributes;

namespace Yuebon.Security.SeedData;

public class SystemTypeSeedData: SeedDataEntity
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<SystemType> HasData()
    {
        return new[] {
            new SystemType{
                Id=9166287964471366,
                EnCode="YuebonWcs",
                FullName="易分拣",
                Url="http://localhost:9529",
                AllowEdit=null,
                AllowDelete=null,
                SortCode=99,
                DeleteMark=false,
                EnabledMark=false,
                Description="",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                TenantId=9242772129579077
            },
            new SystemType{
                Id=9166287964471363,
                EnCode="openauth",
                FullName="权限系统",
                Url="http://localhost:9528",
                AllowEdit=null,
                AllowDelete=null,
                SortCode=1,
                DeleteMark=false,
                EnabledMark=true,
                Description="权限系统是基础系统，包含机构、岗位、角色、用户等功能",
                CreatorTime= DateTime.Now,
                CreatorUserId = 9165855286886368,
                LastModifyTime= null,
                LastModifyUserId= null,
                DeleteTime= null,
                DeleteUserId= null,
                TenantId=9242772129579077
            }
        };
    }
}
