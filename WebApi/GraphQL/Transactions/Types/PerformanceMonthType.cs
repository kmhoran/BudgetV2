using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class PerformanceMonthType : ObjectGraphType<PerformanceMonth>
    {
        public PerformanceMonthType()
        {
            Field(x => x.MonthId);
            Field(x => x.ExpenseTotal);
            Field(x => x.ExpenseProjected);
            Field(x => x.IncomeTotal);
            Field(x => x.IncomeProjected);
            Field(x => x.AdjustedTotal);
            Field(x => x.GoalTotal);
        }
    }
}