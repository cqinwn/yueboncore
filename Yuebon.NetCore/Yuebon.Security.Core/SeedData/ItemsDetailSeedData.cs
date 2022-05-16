using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuebon.Commons.Core.Models;
using Yuebon.Commons.SeedInitData;
using Yuebon.Security.Models;

namespace Yuebon.Security.SeedData
{
    public class ItemsDetailSeedData:SeedDataEntity
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemsDetail> HasData()
        {
            return new[] {
                new ItemsDetail{
                    Id= 9165817405374533,
                    ItemId= 9165809527554117,
                    ParentId= 0,
                    ItemCode= "Group",
                    ItemName= "集团",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165836811632709,
                    ItemId= 9165809527554117,
                    ParentId= 0,
                    ItemCode= "Company",
                    ItemName= "公司",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165850199064645,
                    ItemId= 9165809527554117,
                    ParentId= 0,
                    ItemCode= "SubCompany",
                    ItemName= "子公司",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165852817752133,
                    ItemId= 9165809527554117,
                    ParentId= 0,
                    ItemCode= "Department",
                    ItemName= "部门",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165855286886469,
                    ItemId= 9165809527554117,
                    ParentId= 0,

                    ItemCode= "WorkGroup",
                    ItemName= "小组",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165857562951749,
                    ItemId= 9165813031108677,
                    ParentId= 0,
                    ItemCode= "1",
                    ItemName= "系统角色",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165859013525573,
                    ItemId= 9165813031108677,
                    ParentId= 0,

                    ItemCode= "2",
                    ItemName= "业务角色",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                },
                new ItemsDetail{
                    Id= 9165860710645829,
                    ItemId= 9165813031108677,
                    ParentId= 0,
                    ItemCode= "3",
                    ItemName= "其他角色",
                    SimpleSpelling= null,
                    IsDefault= false,
                    Layers= null,
                    SortCode= 99,
                    DeleteMark= false,
                    EnabledMark= true,
                    Description= null,
                    CreatorTime= DateTime.Now,
                    CreatorUserId = 9165855286886368,
                    LastModifyTime= null,
                    LastModifyUserId= null,
                    DeleteTime= null,
                    DeleteUserId= null
                }
            };
        }
    }
}
