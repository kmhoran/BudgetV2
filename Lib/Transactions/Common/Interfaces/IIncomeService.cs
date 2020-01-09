using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IIncomeService : ITransactionService<Income>
    {
        Task<Income> GetASync(string id);
        Task<(List<Income> records, int count)> FilterAsync(TransactionFilter filter);
        Task<Income> SaveAsync(Income toSave);
    }
}