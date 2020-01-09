using System;
using GraphQL.Types;
using Transactions.Common.Models;
using WebApi.GraphQL.Transactions.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class TransactionResponseType : ObjectGraphType<TransactionResponse>
    {
        public TransactionResponseType()
        {
            Field(x => x.Expense, nullable: false, type: typeof(ExpenseCollectionType));
            Field(x => x.Income, nullable: false, type: typeof(IncomeCollectionType));
            Field(x => x.Adjustment, nullable: false, type: typeof(AdjustmentCollectionType));
        }
    }

    public class ExpenseCollectionType : ObjectGraphType<TransactionCollection<Expense>>
    {
        public ExpenseCollectionType()
        {
            Field(x => x.Items, nullable: false, typeof(ListGraphType<ExpenseType>));
            Field(x => x.TotalCount, nullable: false, typeof(IntGraphType));
        }
    }
    public class IncomeCollectionType : ObjectGraphType<TransactionCollection<Income>>
    {
        public IncomeCollectionType()
        {
            Field(x => x.Items, nullable: false, typeof(ListGraphType<IncomeType>));
            Field(x => x.TotalCount, nullable: false, typeof(IntGraphType));
        }
    }
    public class AdjustmentCollectionType : ObjectGraphType<TransactionCollection<BalanceAdjustment>>
    {
        public AdjustmentCollectionType()
        {
            Field(x => x.Items, nullable: false, typeof(ListGraphType<BalanceAdjustmentType>));
            Field(x => x.TotalCount, nullable: false, typeof(IntGraphType));
        }
    }
}