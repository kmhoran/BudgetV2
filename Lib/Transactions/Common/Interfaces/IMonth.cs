using System;

namespace Transactions.Common.Interfaces
{
    public interface IMonth<T>
    where T : IAccountable
    {
        int MonthId { get; }
        double TotalAmount { get; }
    }
}