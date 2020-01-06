using System;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace Transactions.Services
{
    public class ExpenseService : TransactionService<Expense>, IExpenseService
    {
        private IExpenseRepository expenseRepo;

        public ExpenseService(IExpenseRepository repo)
        : base(repo)
        {
            expenseRepo = repo;
        }

        public async Task<Expense> GetASync(string id)
            => await expenseRepo.GetAsync(id);

        public async Task<Expense> SaveAsync(Expense toSave)
        {
            // allow for partial update
            if (!string.IsNullOrEmpty(toSave.TransactionId))
            {
                var existing = await expenseRepo.GetAsync(toSave.TransactionId);
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
                    toSave.ByUserId = string.IsNullOrEmpty(toSave.ByUserId)
                        ? existing.ByUserId
                        : toSave.ByUserId;
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
            if (!ValidateExpense(toSave)) throw new ArgumentException("Invalid Expense model");

            return await expenseRepo.SaveAsync(toSave);
        }

        public bool ValidateExpense(Expense expense)
        {
            if (string.IsNullOrEmpty(expense.Category)) return false;
            if (string.IsNullOrEmpty(expense.Description)) return false;
            if (string.IsNullOrEmpty(expense.ByUserId)) return false;
            if (string.IsNullOrEmpty(expense.ForUserId)) return false;
            if (expense.TransactionDateUTC == default(DateTime)) return false;
            return true;
        }

    }
}
