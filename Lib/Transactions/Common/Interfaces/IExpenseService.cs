using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IExpenseService: ITransactionService<Expense>
    {
        Task<Expense> GetASync(string id);
        Task<Expense> SaveAsync(Expense toSave);
    }
}