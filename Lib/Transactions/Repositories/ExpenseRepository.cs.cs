using System;
using Core.Data.Models;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace Transactions.Repositories
{
    public class ExpenseRepository : TransactionRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IBudgetDbSettings settings)
        : base(settings, "Expenses")
        {
        }
    }
}
