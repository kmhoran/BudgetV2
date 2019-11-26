using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface ITransactionService<T>
    where T : ITransaction
    {
        Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> expression);
        Task<Month<T>> GetMonthPerformanceAsync(int? monthId = null);
        Task<Year<T>> GetYearPerformanceAsync(int? yearId = null);
        Task<Month<INamedBalance>> GetMonthCategoriesAsync(int? monthId = null);
        Task<Year<INamedBalance>> GetYearCategoriesAsync(int? yearId = null);
        Task DeleteAsync(string id);
    }
}