using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Data.Models;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

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
