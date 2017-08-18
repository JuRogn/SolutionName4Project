using System;
using System.Collections.Generic;
using System.Text;

namespace  Wjw1.Infrastructure
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtentionMethods
    {

        public static string ToDateTimeString(this DateTime value)
        {
            return value.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string ToDateTimeAdd8hString(this DateTime value)
        {
            return value.AddHours(8).ToDateTimeString();
        }

        public static string ToDateString(this DateTime value)
        {
            return value.ToString("yyyy/MM/dd");
        }

        public static string ToDateAdd8hString(this DateTime value)
        {
            return value.AddHours(8).ToDateString();
        }

        public static string ToTimeString(this DateTime value)
        {
            return value.ToString("HH:mm:ss");
        }

        public static string ToTimeAdd8hString(this DateTime value)
        {
            return value.AddHours(8).ToTimeString();
        }
    }
}
