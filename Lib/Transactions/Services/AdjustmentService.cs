using System;
using System.Collections.Generic;
using System.Linq;
using Transactions.Common.Interfaces;
using Transactions.Common.Models;
using Utils.Date;

namespace Transactions.Services
{
    public class AdjustmentService : TransactionService<BalanceAdjustment>
    {
        public AdjustmentService(ITransactionRepository<BalanceAdjustment> repo)
        : base(repo)
        {
        }
    }
}
