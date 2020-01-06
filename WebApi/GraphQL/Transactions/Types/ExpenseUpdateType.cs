using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class ExpenseUpdateType : InputObjectGraphType
    {
        public ExpenseUpdateType()
        {
            Field<NonNullGraphType<StringGraphType>>("transactionId", "unique id of the purchase");
            Field<FloatGraphType>("amount", "full amount of the purchase");
            Field<StringGraphType>("byUserId", "user making the");
            Field<StringGraphType>("category", "category of the purchase");
            Field<StringGraphType>("description", "description of the purchase");
            Field<StringGraphType>("forUserId", "user benefiting from the purchase");
            Field<DateTimeGraphType>("transactionDateUTC", "date the purchase occurred");
        }
    }
}