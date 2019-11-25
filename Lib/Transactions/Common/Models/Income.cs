using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Transactions.Common.Models
{
    public class Income : TransactionBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IncomeId { get; set; }
    }
}