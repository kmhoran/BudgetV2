using System;

namespace Transactions.Common.Models
{
    public class Expense : TransactionBase
    {
        public string ByUserId { get; set; }
    }
}