using System;
using GraphQL.Types;
using WebApi.GraphQL.Transactions;

namespace WebApi.GraphQL
{
    public class BudgetSchema : Schema
    {
        public BudgetSchema(ITransactionData data)
        {
            Query = new BudgetQuery(data);
            Mutation = new BudgetMutation(data);
        }
    }
}