using System;
using System.Collections.Generic;
using System.Linq;

namespace Transactions.Common.Models
{
    public class MonthTransactions
    {
        public int MonthId { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public IEnumerable<Income> Income { get; set; }
        public IEnumerable<BalanceAdjustment> Adjustments { get; set; }

        public double IncomeTotal
        {
            get
            {
                return Income.Select(x => x.Amount).Sum();
            }
        }

        public double ExpenseTotal
        {
            get
            {
                return Expenses.Select(x => x.Amount).Sum();
            }
        }
        public double AdjustmentTotal
        {
            get
            {
                return Adjustments.Select(x => x.Amount).Sum();
            }
        }
        public double Balance
        {
            get
            {
                return (IncomeTotal + AdjustmentTotal) - ExpenseTotal;
            }
        }
    }
}