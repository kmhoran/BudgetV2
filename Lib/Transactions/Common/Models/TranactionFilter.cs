using System;
using System.Collections.Generic;

namespace Transactions.Common.Models
{
    public class TransactionFilter
    {
        public InputRange<string> DateRange { get; set; }
        public MinorFilter Expense { get; set; }
        public MinorFilter Income { get; set; }
        public MinorFilter Adjustment { get; set; }
    }

    public class MinorFilter
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string TextSearch { get; set; }
        public InputRange<double?> Amount { get; set; }
    }

    public class InputRange<T>
    {
        public T End { get; set; }
        public T Start { get; set; }
    }
}