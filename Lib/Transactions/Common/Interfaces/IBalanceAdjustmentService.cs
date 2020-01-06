using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IBalanceAdjustmentService: ITransactionService<BalanceAdjustment>
    {
        Task<BalanceAdjustment> GetASync(string id);
        Task<BalanceAdjustment> SaveAsync(BalanceAdjustment toSave);
    }
}