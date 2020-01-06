using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions
{
    public interface ITransactionData
    {
        Task<Month<Expense>> GetMonthExpense(int monthId);
        Task<Year<Expense>> GetYearExpense(int year);
        Task<Expense> SaveExpense(Expense model);
        Task<Month<Income>> GetMonthIncome(int monthId);
        Task<Year<Income>> GetYearIncome(int year);
        Task<PerformanceMonth> GetMonthPerformance(int? monthId);
        Task<PerformanceYear> GetYearPerformance(int? year);
        
    }
}