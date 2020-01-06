using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

namespace Transactions.Services
{
    public class BalanceAdjustmentService : TransactionService<BalanceAdjustment>, IBalanceAdjustmentService
    {
        private IBalanceAdjustmentRepository balanceAdjustmentRepo;

        public BalanceAdjustmentService(IBalanceAdjustmentRepository repo)
        : base(repo)
        {
            balanceAdjustmentRepo = repo;
        }

        public async Task<BalanceAdjustment> GetASync(string id)
          => await balanceAdjustmentRepo.GetAsync(id);

        public async Task<BalanceAdjustment> SaveAsync(BalanceAdjustment toSave)
        {
            // allow for partial update
            if (!string.IsNullOrEmpty(toSave.TransactionId))
            {
                var existing = await balanceAdjustmentRepo.GetAsync(toSave.TransactionId);
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
                    toSave.CreatedUTC = toSave.CreatedUTC == default(DateTime)
                        ? existing.CreatedUTC
                        : toSave.CreatedUTC;
                }
            }
            if (!ValidateBalanceAdjustment(toSave)) throw new ArgumentException("Invalid Income model");

            return await balanceAdjustmentRepo.SaveAsync(toSave);
        }

        public bool ValidateBalanceAdjustment(BalanceAdjustment model)
        {
            if (string.IsNullOrEmpty(model.Category)) return false;
            if (string.IsNullOrEmpty(model.Description)) return false;
            if (string.IsNullOrEmpty(model.ForUserId)) return false;
            return true;
        }
    }
}
