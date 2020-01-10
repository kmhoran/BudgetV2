using System;
using System.Threading.Tasks;
using AutoMapper;
using Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace WebApi.Controllers.Transactions
{
    [ApiController]
    [Route("transaction/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ExpenseController> _logger;
        private readonly IExpenseService _expenseService;
        private readonly IBudgetDbSettings _dbSettings;

        public ExpenseController(IExpenseService expenseService, IMapper mapper, ILogger<ExpenseController> logger, IBudgetDbSettings dbSettings)
        {
            _mapper = mapper;
            _logger = logger;
            _expenseService = expenseService;
            _dbSettings = dbSettings;
        }

        [HttpGet("year")]
        public async Task<Year<Expense>> GetYearExpenses([FromQuery]int? year)
        {
            return await _expenseService.GetYearPerformanceAsync(year);
        }

        [HttpGet("month")]
        public async Task<Month<Expense>> GetExpense([FromQuery]int? month)
        {
            return await _expenseService.GetMonthAsync(month);
        }

        [HttpGet("sanity")]
        public IBudgetDbSettings GetSanity()
        {
            return _dbSettings;
        }

        [HttpPost]
        public async Task<Expense> SaveExpense([FromBody] ExpenseSaveRequest model)
        {
            var toSave = _mapper.Map<Expense>(model);
            return await _expenseService.SaveAsync(toSave);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteExpense([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            await _expenseService.DeleteAsync(id);
            return true;
        }
    }
}
