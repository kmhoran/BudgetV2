using System;
using Transactions.Common.Interfaces;

namespace Transactions.Common.Models
{
    public class CategoryBalance : INamedBalance
    {
        public CategoryBalance() { }
        public CategoryBalance(string Name, double amount, int monthId) { }
        public string Name { get; set; }

        public double Amount { get; set; }

        public int MonthId { get; set; }
    }
}