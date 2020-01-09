using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class ExpenseCreateType : InputObjectGraphType
    {
        public ExpenseCreateType()
        {
            Field<NonNullGraphType<FloatGraphType>>("amount", "amount of the new transaction");
            Field<NonNullGraphType<StringGraphType>>("byUserId", "user making the");
            Field<NonNullGraphType<StringGraphType>>("category", "category of the purchase");
            Field<NonNullGraphType<StringGraphType>>("description", "description of the purchase");
            Field<NonNullGraphType<StringGraphType>>("forUserId", "user benefiting from the purchase");
            Field<NonNullGraphType<DateTimeGraphType>>("transactionDateUTC", "date the purchase occurred");
        }
    }
}