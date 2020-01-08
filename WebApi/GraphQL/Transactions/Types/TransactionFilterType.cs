using System;
using GraphQL.Types;
using Transactions.Common.Models;

namespace WebApi.GraphQL.Transactions.Types
{
    public class TransactionFilterType : InputObjectGraphType
    {
        public TransactionFilterType()
        {
            Field<InputStringRangeType>("DateRange", "start date end date filter");
            Field<MinorFilterType>("Expense", "Filters for expense transactions");
            Field<MinorFilterType>("Income", "Filters for income transactions");
            Field<MinorFilterType>("Adjustments", "Filters for balance adjustment transactions");
        }
    }

    public class MinorFilterType : InputObjectGraphType
    {
        public MinorFilterType()
        {
            Field<IntGraphType>("Skip", "Number of results to skip over before returnin.");
            Field<IntGraphType>("Take", "Number of results to return -- page size.");
            Field<ListGraphType<StringGraphType>>("Categories", "Filter against category");
            Field<StringGraphType>("TextSearch", "Filter against description.");
            Field<InputFloatRangeType>("Amount", "max-min transaction amounts");
        }
    }

    public class InputStringRangeType : InputObjectGraphType
    {
        public InputStringRangeType()
        {
            Field<StringGraphType>("Start", "Start of range -- inclusive");
            Field<StringGraphType>("End", "End of range -- inclusive");
        }
    }

    public class InputFloatRangeType : InputObjectGraphType
    {
        public InputFloatRangeType()
        {
            Field<FloatGraphType>("Start", "Start of range -- inclusive");
            Field<FloatGraphType>("End", "End of range -- inclusive");
        }
    }
}

