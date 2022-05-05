using System;
using System.Data;
using Yuebon.Commons.Core.UnitOfWork;
using Yuebon.Commons.Repositories;
using Yuebon.Security.IRepositories;
using Yuebon.Security.Models;

namespace Yuebon.Security.Repositories
{
    public class UploadFileRepository : BaseRepository<UploadFile>, IUploadFileRepository
    {
        public UploadFileRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 根据应用Id和应用标识批量更新数据
        /// </summary>
        /// <param name="beLongAppId">更新后的应用Id</param>
        /// <param name="oldBeLongAppId">更新前旧的应用Id</param>
        /// <param name="belongApp">应用标识</param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool UpdateByBeLongAppId(string beLongAppId, string oldBeLongAppId, string belongApp = null, IDbTransaction trans = null)
        {
            try
            {
                string sqlStr = string.Format("update {0} set beLongAppId='{1}' where beLongAppId='{2}'", this.tableName, beLongAppId, oldBeLongAppId);
                if (!string.IsNullOrEmpty(belongApp))
                {
                    sqlStr = string.Format(" and BelongApp='{0}'", belongApp);
                }
                return Db.Ado.ExecuteCommand(sqlStr)>0;
            }
            catch (Exception)
            {
                trans.Rollback();
                throw;
            }
        }
    } 
}
