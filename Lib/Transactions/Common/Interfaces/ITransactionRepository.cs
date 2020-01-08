using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface ITransactionRepository<T>
    where T : ITransaction
    {
        Task<T> GetAsync(string id);
        Task<T> SaveAsync(T toSave);
        Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> expression);
        Task<Month<T>> GetMonthAsync(int monthId);
        Task<Year<T>> GetYearAsync(int year);
        Task<(List<T> records, int count)> FilterAsync(InputRange<long?> dateRange, MinorFilter filter);
        Task<Month<INamedBalance>> GetMonthCategoriesAsync(int monthId);
        Task<Year<INamedBalance>> GetYearCategoriesAsync(int year);
        Task DeleteAsync(string id);
    }
}