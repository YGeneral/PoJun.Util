using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// Url操作
    /// </summary>
    public static class Url
    {
        /// <summary>
        /// 合并Url
        /// </summary>
        /// <param name="urls">url片断，范例：Url.Combine( "http://a.com","b" ),返回 "http://a.com/b"</param>
        public static string Combine(params string[] urls)
        {
            return Path.Combine(urls).Replace(@"\", "/");
        }

        /// <summary>
        /// 连接Url，范例：Url.Join( "http://a.com","b=1" ),返回 "http://a.com?b=1"
        /// </summary>
        /// <param name="url">Url，范例：http://a.com</param>
        /// <param name="param">参数，范例：b=1</param>
        public static string Join(string url, string param)
        {
            return $"{GetUrl(url)}{param}";
        }

        /// <summary>
        /// 获取Url
        /// </summary>
        private static string GetUrl(string url)
        {
            if (!url.Contains("?"))
                return $"{url}?";
            if (url.EndsWith("?"))
                return url;
            if (url.EndsWith("&"))
                return url;
            return $"{url}&";
        }

        #region URL添加参数

        /// <summary>
        /// URL添加参数
        /// </summary>
        /// <param name="originUrl"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string AddUrlParams(string originUrl, IDictionary<string, string> data)
        {
            var baseUrl = string.Empty;
            var paramsStr = string.Empty;
            var baseData = GetUrlParams(originUrl, out baseUrl);

            foreach (var d in data)
            {
                baseData[d.Key] = d.Value;
            }

            baseUrl += "?";
            foreach (var d in baseData)
            {
                baseUrl += string.Format("{0}={1}&", d.Key, d.Value);
            }
            return baseUrl.Substring(0, baseUrl.Length - 1);
        }

        #endregion

        #region 获取Url参数

        /// <summary>
        /// 获取Url参数
        /// </summary>
        /// <param name="originUrl"></param>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        public static IDictionary<string, string> GetUrlParams(string originUrl, out string baseUrl)
        {
            baseUrl = string.Empty;
            var paramsStr = string.Empty;
            if (originUrl.IndexOf("?") >= 0)
            {
                var temp = originUrl.Split('?');
                if (temp.Length > 1)
                {
                    paramsStr = temp[1];
                }
                baseUrl = temp[0];
            }
            else
            {
                baseUrl = originUrl;
            }

            var _data = new Dictionary<string, string>();
            string[] paramsArray;
            if (!string.IsNullOrWhiteSpace(paramsStr))
            {
                paramsArray = paramsStr.Split('&');
                for (var i = 0; i < paramsArray.Length; i++)
                {
                    var _temp = paramsArray[i].Split('=');
                    if (_temp.Length == 2)
                    {
                        _data[_temp[0]] = _temp[1];
                    }
                }
            }

            return _data;
        }

        #endregion
    }
}
