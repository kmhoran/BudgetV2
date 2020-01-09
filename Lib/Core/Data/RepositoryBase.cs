using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Data.Models;
using MongoDB.Driver;

namespace Transactions.Repositories
{
    // MongoDb Repository
    public class RepositoryBase<T>
    where T : class
    {
        private IMongoCollection<T> _db;

        public RepositoryBase(IBudgetDbSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _db = database.GetCollection<T>(collectionName);
        }

        protected async Task<T> SingleAsync(Expression<Func<T, bool>> expression)
            => await _db.Find<T>(expression, null).FirstOrDefaultAsync();

        protected async Task<List<T>> MultipleAsync(Expression<Func<T, bool>> expression)
        {
            var result = _db.Find(expression);

            return await result.ToListAsync();
        }

        protected virtual async Task DeleteAsync(Expression<Func<T, bool>> expression) => await _db.DeleteOneAsync(expression);

        protected virtual async Task DeleteManyAsync(Expression<Func<T, bool>> expression) => await _db.DeleteManyAsync(expression);

        protected virtual async Task<T> CreateAsync(T toSave)
        {
            await _db.InsertOneAsync(toSave);
            return toSave;
        }

        protected virtual async Task<T> UpdateAsync(Expression<Func<T, bool>> expression, T toUpdate)
        {
            await _db.ReplaceOneAsync(expression, toUpdate);
            return toUpdate;
        }
    }
}
