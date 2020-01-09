using System;

namespace WebApi.Controllers.Transactions
{
    public class IncomeSaveRequest
    {

        public string TransactionId { get; set; }
        public DateTime TransactionDateUTC { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ForUserId { get; set; }
    }
}