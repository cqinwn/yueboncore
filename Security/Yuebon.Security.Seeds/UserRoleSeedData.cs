using Yuebon.Commons.Helpers;

namespace Yuebon.Security.SeedData;

public class UserRoleSeedData : SeedDataEntity
{
    /// <summary>
    /// 种子数据
    /// </summary>
    /// <returns></returns>
    [IgnoreUpdate]
    public IEnumerable<UserRole> HasData()
    {
        return new[] {
            new UserRole{
                Id=14952996950376518,
                UserId=9165855286886368,
                RoleId=9242772029964356
            }
        };
    }
}
