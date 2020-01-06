using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IIncomeService: ITransactionService<Income>
    {
        Task<Income> GetASync(string id);
        Task<Income> SaveAsync(Income toSave);
    }
}