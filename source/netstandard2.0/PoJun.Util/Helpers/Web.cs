using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// Web操作
    /// </summary>
    public static class Web
    {
        #region IP操作

        /// <summary>
        /// 客户端Ip地址(必须注册MyHttpContext)
        /// </summary>
        public static string Ip
        {
            get
            {
                var list = new[] { "127.0.0.1", "::1" };
                var result = MyHttpContext.Current?.Connection?.RemoteIpAddress.SafeString();
                if (string.IsNullOrWhiteSpace(result) || list.Contains(result))
                    result = GetLanIp();
                return result;
            }
        }

        #region Ip(客户端Ip地址)

        /// <summary>
        /// 获取局域网IP
        /// </summary>
        private static string GetLanIp()
        {
            foreach (var hostAddress in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (hostAddress.AddressFamily == AddressFamily.InterNetwork)
                    return hostAddress.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region 将一个IP字符串转为Long型

        /// <summary>
        /// 将一个IP字符串转为Long型
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns></returns>
        public static long IPConvertLong(string ip)
        {
            //从大到小排列ip,与IPAddress不同
            if (string.IsNullOrEmpty(ip) || ip == "::1")
            {
                return 0;
            }
            string[] ipsegmentArray = ip.Split('.');
            if (ipsegmentArray.Length != 4)
            {
                ipsegmentArray = "127.0.0.1".Split();
            }
            long ip1 = int.Parse(ipsegmentArray[0]);
            int ip2 = int.Parse(ipsegmentArray[1]);
            int ip3 = int.Parse(ipsegmentArray[2]);
            int ip4 = int.Parse(ipsegmentArray[3]);
            long ip0 = (ip1 << 24) + (ip2 << 16) + (ip3 << 8) + ip4;
            return ip0;
        }

        #endregion

        #region 将一个Long型的ip转成字符串

        /// <summary>
        /// 将一个Long型的ip转成字符串
        /// </summary>
        /// <returns></returns>
        public static string LongConvertIP(long ip)
        {
            long ip1 = ip >> 24 & 0xFF;
            long ip2 = ip >> 16 & 0xFF;
            long ip3 = ip >> 8 & 0xFF;
            long ip4 = ip & 0xFF;
            var ipstr = ip1 + "." + ip2 + "." + ip3 + "." + ip4;
            return ipstr;
        }

        #endregion 

        #region 判断是否是IP地址格式 0.0.0.0  

        /// <summary>  
        /// 判断是否是IP地址格式 0.0.0.0  
        /// </summary>  
        /// <param name="str1">待判断的IP地址</param>  
        /// <returns>true or false</returns>  
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;
            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }

        #endregion

        #endregion

        #region URL操作

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

        #region 判断url是否是外部地址

        /// <summary>
        /// 判断url是否是外部地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsExternalAddress(this string url)
        {
            var uri = new Uri(url);
            switch (uri.HostNameType)
            {
                case UriHostNameType.Dns:
                    var ipHostEntry = Dns.GetHostEntry(uri.DnsSafeHost);
                    if (ipHostEntry.AddressList.Where(ipAddress => ipAddress.AddressFamily == AddressFamily.InterNetwork).Any(ipAddress => !ipAddress.IsPrivateIP()))
                    {
                        return true;
                    }
                    break;
                case UriHostNameType.IPv4:
                    return !IPAddress.Parse(uri.DnsSafeHost).IsPrivateIP();
            }
            return false;
        }

        #endregion

        #region 判断IP是否是私有地址

        /// <summary>
        /// 判断IP是否是私有地址
        /// </summary>
        /// <param name="myIPAddress"></param>
        /// <returns></returns>
        public static bool IsPrivateIP(this IPAddress myIPAddress)
        {
            if (IPAddress.IsLoopback(myIPAddress)) return true;
            if (myIPAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();
                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 169.254.0.0/16
                if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
                // 172.16.0.0/16
                if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断IP是否是私有地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsPrivateIP(this string ip)
        {
            if (MatchInetAddress(ip))
            {
                return IsPrivateIP(IPAddress.Parse(ip));
            }
            throw new ArgumentException(ip + "不是一个合法的ip地址");
        } 

        #endregion

        #region 校验IP地址的合法性

        /// <summary>
        /// 校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns>
        public static IPAddress MatchInetAddress(this string s, out bool isMatch)
        {
            isMatch = IPAddress.TryParse(s, out var ip);
            return ip;
        }

        /// <summary>
        /// 校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchInetAddress(this string s)
        {
            MatchInetAddress(s, out var success);
            return success;
        }

        #endregion

        #region UrlEncode(Url编码)

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(string url, bool isUpper = false)
        {
            return UrlEncode(url, Encoding.UTF8, isUpper);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(string url, string encoding, bool isUpper = false)
        {
            encoding = string.IsNullOrWhiteSpace(encoding) ? "UTF-8" : encoding;
            return UrlEncode(url, Encoding.GetEncoding(encoding), isUpper);
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        /// <param name="isUpper">编码字符是否转成大写,范例,"http://"转成"http%3A%2F%2F"</param>
        public static string UrlEncode(string url, Encoding encoding, bool isUpper = false)
        {
            var result = HttpUtility.UrlEncode(url, encoding);
            if (isUpper == false)
                return result;
            return GetUpperEncode(result);
        }

        /// <summary>
        /// 获取大写编码字符串
        /// </summary>
        private static string GetUpperEncode(string encode)
        {
            var result = new StringBuilder();
            int index = int.MinValue;
            for (int i = 0; i < encode.Length; i++)
            {
                string character = encode[i].ToString();
                if (character == "%")
                    index = i;
                if (i - index == 1 || i - index == 2)
                    character = character.ToUpper();
                result.Append(character);
            }
            return result.ToString();
        }

        #endregion

        #region UrlDecode(Url解码)

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url">url</param>
        public static string UrlDecode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        /// <summary>
        /// Url解码
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="encoding">字符编码</param>
        public static string UrlDecode(string url, Encoding encoding)
        {
            return HttpUtility.UrlDecode(url, encoding);
        }

        #endregion

        #endregion

        #region 获取远程服务器内容，并转换成二进制数组

        /// <summary>
        /// 获取远程服务器内容，并转换成二进制数组
        /// </summary>
        /// <param name="url">http://showdoc.ashermed.com/Public/Uploads/2020-06-30/5efaf665458b2.jpg</param>
        /// <returns></returns>
        public static byte[] GetUrlByte(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    List<byte> btlist = new List<byte>();
                    int b = responseStream.ReadByte();
                    while (b > -1)
                    {
                        btlist.Add((byte)b);
                        b = responseStream.ReadByte();
                    }
                    return btlist.ToArray();
                }
            }
        }

        #endregion
    }
}
