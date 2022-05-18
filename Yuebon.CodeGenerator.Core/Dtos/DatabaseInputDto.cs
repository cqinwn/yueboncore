using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Yuebon.CodeGenerator.Models;
using Yuebon.Commons.Dtos;

namespace Yuebon.CodeGenerator.Dtos
{
    /// <summary>
    /// 数据库信息输入对象模型
    /// </summary>
    [AutoMap(typeof(Database))]
    [Serializable]
    public class DatabaseInputDto: IInputDto
    {
        /// <summary>
        /// 设置或获取编号,主键
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        [MaxLength(255)]
        public string Desc { get; set; }

        /// <summary>
        /// 设置或获取数据库连接
        /// </summary>
        [MaxLength(600)]
        public string Connection { get; set; }

        /// <summary>
        /// 设置或获取
        /// </summary>
        public int? DbType { get; set; }

    }
}
