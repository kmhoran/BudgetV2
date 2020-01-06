using System;

namespace Transactions.Common.Models
{
    public class PerformanceBase {
        public double ExpenseTotal { get; set; }
        public double ExpenseProjected { get; set; }
        public double IncomeTotal { get; set; }
        public double IncomeProjected { get; set; }
        public double AdjustedTotal { get; set; }
        public double GoalTotal { get; set; }
    }
}