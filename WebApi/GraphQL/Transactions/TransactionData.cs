using System;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions
{
    public class TransactionData: ITransactionData
    {
        private IExpenseService _expenseService;

        public TransactionData(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public Task<Month<Expense>> GetMonth(int monthId)
        {
            return _expenseService.GetMonthPerformanceAsync(monthId);
        }
    }
}