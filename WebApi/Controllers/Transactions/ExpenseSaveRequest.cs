using System;

namespace WebApi.Controllers.Transactions
{
    public class ExpenseSaveRequest
    {

        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedUTC { get; set; }
        public string Description { get; set; }
        public string ForUserId { get; set; }
    }
}