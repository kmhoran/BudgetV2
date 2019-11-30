using System;
using GraphQL.Types;
using Transactions.Common.Interfaces;
using WebApi.GraphQL.Transactions;

namespace WebApi.GraphQL
{
    public class BudgetQuery: ObjectGraphType
    {
        public BudgetQuery(ITransactionData data)
        {
            Field<MonthExpenseType>(
                "monthExpense",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "monthId" }),
                resolve: context =>
                {
                    var monthId = context.GetArgument<int>("monthId");
                    return data.GetMonth(monthId);
                }
            );

        }
    }
}