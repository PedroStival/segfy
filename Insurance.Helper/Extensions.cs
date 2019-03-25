using System;
using System.Text.RegularExpressions;

namespace Insurance.Helper
{
    public static class Extensions
    {
        public static DateTime GetTimeFromUploadedFileName(string filename)
        {
            var regex = new Regex(@"(\d{4,})");
            var matches = regex.Matches(filename.Substring(filename.LastIndexOf("\\", StringComparison.Ordinal)));
            if (matches.Count == 0) return DateTime.MinValue;

            var ticksStr = matches[0].Value;
            long ticks;
            if (!long.TryParse(ticksStr, out ticks)) return DateTime.MinValue;

            var date = new DateTime(ticks);

            return date;
        }

        public static string ToSqlDatetime(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
