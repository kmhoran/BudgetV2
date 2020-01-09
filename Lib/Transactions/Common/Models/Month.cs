using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Transactions.Common.Interfaces;

namespace Transactions.Common.Models
{
    public class Month<T> : IMonth<T>
    where T : IAccountable
    {
        public Month(int monthId, IEnumerable<T> values)
        {
            MonthId = monthId;
            Values = values;
        }
        public int MonthId { get; set; }
        public IEnumerable<T> Values { get; set; }

        [JsonIgnore]
        public double TotalAmount
        {
            get
            {
                return Values.Select(x => x.Amount).Sum();
            }
        }
    }
}