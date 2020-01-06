using System;
using Core.Data.Models;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace Transactions.Repositories
{
    public class IncomeRepository : TransactionRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(IBudgetDbSettings settings)
        : base(settings, "Income")
        {
        }
    }
}
