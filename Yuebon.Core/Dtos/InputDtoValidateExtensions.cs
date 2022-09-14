using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Yuebon.Commons.Data;
using Yuebon.Commons.Extensions;

namespace Yuebon.Core.Dtos
{
    /// <summary>
    /// <see cref="IInputDto{TKey}"/>验证扩展 
    /// </summary>
    public static class InputDtoValidateExtensions
    {
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<PropertyInfo, ValidationAttribute[]>> _dict
            = new ConcurrentDictionary<Type, ConcurrentDictionary<PropertyInfo, ValidationAttribute[]>>();

        /// <summary>
        /// InputDto属性验证
        /// </summary>
        public static void Validate<TKey>(this IEnumerable<IInputDto<TKey>> dtos)
        {
            IInputDto<TKey>[] inputDtos = dtos as IInputDto<TKey>[] ?? dtos.ToArray();
            Check.NotNull(inputDtos, nameof(dtos));
            foreach (IInputDto<TKey> dto in inputDtos)
            {
                Validate(dto);
            }
        }

        /// <summary>
        /// InputDto属性验证
        /// </summary>
        public static void Validate<TKey>(this IInputDto<TKey> dto)
        {
            Check.NotNull(dto, nameof(dto));
            Type type = dto.GetType();
            if (!_dict.TryGetValue(type, out ConcurrentDictionary<PropertyInfo, ValidationAttribute[]> dict))
            {
                PropertyInfo[] properties = type.GetProperties();
                dict = new ConcurrentDictionary<PropertyInfo, ValidationAttribute[]>();
                if (properties.Length == 0)
                {
                    _dict[type] = dict;
                    return;
                }
                foreach (var property in properties)
                {
                    dict[property] = null;
                }
                _dict[type] = dict;
            }

            foreach (PropertyInfo property in dict.Keys)
            {
                if (!dict.TryGetValue(property, out ValidationAttribute[] attributes) || attributes == null)
                {
                    attributes = property.GetAttributes<ValidationAttribute>();
                    dict[property] = attributes;
                }
                if (attributes.Length == 0)
                {
                    continue;
                }
                object value = property.GetValue(dto);
                foreach (ValidationAttribute attribute in attributes)
                {
                    attribute.Validate(value, property.Name);
                }
            }
        }
    }
}
