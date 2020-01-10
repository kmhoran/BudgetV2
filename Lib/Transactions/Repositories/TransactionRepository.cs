using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Data;
using Core.Data.Models;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

namespace Transactions.Repositories
{
    public class TransactionRepository<T> : RepositoryBase<T>, ITransactionRepository<T>
    where T : class, ITransaction, new()
    {
        public TransactionRepository(IBudgetDbSettings settings, string collectionName)
        : base(settings, collectionName)
        {
        }

        private readonly string UserId = "USER";

        public async Task<T> GetAsync(string id)
            => await SingleAsync(x => x.TransactionId == id);

        public async Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>> expression)
            => await MultipleAsync(expression);

        public async Task<T> SaveAsync(T toSave)
        {
            if (string.IsNullOrEmpty(toSave.TransactionId))
                return await base.CreateAsync(toSave.TrackChanges(UserId, true));

            var id = toSave.TransactionId;
            return await base.UpdateAsync(x => x.TransactionId == id, toSave.TrackChanges(UserId));
        }

        protected override async Task<T> UpdateAsync(Expression<Func<T, bool>> expression, T toUpdate)
            => await base.UpdateAsync(expression, toUpdate.TrackChanges(UserId));

        public async Task<Month<T>> GetMonthAsync(int monthId)
        {
            var (year, month) = MonthUtil.ParseMonthId(monthId);
            var values = await MultipleAsync(x =>
            x.Year == year && x.MonthId == monthId);

            return new Month<T>(monthId, values);
        }

        public async Task<Year<T>> GetYearAsync(int year)
        {
            var transactions = await MultipleAsync(x => x.Year == year);
            var months = transactions.GroupBy(x => x.MonthId).Select(g =>
            {
                if (g.Count() == 0) return null;
                return new Month<T>(g.Key, g);
            }).Where(x => x != null).ToList();

            return new Year<T>(year, months);
        }

        public async Task<(List<T> records, int count)> FilterAsync(InputRange<long?> dateRange, MinorFilter filter)
        {
            var startTicks = dateRange?.Start;
            var endTicks = dateRange?.End;
            var categories = filter?.Categories ?? new List<string>();
            var textSearch = filter?.TextSearch ?? string.Empty;
            var minAmount = filter?.Amount?.Start;
            var maxAmount = filter?.Amount?.End;

            var transactions = await MultipleAsync(x =>
              (startTicks == null || x.Ticks >= startTicks)
              && (endTicks == null || x.Ticks <= endTicks)
              && (categories.Count() == 0 || categories.Contains(x.Category))
              && (string.IsNullOrEmpty(textSearch) || x.Description.ToLower().StartsWith(textSearch.ToLower()))
              && (minAmount == null || x.Amount >= minAmount)
              && (maxAmount == null || x.Amount <= maxAmount));

            var total = transactions.Count;

            var skip = filter?.Skip ?? 0;
            var take = filter?.Take ?? total;

            var page = transactions.OrderByDescending(x => x.Ticks)
            .Skip(skip).Take(take).ToList();

            return (records: page, count: total);
        }

        public async Task<Month<INamedBalance>> GetMonthCategoriesAsync(int monthId)
        {
            var (year, month) = MonthUtil.ParseMonthId(monthId);
            var transactions = await MultipleAsync(x =>
                x.Year == year && x.MonthId == monthId);

            var categories = transactions.GroupBy(x => x.Category)
                .Select(g => new CategoryBalance(g.Key, g.Sum(x => x.Amount), monthId));

            return new Month<INamedBalance>(monthId, categories);

        }

        public async Task<Year<INamedBalance>> GetYearCategoriesAsync(int year)
        {
            var transactions = await MultipleAsync(x => x.Year == year);

            var months = transactions.GroupBy(x => x.MonthId)
            .Select(g =>
            {
                var month = g.First().MonthId;
                var balances = g.GroupBy(c => c.Category).Select(x =>
                {
                    var first = x.First();
                    return new CategoryBalance(
                        first.Category,
                        x.Sum(w => w.Amount),
                        month);
                });
                return new Month<INamedBalance>(month, balances);
            });

            return new Year<INamedBalance>(year, months);
        }


        public async Task DeleteAsync(string id)
        {
            await base.DeleteAsync(x => x.TransactionId == id);
        }
    }

    internal static class TransactionExtentions
    {
        internal static T TrackChanges<T>(this T toSave, string userId, bool isNew = false)
        where T : class, IAccountable, IChangeTrackable, new()
        {
            var now = DateTime.Now;
            toSave.LastChangedBy = userId;
            toSave.LastModifiedUTC = now;
            if (isNew) toSave.CreatedUTC = now;

            return toSave;
        }
    }
}
