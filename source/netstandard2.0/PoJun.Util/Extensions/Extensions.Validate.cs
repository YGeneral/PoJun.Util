using PoJun.Util.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace PoJun.Util
{
    /// <summary>
    /// 系统扩展 - 验证
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 检测对象是否为null,为null则抛出<see cref="ArgumentNullException"/>异常
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="parameterName">参数名</param>
        public static void CheckNull(this object obj, string parameterName)
        {
            if (obj == null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// 是否为空(验证Null、空格、空字符串)
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this string value)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="value">值</param>
        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return value == Guid.Empty;
        }

        /// <summary>
        /// 判断字符串是否为json 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool IsJson(this string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                json = json.Trim('\r', '\n', ' ');
                if (json.Length > 1)
                {
                    char s = json[0];
                    char e = json[json.Length - 1];
                    return (s == '{' && e == '}') || (s == '[' && e == ']');
                }
            }
            return false;
        }

        /// <summary>
        /// 是否数字
        /// </summary>
        /// <param name="input">输入值</param>        
        public static bool IsNumber(this string input)
        {
            if (input.IsEmpty())
                return false;
            const string pattern = @"^(-?\d*)(\.\d+)?$";
            return Regex.IsMatch(input, pattern);
        }


        #region 匹配完整的URL

        /// <summary>
        /// 验证网址(通过正则验证)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsUrlToRegex(this string input)
        {
            if (input.IsEmpty())
                return false;
            const string pattern = @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$";
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 匹配完整格式的URL
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns> 
        public static Uri IsUrl(this string s, out bool isMatch)
        {
            try
            {
                var uri = new Uri(s);
                isMatch = Dns.GetHostAddresses(uri.Host).Any(ip => !ip.IsPrivateIP());
                return uri;
            }
            catch
            {
                isMatch = false;
                return null;
            }
        }

        /// <summary>
        /// 匹配完整格式的URL
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool IsUrl(this string s)
        {
            IsUrl(s, out var isMatch);
            return isMatch;
        }

        #endregion

        #region 验证日期

        /// <summary>
        /// 验证日期
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDateTime(string input)
        {
            if (input.IsEmpty())
                return false;
            try
            {
                DateTime time = System.Convert.ToDateTime(input);
                return true;
            }
            catch
            {
                return false;
            }
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
            if (IsIP(ip))
            {
                return IsPrivateIP(IPAddress.Parse(ip));
            }
            //throw new ArgumentException(ip + "不是一个合法的ip地址");
            return false;
        }

        #endregion

        #region 校验IP地址的合法性

        /// <summary>
        /// 验证IP(通过正则验证)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsIPToRegex(string input)
        {
            if (input.IsEmpty())
                return false;
            const string pattern = @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$";
            return Regex.IsMatch(input, pattern);
        }

        /// <summary>
        /// 校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns> 
        public static IPAddress IsIP(this string s, out bool isMatch)
        {
            isMatch = IPAddress.TryParse(s, out var ip);
            return ip;
        }

        /// <summary>
        /// 校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool IsIP(this string s)
        {
            IsIP(s, out var success);
            return success;
        }

        #endregion

        #region 验证身份证是否有效

        /// <summary>
        /// 验证身份证是否有效
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static bool IsIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                return IsIDCard18(Id);
            }
            else if (Id.Length == 15)
            {
                return IsIDCard15(Id);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证18位身份证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private static bool IsIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        /// <summary>
        /// 验证15位身份证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private static bool IsIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        #region 验证是否位小数

        /// <summary>
        /// 验证是否位小数
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDecimal(string input)
        {
            if (input.IsEmpty())
                return false;
            const string pattern = @"[0].d{1,2}|[1]";
            return Regex.IsMatch(input, pattern);
        }

        #endregion

        #region 验证是否为中文

        /// <summary>
        /// 验证是否为中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsChinese(string input)
        {
            if (input.IsEmpty())
                return false;
            const string pattern = @"^[\u4e00-\u9fa5]+$";
            return Regex.IsMatch(input, pattern);
        }

        #endregion

        #region 验证是否包含中文

        /// <summary>
        /// 验证是否包含中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsContainChinese(string input)
        {
            if (input.IsEmpty())
                return false;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]");
            if (regex.Match(input).Success)
                return true;
            else
                return false;
        }

        #endregion

        #region 验证是否全部为中文

        /// <summary>
        /// 验证是否全部为中文
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsAllInChinese(string input)
        {
            if (input.IsEmpty())
                return false;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("[\u4e00-\u9fa5]");
            //匹配的内容长度和被验证的内容长度相同时，验证通过
            if (regex.Match(input).Success)
                if (regex.Matches(input).Count == input.Length)
                    return true;
            //其它，未通过
            return false;
        }

        #endregion

       
    }
}
