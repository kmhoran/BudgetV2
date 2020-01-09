using System;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IExpenseRepository : ITransactionRepository<Expense>
    {

    }
}