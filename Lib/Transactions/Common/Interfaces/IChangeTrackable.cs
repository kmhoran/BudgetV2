using System;

namespace Transactions.Common.Interfaces
{
    public interface IChangeTrackable
    {
        DateTime CreatedUTC { get; set; }
        string LastChangedBy { get; set; }
        DateTime LastModifiedUTC { get; set; }
    }
}