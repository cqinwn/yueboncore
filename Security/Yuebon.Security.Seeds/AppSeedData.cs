using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    /// <summary>
    /// 应用种子数据
    /// </summary>
    public class AppSeedData:SeedDataEntity
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<APP> HasData()
        {
            return new[]
            {
                new APP
                {
                    Id = 9242771975831621,
                    AppId = "system",
                    AppSecret = "87135AB0160F706D8B47F06BDABA6FC6",
                    EncodingAESKey = "0D32368A4029492DB8E2ADF12C5B468E",
                    RequestUrl = "http://localhost:5001,http://localhost:5002,http://localhost:8081",
                    Token = "009900",
                    IsOpenAEKey = true,
                    DeleteMark = false,
                    EnabledMark = true,
                    Description = "",
                    CreatorTime = DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    CompanyId = 9165855286886469,
                    DeptId = 9165855286886470,
                    LastModifyTime = null,
                    LastModifyUserId = null,
                    DeleteTime = null,
                    DeleteUserId = null
                },
                new APP
                {
                    Id = 9242771975962693,
                    AppId = "wmsapp",
                    AppSecret = "B8548D08B8BA023677939E3AE8A4388E",
                    EncodingAESKey = "39641FFDAED557D2D6F2F1FC08A37696",
                    RequestUrl = "http://localhost:5001,http://localhost:5002,http://localhost:8081",
                    Token = "00990l",
                    IsOpenAEKey = true,
                    DeleteMark = false,
                    EnabledMark = true,
                    Description = "",
                    CreatorTime = DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    CompanyId = 9165855286886469,
                    DeptId = 9165855286886470,
                    LastModifyTime = null,
                    LastModifyUserId = null,
                    DeleteTime = null,
                    DeleteUserId = null
                }
            };
        }
    }
}
