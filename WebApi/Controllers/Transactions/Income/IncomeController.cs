using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace WebApi.Controllers.Transactions
{
    [ApiController]
    [Route("transaction/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<IncomeController> _logger;
        private readonly IIncomeService _IncomeService;

        public IncomeController(IIncomeService IncomeService, IMapper mapper, ILogger<IncomeController> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _IncomeService = IncomeService;
        }

        [HttpGet("year")]
        public async Task<Year<Income>> GetYearIncomes([FromQuery]int? year)
        {
            return await _IncomeService.GetYearPerformanceAsync(year);
        }

        [HttpGet("month")]
        public async Task<Month<Income>> GetIncome([FromQuery]int? month)
        {
            return await _IncomeService.GetMonthAsync(month);
        }

        [HttpPost]
        public async Task<Income> SaveIncome([FromBody] IncomeSaveRequest model)
        {
           var toSave = _mapper.Map<Income>(model);
           return await _IncomeService.SaveAsync(toSave);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteIncome([FromRoute] string id)
        {
            if(string.IsNullOrEmpty(id)) return false;
            await _IncomeService.DeleteAsync(id);
            return true;
        } 
    }
}
