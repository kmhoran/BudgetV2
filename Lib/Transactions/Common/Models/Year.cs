using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Transactions.Common.Interfaces;

namespace Transactions.Common.Models
{
    public class Year<T>
    where T : IAccountable
    {
        public Year() { }
        public Year(int yearId, IEnumerable<IMonth<T>> months)
        {
            YearId = yearId;
            foreach (var month in months)
            {
                switch (month.MonthId % 100)
                {
                    case 1:
                        January = month;
                        break;
                    case 2:
                        February = month;
                        break;
                    case 3:
                        March = month;
                        break;
                    case 4:
                        April = month;
                        break;
                    case 5:
                        May = month;
                        break;
                    case 6:
                        June = month;
                        break;
                    case 7:
                        July = month;
                        break;
                    case 8:
                        August = month;
                        break;
                    case 9:
                        September = month;
                        break;
                    case 10:
                        October = month;
                        break;
                    case 11:
                        November = month;
                        break;
                    case 12:
                        December = month;
                        break;
                    default:
                        throw new ArgumentException($"Month {month.MonthId} is invalid");
                }
            }

        }
        public int YearId { get; set; }
        public IMonth<T> January { get; set; }
        public IMonth<T> February { get; set; }
        public IMonth<T> March { get; set; }
        public IMonth<T> April { get; set; }
        public IMonth<T> May { get; set; }
        public IMonth<T> June { get; set; }
        public IMonth<T> July { get; set; }
        public IMonth<T> August { get; set; }
        public IMonth<T> September { get; set; }
        public IMonth<T> October { get; set; }
        public IMonth<T> November { get; set; }
        public IMonth<T> December { get; set; }

        public IEnumerable<IMonth<T>> Months
        {
            get
            {
                var months = new List<IMonth<T>>{
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

        public double TotalAmount
        {
            get
            {
                return Months.Select(x => x.TotalAmount).Sum();
            }
        }
    }
}