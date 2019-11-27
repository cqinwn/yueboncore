using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Yuebon.WebApp.Commons
{
    /// <summary>
    /// 自定义拒绝访问异常
    /// </summary>
    public class MyDenyAccessException : UnauthorizedAccessException
    {
        public MyDenyAccessException(string message) : base(message)
        {
        }
    }
}
