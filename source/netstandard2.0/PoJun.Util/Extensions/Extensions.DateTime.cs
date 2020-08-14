using PoJun.Util.Helpers;
using System;
using System.Diagnostics;
using System.Text;

namespace PoJun.Util
{
    /// <summary>
    /// 系统扩展 - 日期
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime dateTime, bool removeSecond = false)
        {
            if (removeSecond)
                return dateTime.ToString("yyyy-MM-dd HH:mm");
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime? dateTime, bool removeSecond = false)
        {
            if (dateTime == null)
                return string.Empty;
            return ToDateTimeString(dateTime.Value, removeSecond);
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToDateString(dateTime.Value);
        }

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 获取格式化字符串，不带年月日，格式："HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToTimeString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToTimeString(dateTime.Value);
        }

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        /// <summary>
        /// 获取格式化字符串，带毫秒，格式："yyyy-MM-dd HH:mm:ss.fff"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToMillisecondString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToMillisecondString(dateTime.Value);
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy年MM月dd日"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToChineseDateString(this DateTime dateTime)
        {
            return string.Format("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy年MM月dd日"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToChineseDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToChineseDateString(dateTime.SafeValue());
        }

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy年MM月dd日 HH时mm分"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToChineseDateTimeString(this DateTime dateTime, bool removeSecond = false)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
            result.AppendFormat(" {0}时{1}分", dateTime.Hour, dateTime.Minute);
            if (removeSecond == false)
                result.AppendFormat("{0}秒", dateTime.Second);
            return result.ToString();
        }

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy年MM月dd日 HH时mm分"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="removeSecond">是否移除秒</param>
        public static string ToChineseDateTimeString(this DateTime? dateTime, bool removeSecond = false)
        {
            if (dateTime == null)
                return string.Empty;
            return ToChineseDateTimeString(dateTime.Value, removeSecond);
        }

        #region 获取描述

        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="span">时间间隔</param>
        public static string Description(this TimeSpan span)
        {
            StringBuilder result = new StringBuilder();
            if (span.Days > 0)
                result.AppendFormat("{0}天", span.Days);
            if (span.Hours > 0)
                result.AppendFormat("{0}小时", span.Hours);
            if (span.Minutes > 0)
                result.AppendFormat("{0}分", span.Minutes);
            if (span.Seconds > 0)
                result.AppendFormat("{0}秒", span.Seconds);
            if (span.Milliseconds > 0)
                result.AppendFormat("{0}毫秒", span.Milliseconds);
            if (result.Length > 0)
                return result.ToString();
            return $"{span.TotalSeconds * 1000}毫秒";
        }

        #endregion

        #region 得到指定日期的当月第一天

        /// <summary>
        /// 得到指定日期的当月第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        #endregion       

        #region 得到指定日期当月的最后一天

        /// <summary>
        /// 得到指定日期当月的最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return dateTime.AddMonths(1).AddDays(-dateTime.Day);
        }

        #endregion

        #region DateTime时间格式转换为Unix时间戳格式

        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int DateTimeToTimeStamp(this System.DateTime time)
        {
            var startTime =
            System.TimeZoneInfo.ConvertTimeFromUtc(new System.DateTime(1970, 1, 1), TimeZoneInfo.Local);
            return (int)(time - startTime).TotalSeconds;
        }

        #endregion

        #region 获取当前时间的毫秒数

        /// <summary>
        /// 获取当前时间的毫秒数
        /// </summary>
        /// <returns></returns>
        public static long GetMillisecond(this DateTime dateTime)
        {
            return System.Convert.ToInt64(Math.Floor(dateTime.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds));
        }

        #endregion

        #region 获取当前时间的天数

        /// <summary>
        /// 获取当前时间的天数
        /// </summary>
        /// <returns></returns>
        public static long GetDaysNumber(this DateTime dateTime)
        {
            return System.Convert.ToInt64(Math.Floor(dateTime.Subtract(new DateTime(1970, 1, 1)).TotalDays));
        }

        #endregion

        #region 返回相对于当前时间的相对天数

        /// <summary>
        /// 返回相对于当前时间的相对天数
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="relativeday">相对天数</param>
        public static string GetDateTime(this DateTime dt, int relativeday)
        {
            return dt.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion

        #region 获取该时间相对于1970-01-01 00:00:00的微秒时间戳

        /// <summary>
        /// 获取该时间相对于1970-01-01 00:00:00的微秒时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long GetTotalMicroseconds(this DateTime dt) => new DateTimeOffset(dt).Ticks / 10; 

        #endregion

        #region 获取该时间相对于1970-01-01 00:00:00的纳秒时间戳

        /// <summary>
        /// 获取该时间相对于1970-01-01 00:00:00的纳秒时间戳
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static long GetTotalNanoseconds(this DateTime dt) => new DateTimeOffset(dt).Ticks * 100 + Stopwatch.GetTimestamp() % 100;

        #endregion

        #region 获取本年有多少天

        /// <summary>
        /// 获取本年有多少天
        /// </summary>
        /// <param name="_"></param>
        /// <param name="iYear">年份</param>
        /// <returns>本年的天数</returns>
        public static int GetDaysOfYear(this DateTime _, int iYear)
        {
            return Time.IsRuYear(iYear) ? 366 : 365;
        }

        /// <summary>
        /// 获取本年有多少天
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>本天在当年的天数</returns>
        public static int GetDaysOfYear(this DateTime dt)
        {
            //取得传入参数的年份部分，用来判断是否是闰年
            return Time.IsRuYear(dt.Year) ? 366 : 365;
        }

        #endregion

        #region 获取本月有多少天

        /// <summary>
        /// 获取本月有多少天
        /// </summary>
        /// <param name="_"></param>
        /// <param name="iYear">年</param>
        /// <param name="month">月</param>
        /// <returns>天数</returns>
        public static int GetDaysOfMonth(this DateTime _, int iYear, int month)
        {
            return month switch
            {
                1 => 31,
                2 => (Time.IsRuYear(iYear) ? 29 : 28),
                3 => 31,
                4 => 30,
                5 => 31,
                6 => 30,
                7 => 31,
                8 => 31,
                9 => 30,
                10 => 31,
                11 => 30,
                12 => 31,
                _ => 0
            };
        }

        /// <summary>
        /// 获取本月有多少天
        /// </summary>
        /// <param name="dt">日期</param>
        /// <returns>天数</returns>
        public static int GetDaysOfMonth(this DateTime dt)
        {
            //--利用年月信息，得到当前月的天数信息。
            return dt.Month switch
            {
                1 => 31,
                2 => (Time.IsRuYear(dt.Year) ? 29 : 28),
                3 => 31,
                4 => 30,
                5 => 31,
                6 => 30,
                7 => 31,
                8 => 31,
                9 => 30,
                10 => 31,
                11 => 30,
                12 => 31,
                _ => 0
            };
        }

        #endregion

        #region 获取当前日期的星期名称

        /// <summary>
        /// 获取当前日期的星期名称
        /// </summary>
        /// <param name="idt">日期</param>
        /// <returns>星期名称</returns>
        public static string GetWeekNameOfDay(this DateTime idt)
        {
            return idt.DayOfWeek.ToString() switch
            {
                "Mondy" => "星期一",
                "Tuesday" => "星期二",
                "Wednesday" => "星期三",
                "Thursday" => "星期四",
                "Friday" => "星期五",
                "Saturday" => "星期六",
                "Sunday" => "星期日",
                _ => ""
            };
        }

        #endregion

        #region 获取当前日期的星期编号

        /// <summary>
        /// 获取当前日期的星期编号
        /// </summary>
        /// <param name="idt">日期</param>
        /// <returns>星期数字编号</returns>
        public static string GetWeekNumberOfDay(this DateTime idt)
        {
            return idt.DayOfWeek.ToString() switch
            {
                "Mondy" => "1",
                "Tuesday" => "2",
                "Wednesday" => "3",
                "Thursday" => "4",
                "Friday" => "5",
                "Saturday" => "6",
                "Sunday" => "7",
                _ => ""
            };
        }

        #endregion

        #region 得到随机日期

        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTime GetRandomTime(this DateTime time1, DateTime time2)
        {
            var random = new System.Random();
            DateTime minTime;
            var ts = new TimeSpan(time1.Ticks - time2.Ticks);
            // 获取两个时间相隔的秒数
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds;
            if (dTotalSecontds > int.MaxValue) iTotalSecontds = int.MaxValue;
            else if (dTotalSecontds < int.MinValue) iTotalSecontds = int.MinValue;
            else iTotalSecontds = (int)dTotalSecontds;
            if (iTotalSecontds > 0)
            {
                minTime = time2;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;
            if (iTotalSecontds <= int.MinValue)
            {
                maxValue = int.MinValue + 1;
            }

            int i = random.Next(Math.Abs(maxValue));
            return minTime.AddSeconds(i);
        }

        #endregion

        #region 获得一段时间内有多少小时

        /// <summary>
        /// 获得一段时间内有多少小时
        /// </summary>
        /// <param name="dtStar">起始时间</param>
        /// <param name="dtEnd">终止时间</param>
        /// <returns>小时差</returns>
        public static TimeSpan GetTimeDelay(this DateTime dtStar, DateTime dtEnd)
        {
            long lTicks = (dtEnd.Ticks - dtStar.Ticks) / 10000000;
            var h = System.Convert.ToInt32((lTicks / 3600).ToString().PadLeft(2, '0'));
            var m = System.Convert.ToInt32((lTicks % 3600 / 60).ToString().PadLeft(2, '0'));
            var s = System.Convert.ToInt32((lTicks % 3600 % 60).ToString().PadLeft(2, '0'));
            return new TimeSpan(h, m, s);
        }

        #endregion
    }
}
