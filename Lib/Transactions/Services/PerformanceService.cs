using System;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

namespace Transactions.Services
{
    public class PerformanceService: IPerformanceService
    {
        private IExpenseService _expenseService;
        private IIncomeService _incomeService;
        private IBalanceAdjustmentService _adjustmentService;

        public PerformanceService(IExpenseService expenseService, IIncomeService incomeService, IBalanceAdjustmentService adjustmentService)
        {
            _expenseService = expenseService;
            _incomeService = incomeService;
            _adjustmentService = adjustmentService;
        }

        public async Task<PerformanceMonth> GetMonthPerformance(int? monthId = null)
        {
            int id = monthId ?? MonthUtil.CurretMonthId;
            var expense = await _expenseService.GetMonthAsync(id);
            var income = await _incomeService.GetMonthAsync(id);
            var adjustments = await _adjustmentService.GetMonthAsync(id);

            return new PerformanceMonth
            {
                MonthId = id,
                ExpenseTotal = expense.TotalAmount,
                IncomeTotal = income.TotalAmount,
                AdjustedTotal = adjustments.TotalAmount,
                // test values!!!
                ExpenseProjected = expense.TotalAmount,
                IncomeProjected = income.TotalAmount,
                GoalTotal = 100
            };
        }

        public async Task<PerformanceYear> GetYearPerformance(int? year = null)
        {
            var id = year ?? DateTime.Today.Year;
            var expense = await _expenseService.GetYearPerformanceAsync(year);
            var income = await _incomeService.GetYearPerformanceAsync(year);
            var adjustments = await _adjustmentService.GetYearPerformanceAsync(year);
            return new PerformanceYear
            {
                Year = id,
                ExpenseTotal = expense.TotalAmount,
                IncomeTotal = income.TotalAmount,
                AdjustedTotal = adjustments.TotalAmount,
                // test values!!!
                ExpenseProjected = expense.TotalAmount,
                IncomeProjected = income.TotalAmount,
                GoalTotal = 100
            };
        }
    }
}