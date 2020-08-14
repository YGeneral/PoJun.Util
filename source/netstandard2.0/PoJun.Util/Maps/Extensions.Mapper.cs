using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PoJun.Util.Maps
{
    /// <summary>
    /// 对象映射
    /// </summary>
    public static class Extensions
    {
        #region 将源对象映射到目标对象

        /// <summary>
        /// 将源对象映射到目标对象
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="source">源对象</param>  
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object source) where TDestination : new()
        {
            var json = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<TDestination>(json);
        }

        #endregion

        #region 将源集合映射到目标集合

        /// <summary>
        /// 将源集合映射到目标集合
        /// </summary>
        /// <typeparam name="TDestination">目标元素类型,范例：Sample,不要加List</typeparam>
        /// <param name="source">源集合</param>
        /// <returns></returns>
        public static List<TDestination> MapToList<TDestination>(this System.Collections.IEnumerable source)
        {
            var json = JsonConvert.SerializeObject(source);
            return JsonConvert.DeserializeObject<List<TDestination>>(json);
        } 

        #endregion




    }
}
