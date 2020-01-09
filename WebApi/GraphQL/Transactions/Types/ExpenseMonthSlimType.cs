using System;
using GraphQL.Types;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class ExpenseMonthSlimType : ObjectGraphType<IMonth<Expense>>
    {
        public ExpenseMonthSlimType()
        {
            Field(x => x.TotalAmount);
            Field(x => x.MonthId);
        }
    }
}