using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IBalanceAdjustmentService : ITransactionService<BalanceAdjustment>
    {
        Task<BalanceAdjustment> GetASync(string id);
        Task<(List<BalanceAdjustment> records, int count)> FilterAsync(TransactionFilter filter);
        Task<BalanceAdjustment> SaveAsync(BalanceAdjustment toSave);
    }
}