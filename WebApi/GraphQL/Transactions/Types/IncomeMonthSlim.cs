using System;
using GraphQL.Types;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class IncomeMonthSlimType: ObjectGraphType<IMonth<Income>>
    {
        public IncomeMonthSlimType()
        {
            Field(x => x.TotalAmount);
            Field(x => x.MonthId);
        }
    }
}