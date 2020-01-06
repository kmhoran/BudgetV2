using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class ExpenseYearType : ObjectGraphType<Year<Expense>>
    {
        public ExpenseYearType()
        {
            Field(x => x.YearId);
            Field(x => x.January, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.February, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.March, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.April, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.May, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.June, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.July, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.August, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.September, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.October, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.November, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.December, nullable: true, type: typeof(ExpenseMonthSlimType));
            Field(x => x.Months, nullable: false, type: typeof(ListGraphType<ExpenseMonthSlimType>));
            Field(x => x.TotalAmount);
        }
    }
}