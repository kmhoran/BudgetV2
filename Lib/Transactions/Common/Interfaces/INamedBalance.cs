using System;

namespace Transactions.Common.Interfaces
{
    public interface INamedBalance: IAccountable
    {
        string Name { get; }
        int MonthId { get; }
    }
}