namespace Yuebon.Security.Repositories
{
    /// <summary>
    /// ��־�ִ�ʵ��
    /// </summary>
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override int Insert(Log entity)
        {
            if (entity.KeyIsNull())
            {
                entity.GenerateDefaultKeyVal();
            }
            return Db.Insertable(entity).ExecuteCommand();
        }
        /// <summary>
        /// ����ɾ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool Delete(object id)
        {
            int row = Db.Ado.ExecuteCommand($"delete from Sys_Log where Id=@id");
            return row > 0 ? true : false;
        }
    }
}