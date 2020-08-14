using System;
using System.IO;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// 常用公共操作
    /// </summary>
    public static class Common
    {
        #region 获取类型

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        public static Type GetType<T>()
        {
            var type = typeof(T);
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        #endregion

        #region 获取类型

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="type">类型</param>
        public static Type GetType(Type type)
        {
            return Nullable.GetUnderlyingType(type) ?? type;
        }

        #endregion

        #region 换行符

        /// <summary>
        /// 换行符
        /// </summary>
        public static string Line => Environment.NewLine; 

        #endregion

        #region 获取百分比

        /// <summary>
        /// 获取百分比
        /// </summary>
        /// <param name="total">总数量</param>
        /// <param name="part">部分数量</param>
        /// <returns>部分数量站总数量的百分比</returns>
        public static decimal GetPercentage(decimal total, decimal part)
        {
            decimal t = Math.Round((part / total), 2); //四舍五入,精确2位
            return t * 100;
        }

        #endregion
    }
}
