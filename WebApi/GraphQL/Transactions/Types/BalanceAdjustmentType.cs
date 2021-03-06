using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class BalanceAdjustmentType : ObjectGraphType<BalanceAdjustment>
    {
        public BalanceAdjustmentType()
        {
            Field(x => x.TransactionId);
            Field(x => x.Amount);
            Field(x => x.Category);
            Field(x => x.CreatedUTC);
            Field(x => x.Description);
            Field(x => x.ForUserId);
            Field(x => x.LastChangedBy);
            Field(x => x.LastModifiedUTC);
            Field(x => x.MonthId);
            Field(x => x.Year);
        }
    }
}