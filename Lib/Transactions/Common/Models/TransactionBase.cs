using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Transactions.Common.Interfaces;
using Utils.Date;

namespace Transactions.Common.Models
{
    public class TransactionBase : ITransaction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime CreatedUTC { get; set; }
        public string Description { get; set; }
        public string ForUserId { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime LastModifiedUTC { get; set; }
        public DateTime TransactionDateUTC { get; set; }
        [BsonElement]
        public int MonthId
        {
            get{
                return MonthUtil.GetMonthId(TransactionDateUTC);
            }
        }

        [BsonElement]
        public int Year
        {
            get{
                return TransactionDateUTC.Year;
            }
        }
    }
}