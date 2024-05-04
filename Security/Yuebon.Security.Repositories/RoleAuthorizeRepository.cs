using Yuebon.Commons.Enums;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleAuthorizeRepository : BaseRepository<RoleAuthorize>, IRoleAuthorizeRepository
    {
        public RoleAuthorizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// 保存角色授权
        /// </summary>
        /// <param name="roleId">角色Id</param>
        /// <param name="roleAuthorizesList">角色功能模块</param>
        /// <param name="roleDataList">角色可访问数据</param>
        /// <param name="roleDataScope">角色可访问数据范围</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public async Task<bool> SaveRoleAuthorize(long roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList,int roleDataScope)
        {

            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel;
            tupel = new Tuple<string, object>(@"delete from Sys_Role_Authorize where ObjectId=@RoleId;", new { RoleId = roleId } );
            param.Add(tupel);
            tupel = new Tuple<string, object>(@"delete from Sys_Role_Data where RoleId=@RoleId;", new { RoleId = roleId });
            param.Add(tupel);
            tupel = new Tuple<string, object>(@"update  Sys_Role set DataScope=@DataScope where Id=@RoleId;", new { DataScope = roleDataScope, RoleId = roleId });
            param.Add(tupel);

            foreach (RoleAuthorize item in roleAuthorizesList)
            {
                tupel = new Tuple<string, object>(@" INSERT INTO Sys_Role_Authorize
           (Id
           ,ItemType
           ,ItemId
           ,ObjectType
           ,ObjectId
           ,SortCode
           ,CreatorTime
           ,CreatorUserId
,TenantId)
     VALUES(@Id
           ,@ItemType
           ,@ItemId
           ,@ObjectType
           ,@ObjectId
           ,@SortCode
           ,@CreatorTime
           ,@CreatorUserId
,@TenantId) ", new
                {
                    Id = item.Id,
                    ItemType = item.ItemType,
                    ItemId = item.ItemId,
                    ObjectType = item.ObjectType,
                    ObjectId = item.ObjectId,
                    SortCode = item.SortCode,
                    CreatorTime = item.CreatorTime,
                    CreatorUserId = item.CreatorUserId,
                    TenantId=item.TenantId
                });
                param.Add(tupel);
            }
            foreach (RoleData roleData in roleDataList)
            {
                tupel = new Tuple<string, object>(@" INSERT INTO Sys_Role_Data
           (Id
           ,RoleId
           ,AuthorizeData
           ,DType
,TenantId)
     VALUES
           (@Id
           ,@RoleId
           ,@AuthorizeData
           ,@DType
,@TenantId) ", new
                {
                    Id = roleData.Id,
                    RoleId = roleData.RoleId,
                    AuthorizeData = roleData.AuthorizeData,
                    DType = roleData.DType,
                    TenantId = roleData.TenantId
                });
                param.Add(tupel);
            }
            var result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }
    }
}