using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class ExpenseMonthType : ObjectGraphType<Month<Expense>>
    {
        public ExpenseMonthType()
        {
            Field(x => x.MonthId);
            Field(x => x.Values, nullable: true, type: typeof(ListGraphType<ExpenseType>));
            Field(x => x.TotalAmount);
        }
    }
}