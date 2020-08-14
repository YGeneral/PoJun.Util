using System;

namespace PoJun.Util.Helpers
{
    /// <summary>
    /// 时间操作
    /// </summary>
    public static class Time
    {
        #region 获取Unix时间戳

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        public static long GetUnixTimestamp()
        {
            return GetUnixTimestamp(DateTime.Now);
        }

        #endregion

        #region 获取Unix时间戳

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="time">时间</param>
        public static long GetUnixTimestamp(DateTime time)
        {
            var start = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long ticks = (time - start.Add(new TimeSpan(8, 0, 0))).Ticks;
            return PoJun.Util.Helpers.Convert.ToLong(ticks / TimeSpan.TicksPerSecond);
        }

        #endregion

        #region 从Unix时间戳获取时间

        /// <summary>
        /// 从Unix时间戳获取时间
        /// </summary>
        /// <param name="timestamp">Unix时间戳</param>
        public static DateTime GetTimeFromUnixTimestamp(long timestamp)
        {
            var start = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            TimeSpan span = new TimeSpan(long.Parse(timestamp + "0000000"));
            return start.Add(span).Add(new TimeSpan(8, 0, 0));
        }

        #endregion

        #region 得到本月第一天

        /// <summary>
        /// 得到本月第一天
        /// </summary>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth()
        {
            DateTime dt = DateTime.Now;
            return FirstDayOfMonth(dt);
        }

        #endregion

        #region 得到指定日期的当月第一天

        /// <summary>
        /// 得到指定日期的当月第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(DateTime dt)
        {
            DateTime d = new DateTime(dt.Year, dt.Month, 1);
            return d;
        }

        #endregion

        #region 得到本月最后一天

        /// <summary>
        /// 得到本月最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime LastDayOfMonth()
        {
            DateTime dt = DateTime.Now;
            return LastDayOfMonth(dt);
        }

        #endregion

        #region 得到指定日期当月的最后一天

        /// <summary>
        /// 得到指定日期当月的最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime dt)
        {
            DateTime d = dt.AddMonths(1).AddDays(-dt.Day);
            return d;
        }

        #endregion

        #region 获取当前时间的毫秒数

        /// <summary>
        /// 获取当前时间的毫秒数
        /// </summary>
        /// <returns></returns>
        public static long GetMillisecond()
        {
            return System.Convert.ToInt64(Math.Floor(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds));
        }

        #endregion

        #region 获取当前时间的天数

        /// <summary>
        /// 获取当前时间的天数
        /// </summary>
        /// <returns></returns>
        public static long GetDaysNumber()
        {
            return System.Convert.ToInt64(Math.Floor(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalDays));
        }

        #endregion

        #region 获取指定日期的天数

        /// <summary>
        /// 获取指定日期的天数
        /// </summary>
        /// <param name="appointDay">指定日期</param>
        /// <returns></returns>
        public static long GetAppointDaysNumber(DateTime appointDay)
        {
            return System.Convert.ToInt64(Math.Floor(appointDay.Subtract(new DateTime(1970, 1, 1)).TotalDays));
        }

        #endregion

        #region  DateTime转Unix

        /// <summary>
        /// DateTime转Unix
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeToUnix(DateTime time)
        {
            return ((time.ToUniversalTime().Ticks - 621355968000000000) / 10000);
        }

        #endregion

        #region  DateTime转Unix

        /// <summary>
        /// DateTime转Unix
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeToUnixTo10(DateTime time)
        {
            return ((time.ToUniversalTime().Ticks - 621355968000000000) / 10000000);
        }

        #endregion

        #region Unix转DateTime

        /// <summary>
        /// Unix转DateTime
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
        public static DateTime ConvertUnixToDateTime(long unix)
        {
            DateTime startUnixTime = System.TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);
            long lTime = long.Parse(unix + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            return startUnixTime.Add(toNow);
        }

        #endregion

        #region Unix转DateTime(10位) 

        /// <summary>
        /// Unix转DateTime(10位) 
        /// </summary>
        /// <param name="unix"></param>
        /// <returns></returns>
        public static DateTime ConvertUnixToDateTimeTo10(long unix)
        {
            DateTime startUnixTime = System.TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc), TimeZoneInfo.Local);
            return startUnixTime.AddSeconds(unix);
        }

        #endregion

        #region 判断当前年份是否是闰年，私有函数

        /// <summary>
        /// 判断当前年份是否是闰年，私有函数
        /// </summary>
        /// <param name="iYear">年份(例如：2003)</param>
        /// <returns>是闰年：True ，不是闰年：False</returns>
        public static bool IsRuYear(int iYear)
        {
            //形式参数为年份
            //例如：2003
            return iYear % 400 == 0 || iYear % 4 == 0 && iYear % 100 != 0;
        }

        #endregion

        #region 得到随机日期

        /// <summary>
        /// 得到随机日期
        /// </summary>
        /// <param name="time1">起始日期</param>
        /// <param name="time2">结束日期</param>
        /// <returns>间隔日期之间的 随机日期</returns>
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
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
        public static TimeSpan GetTimeDelay(DateTime dtStar, DateTime dtEnd)
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