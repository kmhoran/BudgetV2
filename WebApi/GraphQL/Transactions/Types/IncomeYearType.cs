using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class IncomeYearType : ObjectGraphType<Year<Income>>
    {
        public IncomeYearType()
        {
            Field(x => x.YearId);
            Field(x => x.January, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.February, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.March, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.April, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.May, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.June, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.July, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.August, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.September, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.October, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.November, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.December, nullable: true, type: typeof(IncomeMonthSlimType));
            Field(x => x.Months, nullable: false, type: typeof(ListGraphType<IncomeMonthSlimType>));
            Field(x => x.TotalAmount);
        }
    }
}