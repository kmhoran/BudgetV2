using System;
using GraphQL.Types;
using Transactions.Common.Models;
using WebApi.GraphQL.Transactions;
using WebApi.GraphQL.Transactions.Types;

namespace WebApi.GraphQL
{
    public class BudgetQuery : ObjectGraphType
    {
        public BudgetQuery(ITransactionData data)
        {
            Field<ExpenseMonthType>(
                "monthExpense",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "monthId" }),
                resolve: context => data.GetMonthExpense(context.GetArgument<int>("monthId"))
            );
            Field<ExpenseYearType>(
                "yearExpense",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "year" }),
                resolve: context => data.GetYearExpense(context.GetArgument<int>("year"))
            );
            Field<IncomeMonthType>(
                "monthIncome",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "monthId" }),
                resolve: context => data.GetMonthIncome(context.GetArgument<int>("monthId"))
            );
            Field<IncomeYearType>(
                "yearIncome",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "year" }),
                resolve: context => data.GetYearIncome(context.GetArgument<int>("year"))
            );
            // new
            Field<PerformanceMonthType>(
                "monthPerformance",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "monthId" }),
                resolve: context => data.GetMonthPerformance(context.GetArgument<int?>("monthId"))
            );
            Field<PerformanceYearType>(
                "yearPerformance",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "year" }),
                resolve: context => data.GetYearPerformance(context.GetArgument<int?>("year"))
            );
            Field<TransactionResponseType>(
                "transactions",
                arguments: new QueryArguments(new QueryArgument<TransactionFilterType> { Name = "filter" }),
                resolve: context => data.GetTransactions(context.GetArgument<TransactionFilter>("filter"))
            );
        }
    }
}