using System;
using Core.Data.Models;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace Transactions.Repositories
{
    public class BalanceAdjustmentRepository : TransactionRepository<BalanceAdjustment>, IBalanceAdjustmentRepository
    {
        public BalanceAdjustmentRepository(IBudgetDbSettings settings)
        : base(settings, "BalanceAdjustment")
        {
        }
    }
}
