using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class IncomeMonthType : ObjectGraphType<Month<Income>>
    {
        public IncomeMonthType()
        {
            Field(x => x.MonthId);
            Field(x => x.Values, nullable: true, type: typeof(ListGraphType<IncomeType>));
            Field(x => x.TotalAmount);
        }
    }
}