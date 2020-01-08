using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IExpenseService: ITransactionService<Expense>
    {
        Task<Expense> GetASync(string id);
        Task<(List<Expense> records, int count)> FilterAsync(TransactionFilter filter);
        Task<Expense> SaveAsync(Expense toSave);
    }
}