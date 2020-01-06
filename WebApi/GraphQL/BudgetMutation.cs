using System;
using GraphQL.Types;
using Transactions.Common.Models;
using WebApi.GraphQL.Transactions;
using WebApi.GraphQL.Transactions.Types;

namespace WebApi.GraphQL
{
    public class BudgetMutation : ObjectGraphType
    {
        public BudgetMutation(ITransactionData data)
        {
            Field<ExpenseType>(
              "addExpense",
              arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<ExpenseCreateType>> { Name = "input" }
              ),
              resolve: context => data.SaveExpense(context.GetArgument<Expense>("input"))
            );
            Field<ExpenseType>(
                "updateExpense",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ExpenseUpdateType>> { Name = "input" }
                ),
                resolve: context => data.SaveExpense(context.GetArgument<Expense>("input"))
            );
        }
    }
}