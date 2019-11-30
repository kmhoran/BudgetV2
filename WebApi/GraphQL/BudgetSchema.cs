using System;
using GraphQL.Types;
using Transactions.Common.Interfaces;
using WebApi.GraphQL.Transactions;

namespace WebApi.GraphQL
{
    public class BudgetSchema: Schema
    {
        public BudgetSchema(ITransactionData data)
        {
            Query = new BudgetQuery(data);
        }
    }
}