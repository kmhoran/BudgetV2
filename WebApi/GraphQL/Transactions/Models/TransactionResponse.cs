using System;
using System.Collections.Generic;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Models
{
    public class TransactionResponse
    {
        public TransactionCollection<Expense> Expense { get; set; }
        public TransactionCollection<Income> Income {get; set;}
        public TransactionCollection<BalanceAdjustment> Adjustment { get; set; }
    }

    public class TransactionCollection<T>
    where T : ITransaction
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}