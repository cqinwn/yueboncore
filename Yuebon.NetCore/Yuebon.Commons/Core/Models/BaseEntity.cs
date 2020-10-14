using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Yuebon.Commons.Extensions;
using Yuebon.Commons.Helpers;

namespace Yuebon.Commons.Models
{
    /// <summary>
    /// 定义领域对象框架实体类的基类，系统默认主键为Id
    /// </summary>

    [Serializable]
    [DataContract]
    public abstract class BaseEntity<TKey> :Entity where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        protected BaseEntity()
        {
        }

        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        [DisplayName("编号")]
        [ExplicitKey]
        public TKey Id { get; set; }


        /// <summary>
        /// 判断主键是否为空
        /// </summary>
        /// <returns></returns>
        public override bool KeyIsNull()
        {
            if (Id == null)
            {
                return true;
            }
            else
            {
                return string.IsNullOrEmpty(Id.ToString());
            }
        }

        /// <summary>
        /// 创建默认的主键值
        /// </summary>
        public override void GenerateDefaultKeyVal()
        {
           Id = GuidUtils.CreateNo().CastTo<TKey>();
        }
    }
}
