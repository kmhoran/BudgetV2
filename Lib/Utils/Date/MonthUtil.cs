using System;

namespace Utils.Date
{
    public static class MonthUtil
    {
        public static int CurretMonthId
        {
            get
            {
                var now = DateTime.Now;
                return (now.Year) * 100 + (now.Month);
            }

        }

        public static int GetMonthId(int year, int month)
            => (year *100) + month;

        public static int GetMonthId(DateTime date) => GetMonthId(date.Year, date.Month);

        public static int GetYear(int monthId)
        {
            return monthId / 100;
        }

        public static (int year, int month) ParseMonthId(int monthId)
        {
            var month = monthId % 100;
            var year = monthId / 100;
            return (year, month);
        }
    }
}
