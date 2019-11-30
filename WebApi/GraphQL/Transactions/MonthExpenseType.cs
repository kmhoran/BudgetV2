using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions
{
    public class MonthExpenseType : ObjectGraphType<Month<Expense>>
    {
        public MonthExpenseType()
        {
            Field(x => x.MonthId);
            Field(x => x.Values, nullable: true, type: typeof(ListGraphType<ExpenseType>));
            Field(x => x.TotalAmount);
        }
    }
}