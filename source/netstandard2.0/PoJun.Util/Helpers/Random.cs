using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// 随机数操作
    /// </summary>
    public class Random
    {
        #region 对集合随机排序

        /// <summary>
        /// 对集合随机排序
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="array">集合</param>
        public static List<T> Sort<T>(IEnumerable<T> array)
        {
            if (array == null)
                return null;
            var random = new System.Random();
            var list = array.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                int index1 = random.Next(0, list.Count);
                int index2 = random.Next(0, list.Count);
                T temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }
            return list;
        }

        #endregion

        #region 获取随机数

        private const int capacity10 = 10;
        private const int capacity36 = 36;
        private const int capacity62 = 62;

        /// <summary>
        /// 取随机数
        /// </summary>
        /// <param name="type">1：纯数字【默认】；2：字母(小写)+数字；3：字母(大写+小写)+数字；4：字母(大写)+数字；</param>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string RandomString(int type, int length)
        {
            char[] constant;
            switch (type)
            {
                default:
                case 1:
                    constant = new char[capacity10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    break;
                case 2:
                    constant = new char[capacity36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                    break;
                case 3:
                    constant = new char[capacity62] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    break;
                case 4:
                    constant = new char[capacity36] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                    break;
            }

            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(constant.Length);
            System.Random rd = new System.Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[rd.Next(constant.Length)]);
            }
            return newRandom.ToString();

        }

        #endregion
    }
}
