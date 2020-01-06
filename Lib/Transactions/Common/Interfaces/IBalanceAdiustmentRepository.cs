using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IBalanceAdjustmentRepository : ITransactionRepository<BalanceAdjustment>
    {
    }
}