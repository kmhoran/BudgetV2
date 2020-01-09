using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace Transactions.Services
{
    public class IncomeService : TransactionService<Income>, IIncomeService
    {
        private IIncomeRepository incomeRepo;

        public IncomeService(IIncomeRepository repo)
        : base(repo)
        {
            incomeRepo = repo;
        }

        public async Task<Income> GetASync(string id)
            => await incomeRepo.GetAsync(id);

        public async Task<(List<Income> records, int count)> FilterAsync(TransactionFilter filter)
            => await FilterAsync(filter?.DateRange, filter?.Income);

        public async Task<Income> SaveAsync(Income toSave)
        {
            // allow for partial update
            if (!string.IsNullOrEmpty(toSave.TransactionId))
            {
                var existing = await incomeRepo.GetAsync(toSave.TransactionId);
                if (existing != null)
                {
                    toSave.Amount = toSave.Amount == default(double)
                        ? existing.Amount
                        : toSave.Amount;
                    toSave.Category = string.IsNullOrEmpty(toSave.Category)
                        ? existing.Category
                        : toSave.Category;
                    toSave.Description = string.IsNullOrEmpty(toSave.Description)
                        ? existing.Description
                        : toSave.Description;
                    toSave.ForUserId = string.IsNullOrEmpty(toSave.ForUserId)
                        ? existing.ForUserId
                        : toSave.ForUserId;
                    toSave.TransactionDateUTC = toSave.TransactionDateUTC == default(DateTime)
                        ? existing.TransactionDateUTC
                        : toSave.TransactionDateUTC;
                    toSave.CreatedUTC = toSave.CreatedUTC == default(DateTime)
                        ? existing.CreatedUTC
                        : toSave.CreatedUTC;
                }
            }
            if (!ValidateIncome(toSave)) throw new ArgumentException("Invalid Income model");

            return await incomeRepo.SaveAsync(toSave);
        }

        public bool ValidateIncome(Income model)
        {
            if (string.IsNullOrEmpty(model.Category)) return false;
            if (string.IsNullOrEmpty(model.Description)) return false;
            if (string.IsNullOrEmpty(model.ForUserId)) return false;
            if (model.TransactionDateUTC == default(DateTime)) return false;
            return true;
        }
    }
}
