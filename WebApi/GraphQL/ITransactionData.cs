using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions
{
    public interface ITransactionData
    {
        Task<Month<Expense>> GetMonth(int monthId);
    }
}