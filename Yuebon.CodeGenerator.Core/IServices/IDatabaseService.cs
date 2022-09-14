using Yuebon.CodeGenerator.Dtos;
using Yuebon.CodeGenerator.Models;

namespace Yuebon.CodeGenerator.IServices
{
    /// <summary>
    /// 定义数据库信息服务接口
    /// </summary>
    public interface IDatabaseService:IService<Database,DatabaseOutputDto>
    {
    }
}
