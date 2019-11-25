using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using Transactions.Common.Models;

namespace Transactions.Common.Interfaces
{
    [BsonSerializer(typeof(ImpliedImplementationInterfaceSerializer<ITransaction, TransactionBase>))]
    public interface ITransaction : IAccountable, IChangeTrackable, ITaggable
    {
        // [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        string TransactionId { get; set; }
        // [BsonDateTimeOptions(DateOnly = true)]
        int MonthId { get; }
        int Year { get; }
    }
}