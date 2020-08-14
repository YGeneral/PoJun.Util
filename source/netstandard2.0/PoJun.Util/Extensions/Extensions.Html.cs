using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoJun.Util
{
    /// <summary>
    /// Html工具类
    /// 创建人：杨江军
    /// 创建时间：2020/8/13/星期四 13:59:06
    /// 
    /// ------------------------------------调用示例--------------------------------------------
    /// var srcs = "html".MatchImgSrcs().ToList();// 获取html字符串里所有的img标签的src属性
    /// var imgTags = "html".MatchImgTags();//获取html字符串里的所有的img标签
    /// ----------------------------------------------------------------------------------------
    /// </summary>
    public static partial class Extensions
    {
        #region 匹配html的所有img标签集合

        /// <summary>
        /// 匹配html的所有img标签集合
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IEnumerable<HtmlNode> MatchImgTags(this string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.Descendants("img");
            return nodes;
        }

        #endregion

        #region 匹配html的所有img标签的src集合

        /// <summary>
        /// 匹配html的所有img标签的src集合
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IEnumerable<string> MatchImgSrcs(this string html)
        {
            return MatchImgTags(html).Where(n => n.Attributes.Contains("src")).Select(n => n.Attributes["src"].Value);
        }

        #endregion

        #region 获取html中第一个img标签的src

        /// <summary>
        /// 获取html中第一个img标签的src
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string MatchFirstImgSrc(this string html)
        {
            return MatchImgSrcs(html).FirstOrDefault();
        }

        #endregion

        #region 随机获取html代码中的img标签的src属性

        /// <summary>
        /// 随机获取html代码中的img标签的src属性
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string MatchRandomImgSrc(this string html)
        {
            int count = MatchImgSrcs(html).Count();
            var rnd = new System.Random();
            return MatchImgSrcs(html).ElementAtOrDefault(rnd.Next(count));
        }

        #endregion

        #region 替换回车换行符为html换行符

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        /// <param name="str">html</param>
        public static string StrFormat(this string str)
        {
            return str.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        #endregion
    }
}
