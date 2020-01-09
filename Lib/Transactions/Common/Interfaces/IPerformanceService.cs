using System;
using System.Threading.Tasks;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    public interface IPerformanceService
    {
        Task<PerformanceMonth> GetMonthPerformance(int? monthId);
        Task<PerformanceYear> GetYearPerformance(int? year);
    }
}