using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBAggregation
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("account_id")]
        public string AccountId { get; set; }

        [BsonElement("account_holder")]
        public string AccountHolder { get; set; }

        [BsonElement("account_type")]
        public string AccountType { get; set; }

        [BsonElement("balance")]
        public double Balance { get; set; }

        public static List<BsonDocument> AccountBsonDocuments()
        {
            var accountDocuments = new List<BsonDocument>
            {
                new BsonDocument
                {
                    { "account_id", "MDB123456789" },
                    { "account_holder", "Alice Smith" },
                    { "account_type", "savings" },
                    { "balance", 1000000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB987654321" },
                    { "account_holder", "Bob Johnson" },
                    { "account_type", "checking" },
                    { "balance", 50000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB456789123" },
                    { "account_holder", "Charlie Brown" },
                    { "account_type", "savings" },
                    { "balance", 250000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB654321987" },
                    { "account_holder", "David Lee" },
                    { "account_type", "checking" },
                    { "balance", 10000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB789456123" },
                    { "account_holder", "Emily Davis" },
                    { "account_type", "savings" },
                    { "balance", 750000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB321456789" },
                    { "account_holder", "Frank Lee" },
                    { "account_type", "checking" },
                    { "balance", 20000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB789654321" },
                    { "account_holder", "Grace Chen" },
                    { "account_type", "savings" },
                    { "balance", 500000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB456123789" },
                    { "account_holder", "Henry Park" },
                    { "account_type", "checking" },
                    { "balance", 5000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB321654987" },
                    { "account_holder", "Isabella Kim" },
                    { "account_type", "savings" },
                    { "balance", 100000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB987321654" },
                    { "account_holder", "Jackie Chen" },
                    { "account_type", "checking" },
                    { "balance", 1000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB456789321" },
                    { "account_holder", "Kevin Lee" },
                    { "account_type", "savings" },
                    { "balance", 50000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB321987654" },
                    { "account_holder", "Linda Kim" },
                    { "account_type", "checking" },
                    { "balance", 500 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB789123456" },
                    { "account_holder", "Mike Johnson" },
                    { "account_type", "savings" },
                    { "balance", 1000000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB654987321" },
                    { "account_holder", "Nancy Lee" },
                    { "account_type", "checking" },
                    { "balance", 2000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB123789456" },
                    { "account_holder", "Oliver Kim" },
                    { "account_type", "savings" },
                    { "balance", 250000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB987456123" },
                    { "account_holder", "Peter Park" },
                    { "account_type", "checking" },
                    { "balance", 100 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB456321789" },
                    { "account_holder", "Queenie Chen" },
                    { "account_type", "savings" },
                    { "balance", 75000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB321789654" },
                    { "account_holder", "Richard Lee" },
                    { "account_type", "checking" },
                    { "balance", 500 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB789321456" },
                    {"account_holder", "Samantha Kim" },
                    { "account_type", "savings" },
                    { "balance", 500000 }
                },
                new BsonDocument
                {
                    { "account_id", "MDB654123789" },
                    { "account_holder", "Tom Johnson" },
                    { "account_type", "checking" },
                    { "balance", 10000 }
                }
            };
            return accountDocuments;
        }

        public static async Task InsertManyAsync()
        {
            try
            {
                //const string connectionUri = "mongodb+srv://aselbehary:sRqAEfS87WdpTIzM@cluster0.7h3aetd.mongodb.net/?retryWrites=true&w=majority";
                const string connectionLocalHost = "mongodb://localhost:27017/";
                var mongoURL = new MongoUrl(connectionLocalHost);
                var client = new MongoClient(mongoURL);
                var database = client.GetDatabase("Bank");
                var bsoncollection = database.GetCollection<BsonDocument>("Account");
                var accountList = AccountBsonDocuments();
                await bsoncollection.InsertManyAsync(accountList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static long CountDocument()
        {
            try
            {
                const string connectionUri = "mongodb+srv://aselbehary:sRqAEfS87WdpTIzM@cluster0.7h3aetd.mongodb.net/?retryWrites=true&w=majority";
                var mongoURL = new MongoUrl(connectionUri);
                var client = new MongoClient(mongoURL);
                var database = client.GetDatabase("Bank");
                var bsoncollection = database.GetCollection<BsonDocument>("Account");
                return bsoncollection.CountDocuments(new BsonDocument());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
