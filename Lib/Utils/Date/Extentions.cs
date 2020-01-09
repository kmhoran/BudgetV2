using System;

namespace Utils.Date
{
    public static class Extentions
    {
        public static string ToISOString(this DateTime date)
        {
            return date.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
    }
}
