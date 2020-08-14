using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace PoJun.Util
{
    /// <summary>
    /// 系统扩展 - 字符串
    /// </summary>
    public static partial class Extensions
    {
        #region 字符串掩码

        /// <summary>
        /// 字符串掩码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="mask">掩码符</param>
        /// <returns></returns>
        public static string Mask(this string s, char mask = '*')
        {
            if (string.IsNullOrWhiteSpace(s?.Trim()))
            {
                return s;
            }
            s = s.Trim();
            string masks = mask.ToString().PadLeft(4, mask);
            return s.Length switch
            {
                _ when s.Length >= 11 => Regex.Replace(s, @"(\w{3})\w*(\w{4})", $"$1{masks}$2"),
                _ when s.Length == 10 => Regex.Replace(s, @"(\w{3})\w*(\w{3})", $"$1{masks}$2"),
                _ when s.Length == 9 => Regex.Replace(s, @"(\w{2})\w*(\w{3})", $"$1{masks}$2"),
                _ when s.Length == 8 => Regex.Replace(s, @"(\w{2})\w*(\w{2})", $"$1{masks}$2"),
                _ when s.Length == 7 => Regex.Replace(s, @"(\w{1})\w*(\w{2})", $"$1{masks}$2"),
                _ when s.Length >= 2 && s.Length < 7 => Regex.Replace(s, @"(\w{1})\w*(\w{1})", $"$1{masks}$2"),
                _ => s + masks
            };
        }

        #endregion

        #region 邮箱掩码

        /// <summary>
        /// 邮箱掩码
        /// </summary>
        /// <param name="s">邮箱</param>
        /// <param name="mask">掩码</param>
        /// <returns></returns>
        public static string MaskEmail(this string s, char mask = '*')
        {
            return s.Replace(s.Substring(0, s.LastIndexOf("@")), Mask(s.Substring(0, s.LastIndexOf("@")), mask));
        }

        #endregion

        #region 检测字符串中是否包含列表中的关键词

        /// <summary>
        /// 检测字符串中是否包含列表中的关键词
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="keys">关键词列表</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <returns></returns>
        public static bool Contains(this string s, IEnumerable<string> keys, bool ignoreCase = true)
        {
            if (!keys.Any() || string.IsNullOrEmpty(s))
            {
                return false;
            }

            if (ignoreCase)
            {
                return Regex.IsMatch(s, string.Join("|", keys), RegexOptions.IgnoreCase);
            }

            return Regex.IsMatch(s, string.Join("|", keys));

        }

        #endregion

        #region PinYin(获取汉字的拼音简码)

        /// <summary>
        /// 获取汉字的拼音简码，即首字母缩写,范例：中国,返回zg
        /// </summary>
        /// <param name="chineseText">汉字文本,范例： 中国</param>
        public static string PinYin(this string chineseText)
        {
            if (string.IsNullOrWhiteSpace(chineseText))
                return string.Empty;
            var result = new StringBuilder();
            foreach (char text in chineseText)
                result.AppendFormat("{0}", ResolvePinYin(text));
            return result.ToString().ToLower();
        }

        /// <summary>
        /// 解析单个汉字的拼音简码
        /// </summary>
        private static string ResolvePinYin(char text)
        {
            byte[] charBytes = Encoding.UTF8.GetBytes(text.ToString());
            if (charBytes[0] <= 127)
                return text.ToString();
            var unicode = (ushort)(charBytes[0] * 256 + charBytes[1]);
            string pinYin = ResolveByCode(unicode);
            if (!string.IsNullOrWhiteSpace(pinYin))
                return pinYin;
            return ResolveByConst(text.ToString());
        }

        /// <summary>
        /// 使用字符编码方式获取拼音简码
        /// </summary>
        private static string ResolveByCode(ushort unicode)
        {
            if (unicode >= '\uB0A1' && unicode <= '\uB0C4')
                return "A";
            if (unicode >= '\uB0C5' && unicode <= '\uB2C0' && unicode != 45464)
                return "B";
            if (unicode >= '\uB2C1' && unicode <= '\uB4ED')
                return "C";
            if (unicode >= '\uB4EE' && unicode <= '\uB6E9')
                return "D";
            if (unicode >= '\uB6EA' && unicode <= '\uB7A1')
                return "E";
            if (unicode >= '\uB7A2' && unicode <= '\uB8C0')
                return "F";
            if (unicode >= '\uB8C1' && unicode <= '\uB9FD')
                return "G";
            if (unicode >= '\uB9FE' && unicode <= '\uBBF6')
                return "H";
            if (unicode >= '\uBBF7' && unicode <= '\uBFA5')
                return "J";
            if (unicode >= '\uBFA6' && unicode <= '\uC0AB')
                return "K";
            if (unicode >= '\uC0AC' && unicode <= '\uC2E7')
                return "L";
            if (unicode >= '\uC2E8' && unicode <= '\uC4C2')
                return "M";
            if (unicode >= '\uC4C3' && unicode <= '\uC5B5')
                return "N";
            if (unicode >= '\uC5B6' && unicode <= '\uC5BD')
                return "O";
            if (unicode >= '\uC5BE' && unicode <= '\uC6D9')
                return "P";
            if (unicode >= '\uC6DA' && unicode <= '\uC8BA')
                return "Q";
            if (unicode >= '\uC8BB' && unicode <= '\uC8F5')
                return "R";
            if (unicode >= '\uC8F6' && unicode <= '\uCBF9')
                return "S";
            if (unicode >= '\uCBFA' && unicode <= '\uCDD9')
                return "T";
            if (unicode >= '\uCDDA' && unicode <= '\uCEF3')
                return "W";
            if (unicode >= '\uCEF4' && unicode <= '\uD188')
                return "X";
            if (unicode >= '\uD1B9' && unicode <= '\uD4D0')
                return "Y";
            if (unicode >= '\uD4D1' && unicode <= '\uD7F9')
                return "Z";
            return string.Empty;
        }

        /// <summary>
        /// 通过拼音简码常量获取
        /// </summary>
        private static string ResolveByConst(string text)
        {
            int index = Helpers.Const.ChinesePinYin.IndexOf(text, StringComparison.Ordinal);
            if (index < 0)
                return string.Empty;
            return Helpers.Const.ChinesePinYin.Substring(index + 1, 1);
        }

        #endregion

        #region FirstLowerCase(首字母小写)

        /// <summary>
        /// 首字母小写
        /// </summary>
        /// <param name="value">值</param>
        public static string FirstLowerCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            return $"{value.Substring(0, 1).ToLower()}{value.Substring(1)}";
        }

        #endregion

        #region 把字符串按照分隔符转换成 List

        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetStrArray(this string str, char speater, bool toLower = false)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }

        #endregion

        #region 把字符串按照[,]分割转换为数组

        /// <summary>
        /// 把字符串按照[,]分割转换为数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] GetStrArray(this string str)
        {
            return str.Split(new Char[] { ',' });
        }

        #endregion

        #region 删除最后一个字符之后的字符

        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DelLastComma(this string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strchar">指定字符</param>
        /// <returns></returns>
        public static string DelLastChar(this string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }

        #endregion

        #region 转全角的函数(SBC case)

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(this string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        #endregion

        #region 转半角的函数(SBC case)

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string ToDBC(this string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }

        #endregion

        #region 把字符串按照指定分隔符装成 List 去除重复

        /// <summary>
        /// 把字符串按照指定分隔符装成 List 去除重复
        /// </summary>
        /// <param name="o_str"></param>
        /// <param name="sepeater"></param>
        /// <returns></returns>
        public static List<string> GetSubStringList(this string o_str, char sepeater)
        {
            List<string> list = new List<string>();
            string[] ss = o_str.Split(sepeater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != sepeater.ToString())
                {
                    list.Add(s);
                }
            }
            return list;
        }

        #endregion

        #region RemoveEnd(移除末尾字符串)

        /// <summary>
        /// 移除末尾字符串
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="removeValue">要移除的值</param>
        public static string RemoveEnd(this string value, string removeValue)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            if (string.IsNullOrWhiteSpace(removeValue))
                return value.SafeString();
            if (value.ToLower().EndsWith(removeValue.ToLower()))
                return value.Remove(value.Length - removeValue.Length, removeValue.Length);
            return value;
        }

        #endregion

        #region SplitWordGroup(分隔词组)

        /// <summary>
        /// 分隔词组
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="separator">分隔符，默认使用"-"分隔</param>
        public static string SplitWordGroup(this string value, char separator = '-')
        {
            var pattern = @"([A-Z])(?=[a-z])|(?<=[a-z])([A-Z]|[0-9]+)";
            return string.IsNullOrWhiteSpace(value) ? string.Empty : System.Text.RegularExpressions.Regex.Replace(value, pattern, $"{separator}$1$2").TrimStart(separator).ToLower();
        }

        #endregion

        #region 在字符串中删除传入集合中的字符串

        /// <summary>
        /// 在字符串中删除传入集合中的字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strList">字符集合</param>
        /// <returns></returns>
        public static string Remove(this string str, List<string> strList)
        {
            foreach (var item in strList)
            {
                str = str.Replace(item, null);
            }
            return str;
        }

        #endregion

        #region 判断字符串中是否全部安装顺序包含该集合中的字符

        /// <summary>
        /// 判断字符串中是否全部安装顺序包含该集合中的字符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strList">字符集合</param>
        /// <returns></returns> 
        public static bool OrderContains(this string str, List<string> strList)
        {
            var order = new List<int>();
            foreach (var item in strList)
            {
                if (!str.Contains(item))
                    return false;
                order.Add(str.IndexOf(item));
            }
            var newOrder = order.OrderBy(x => x).ToList();
            if (string.Join("", order) == string.Join("", newOrder))
                return true;
            else
                return false;
        }

        #endregion

        #region 判断字符串中是否全部包含该集合中的字符

        /// <summary>
        /// 判断字符串中是否全部包含该集合中的字符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="strList">字符集合</param>
        /// <returns></returns>
        public static bool Contains(this string str, List<string> strList)
        {
            foreach (var item in strList)
            {
                if (!str.Contains(item))
                    return false;
            }
            return true;
        }

        #endregion

        #region 判断字符串中是否不包含字符

        /// <summary>
        /// 判断字符串中是否不包含字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strList">不包含字符集合</param>
        /// <returns>如果不包含则返回true，如果包含则返回false</returns>
        public static bool NotContains(this string str, List<string> strList)
        {
            foreach (var item in strList)
            {
                if (str.Contains(item))
                    return false;
            }
            return true;
        }

        #endregion
    }
}
