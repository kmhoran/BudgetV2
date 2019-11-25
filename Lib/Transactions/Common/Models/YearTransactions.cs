using System;
using System.Collections.Generic;
using System.Linq;
using Utils.Date;

namespace Transactions.Common.Models
{
    public class YearTransactions
    {
        public int YearId { get; set; }
        public MonthTransactions January { get; set; }
        public MonthTransactions February { get; set; }
        public MonthTransactions March { get; set; }
        public MonthTransactions April { get; set; }
        public MonthTransactions May { get; set; }
        public MonthTransactions June { get; set; }
        public MonthTransactions July { get; set; }
        public MonthTransactions August { get; set; }
        public MonthTransactions September { get; set; }
        public MonthTransactions October { get; set; }
        public MonthTransactions November { get; set; }
        public MonthTransactions December { get; set; }

        public IEnumerable<MonthTransactions> Months
        {
            get
            {
                var months = new List<MonthTransactions>{
                    January,
                    February,
                    March,
                    April,
                    May,
                    June,
                    July,
                    August,
                    September,
                    October,
                    November,
                    December
                };
                return months.Where(x => x != null);
            }
        }

        public double IncomeTotal
        {
            get
            {
                return Months.Select(x => x.IncomeTotal).Sum();
            }
        }

        public double ExpenseTotal
        {
            get
            {
                return Months.Select(x => x.ExpenseTotal).Sum();
            }

        }
        public double AdjustmentTotal
        {
            get
            {
                return Months.Select(x => x.AdjustmentTotal).Sum();
            }
        }
        public double Balance
        {
            get
            {
                return (IncomeTotal + AdjustmentTotal) - ExpenseTotal;
            }
        }

        public MonthTransactions GetMonth(int? monthId)
        {
            monthId = monthId ?? MonthUtil.CurretMonthId;

            if (MonthUtil.GetYear(monthId ?? 0) != YearId)
                throw new ArgumentException($"Month {monthId} not found within Year {YearId}");
            
            var ordinal = monthId %100;
            switch(ordinal){
                case 1: return January;
                case 2: return February;
                case 3: return March;
                case 4: return April;
                case 5: return May;
                case 6: return June;
                case 7: return July;
                case 8: return August;
                case 9: return September;
                case 10: return October;
                case 11: return November;
                case 12: return December;
                default: throw new ArgumentException($"Invalid Month {monthId}");
            }
        }
    }
}