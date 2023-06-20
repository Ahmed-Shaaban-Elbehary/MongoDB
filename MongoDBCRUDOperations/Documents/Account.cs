using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleApp2.Documents
{
    public sealed class Account
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        [BsonElement("account_id")]
        public string AccountId { get; set; } = String.Empty;
        [BsonElement("account_holder")]
        public string AccountHolder { get; set; } = String.Empty;
        [BsonElement("account_type")]
        public string AccountType { get; set; } = String.Empty;
        [BsonRepresentation(BsonType.Decimal128)]
        [BsonElement("balance")]
        public decimal Balance { get; set; }
        [BsonElement("transfers_complete")]
        public string[] TransfersCompleted { get; set; } = Array.Empty<string>();



    }
}
