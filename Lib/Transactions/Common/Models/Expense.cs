using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transactions.Common.Models
{
    public class Expense : TransactionBase
    {

        public string ByUserId { get; set; }
    }
}