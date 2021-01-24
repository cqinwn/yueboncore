using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Yuebon.Commons.Extend;

namespace Yuebon.Commons.Helpers
{
    /// <summary>
    /// 首字母大写
    /// </summary>
    public class UpperFirstCaseNamingPolicy:JsonNamingPolicy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string ConvertName(string name) =>
            name.UpperFirst();
    }
}
