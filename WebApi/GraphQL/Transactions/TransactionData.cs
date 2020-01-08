using System;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using WebApi.GraphQL.Transactions.Models;

namespace WebApi.GraphQL.Transactions
{
    public class TransactionData : ITransactionData
    {
        private IExpenseService _expenseService;
        private IIncomeService _incomeService;
        private IBalanceAdjustmentService _adjustmentService;
        private IPerformanceService _performanceService;

        public TransactionData(IExpenseService expenseService, IIncomeService incomeService, IBalanceAdjustmentService adjustmentService, IPerformanceService performanceService)
        {
            _expenseService = expenseService;
            _incomeService = incomeService;
            _adjustmentService = adjustmentService;
            _performanceService = performanceService;
        }

        public Task<Month<Expense>> GetMonthExpense(int monthId)
            => _expenseService.GetMonthAsync(monthId);

        public Task<Year<Expense>> GetYearExpense(int year)
            => _expenseService.GetYearPerformanceAsync(year);

        public Task<Expense> SaveExpense(Expense model)
            => _expenseService.SaveAsync(model);

        public Task<Month<Income>> GetMonthIncome(int monthId)
            => _incomeService.GetMonthAsync(monthId);

        public Task<Year<Income>> GetYearIncome(int year)
            => _incomeService.GetYearPerformanceAsync(year);

        public Task<PerformanceMonth> GetMonthPerformance(int? monthId = null)
            => _performanceService.GetMonthPerformance(monthId);

        public Task<PerformanceYear> GetYearPerformance(int? year = null)
            => _performanceService.GetYearPerformance(year);

        public async Task<TransactionResponse> GetTransactions(TransactionFilter filter)
        {
            var income = await _incomeService.FilterAsync(filter);
            var expense = await _expenseService.FilterAsync(filter);
            var adjustment = await _adjustmentService.FilterAsync(filter);

            return new TransactionResponse
            {
                Adjustment = new TransactionCollection<BalanceAdjustment>
                {
                    Items = adjustment.records,
                    TotalCount = adjustment.count
                },
                Expense = new TransactionCollection<Expense>
                {
                    Items = expense.records,
                    TotalCount = expense.count
                },
                Income = new TransactionCollection<Income>
                {
                    Items = income.records,
                    TotalCount = income.count
                }
            };
        }


    }
}