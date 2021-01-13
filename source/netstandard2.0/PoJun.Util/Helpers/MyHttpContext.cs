using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// MyHttpContext
    /// 创建人：杨江军
    /// 创建时间：2021/1/6/星期三 14:05:59
    /// </summary>
    public static class MyHttpContext
    {
        /// <summary>
        /// 
        /// </summary>
        public static IHttpContextAccessor HttpContextAccessor;
        /// <summary>
        /// 
        /// </summary>
        public static HttpContext Current
        {
            get
            {
                return HttpContextAccessor.HttpContext;
            }
        }
    }
}
