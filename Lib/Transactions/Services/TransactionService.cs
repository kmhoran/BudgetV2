using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

namespace Transactions.Services
{
    public class TransactionService<T> : ITransactionService<T>
    where T : ITransaction
    {
        protected ITransactionRepository<T> _repo;

        public TransactionService(ITransactionRepository<T> repo)
        {
            _repo = repo;
        }

        public async Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> expression)
            => await _repo.GetMultipleAsync(expression);



        public async Task<Month<T>> GetMonthAsync(int? monthId = null)
            => await _repo.GetMonthAsync(monthId ?? MonthUtil.CurretMonthId);

        public async Task<Year<T>> GetYearPerformanceAsync(int? yearId = null)
            => await _repo.GetYearAsync(yearId ?? DateTime.Now.Year);

        protected async Task<(List<T> records, int count)> FilterAsync(InputRange<string> dateRange, MinorFilter filter)
        {
            InputRange<long?> tickRange = new InputRange<long?>();
            if (dateRange != null)
            {
                tickRange.Start = StringDateToTicks(dateRange.Start);
                tickRange.End = StringDateToTicks(dateRange.End);
            }
            return await _repo.FilterAsync(tickRange, filter);
        }

        private long? StringDateToTicks(string dateString)
        {
            if (string.IsNullOrEmpty(dateString)) return (long?)null;
            DateTime date;
            var success = DateTime.TryParse(dateString, out date);
            return success ? date.Ticks : (long?)null;
        }

        public async Task<Month<INamedBalance>> GetMonthCategoriesAsync(int? monthId = null)
            => await _repo.GetMonthCategoriesAsync(monthId ?? MonthUtil.CurretMonthId);

        public async Task<Year<INamedBalance>> GetYearCategoriesAsync(int? yearId = null)
            => await _repo.GetYearCategoriesAsync(yearId ?? DateTime.Now.Year);

        public async Task DeleteAsync(string id)
            => await _repo.DeleteAsync(id);
    }
}
