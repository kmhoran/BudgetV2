using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

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
            => await expenseRepo.SaveAsync(toSave);

    }
}
