using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

namespace WebApi.Controllers.Transactions
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IExpenseService _expenseService;

        public TransactionController(IExpenseService expenseService, ILogger<TransactionController> logger)
        {
            _logger = logger;
            _expenseService = expenseService;
        }

        [HttpGet("expense/year")]
        public async Task<Year<Expense>> GetYearExpenses([FromQuery]int? year)
        {
            var amount = GetRandomNumber(1, 100);
            var expense = new Expense()
            {
                TransactionDateUTC = GetRandomDateTime(DateTime.Parse("2019-01-01T08:00:00Z"), DateTime.UtcNow),
                Amount = amount,
                Description = $"Purchase for ${amount}.",
                ForUserId = "user1",
                ByUserId = "user2",
                Category = "Personal"
            };
            await _expenseService.SaveAsync(expense);

            return await _expenseService.GetYearPerformanceAsync(year);
        }

        [HttpGet("expense/month")]
        public async Task<Month<Expense>> GetExpense([FromQuery]int? month)
        {
            return await _expenseService.GetMonthPerformanceAsync(month);
        }

        // [HttpPost]
        // public async Task<Expense> SaveExpense([FromBody] ExpenseSaveRequest model)
        // {
            
        // }

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            var amount = random.NextDouble() * (maximum - minimum) + minimum;
            return Math.Round(amount, 2, MidpointRounding.ToZero);
        }

        public DateTime GetRandomDateTime(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            var randomTest = new Random();
            TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
            return startDate + newSpan;
        }
    }
}
