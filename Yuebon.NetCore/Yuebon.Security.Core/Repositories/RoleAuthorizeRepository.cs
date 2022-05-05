using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class RoleAuthorizeRepository : BaseRepository<RoleAuthorize>, IRoleAuthorizeRepository
    {
        public RoleAuthorizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        /// <summary>
        /// �����ɫ��Ȩ
        /// </summary>
        /// <param name="roleId">��ɫId</param>
        /// <param name="roleAuthorizesList">��ɫ����ģ��</param>
        /// <param name="roleDataList">��ɫ�ɷ�������</param>
        /// <param name="trans"></param>
        /// <returns>ִ�гɹ�����<c>true</c>������Ϊ<c>false</c>��</returns>
        public async Task<bool> SaveRoleAuthorize(string roleId,List<RoleAuthorize> roleAuthorizesList, List<RoleData> roleDataList,
           IDbTransaction trans = null)
        {
            var param = new List<Tuple<string, object>>();
            Tuple<string, object> tupel;
            tupel = new Tuple<string, object>(@"delete from Sys_RoleAuthorize where ObjectId=@RoleId;", new { RoleId = roleId } );
            param.Add(tupel);
            tupel = new Tuple<string, object>(@"delete from Sys_RoleData where RoleId=@RoleId;", new { RoleId = roleId });
            param.Add(tupel);
            foreach (RoleAuthorize item in roleAuthorizesList)
            {
                tupel = new Tuple<string, object>(@" INSERT INTO Sys_RoleAuthorize
           (Id
           ,ItemType
           ,ItemId
           ,ObjectType
           ,ObjectId
           ,SortCode
           ,CreatorTime
           ,CreatorUserId)
     VALUES(@Id
           ,@ItemType
           ,@ItemId
           ,@ObjectType
           ,@ObjectId
           ,@SortCode
           ,@CreatorTime
           ,@CreatorUserId) ", new
                {
                    Id = item.Id,
                    ItemType = item.ItemType,
                    ItemId = item.ItemId,
                    ObjectType = item.ObjectType,
                    ObjectId = item.ObjectId,
                    SortCode = item.SortCode,
                    CreatorTime = item.CreatorTime,
                    CreatorUserId = item.CreatorUserId
                });
                param.Add(tupel);
            }
            foreach (RoleData roleData in roleDataList)
            {
                tupel = new Tuple<string, object>(@" INSERT INTO Sys_RoleData
           (Id
           ,RoleId
           ,AuthorizeData
           ,DType)
     VALUES
           (@Id
           ,@RoleId
           ,@AuthorizeData
           ,@DType) ", new
                {
                    Id = roleData.Id,
                    RoleId = roleData.RoleId,
                    AuthorizeData = roleData.AuthorizeData,
                    DType = roleData.DType
                });
                param.Add(tupel);
            }
            var result = await ExecuteTransactionAsync(param);
            return result.Item1;
        }
    }
}