using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// 缓存帮助类
    /// 创建人：杨江军
    /// 创建时间：2021/1/6/星期三 13:56:15
    /// </summary>
    public class CacheCommon
    {
        private static readonly MemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        #region 获取缓存值

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <returns>返回缓存的值</returns>
        public static object GetCacheValue(string key)
        {
            if (!string.IsNullOrEmpty(key) && cache.TryGetValue(key, out object val))
            {
                return val;
            }
            else
            {
                return default;
            }
        }

        #endregion

        #region 设置缓存值

        /// <summary>
        /// 设置缓存值
        /// </summary>
        /// <param name="key">缓存的键</param>
        /// <param name="value">缓存值</param>
        /// <param name="seconds">缓存时间（秒）</param>
        public static void SetChacheValue(string key, object value, int seconds = 3600)
        {
            if (!string.IsNullOrEmpty(key))
            {
                cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(seconds)
                });
            }
        }

        #endregion

        #region 删除缓存

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveChacheValue(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                cache.Remove(key);
            }
        }

        #endregion
    }
}
