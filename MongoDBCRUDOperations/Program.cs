using ConsoleApp2.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

const string connectionUri = "mongodb+srv://aselbehary:sRqAEfS87WdpTIzM@cluster0.7h3aetd.mongodb.net/?retryWrites=true&w=majority";
//var settings = MongoClientSettings.FromConnectionString(connectionUri);
var mongoURL = new MongoUrl(connectionUri);
var client = new MongoClient(mongoURL);
var database = client.GetDatabase("sample_mflix");
var accountsCollection = database.GetCollection<Account>("account");
var commentCollection = database.GetCollection<Comment>("comment");
var bsonCollection = database.GetCollection<BsonDocument>("comments");


#region Inserting
//var document = new BsonDocument
//{
//   { "account_id", "MDB829001337" },
//   { "account_holder", "Linus Torvalds" },
//   { "account_type", "checking" },
//   { "balance", 50352434 }
//};
//bsonCollection.InsertOne(document);
//var newAccount = new Account
//{
//    AccountId = "MDB829001337",
//    AccountHolder = "Linus Torvalds",
//    AccountType = "checking",
//    Balance = 50352434
//};
//accountsCollection.InsertOne(newAccount);

//var helper = new Helper(accountsCollection);
//await helper.AddAccount();
#endregion Inserting

#region Querying 
//Using LINQ.
//var account1 = accountsCollection.Find(a => a.AccountId == "MDB829001337").FirstOrDefault();
//Console.WriteLine(account1.AccountHolder);

//Using BsonDocument Builder.
//var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("648e29ebab609b79a80bf1a8"));

//var account2 = bsonCollection.Find(filter).FirstOrDefault();
//Console.WriteLine(account2.);
#endregion Querying

#region Updating
UpdateResult result;
FilterDefinition<Account> accountFilter;
FilterDefinition<BsonDocument> bsonFilter;
UpdateDefinition<Account> accountUpdateDefinition;
UpdateDefinition<BsonDocument> bsonUpdateDefinition;
//Updating Documents 
bsonFilter = Builders<BsonDocument>.Filter.Eq("account_id", "MDB829001337");
bsonUpdateDefinition = Builders<BsonDocument>.Update.Set("balance", 8888);
//result = bsonCollection.UpdateOne(bsonFilter, bsonUpdateDefinition);

accountFilter = Builders<Account>.Filter.Eq(a => a.AccountId, "MDB829001337");
accountUpdateDefinition = Builders<Account>.Update.Set(a => a.Balance, 500);
//result = accountsCollection.UpdateOne(accountFilter, accountUpdateDefinition);

accountFilter = Builders<Account>.Filter.Eq(b => b.AccountType, "checking");
accountUpdateDefinition = Builders<Account>.Update.Inc(a => a.Balance, 5);
result = accountsCollection.UpdateMany(accountFilter, accountUpdateDefinition);

//Console.WriteLine(
//    $"Is Acknowladged: {result.IsAcknowledged}, " +
//    $"How many document match the filter: {result.MatchedCount}, " +
//    $"how many document updated: {result.ModifiedCount}");
#endregion Updating

#region Deleting

//delete within a C# linq
FilterDefinition<BsonDocument> deleteFilter;
DeleteResult deleteResult;

//deleteFilter = Builders<Comment>.Filter.Eq("_id", new ObjectId("5a9427648b0beebeb69579e7"));
//deleteResult = commentCollection.DeleteOne(deleteFilter);

//deleteFilter = Builders<Comment>.Filter
//    .Where(x => x.Date > new DateTime(2000, 1, 1));

deleteFilter = Builders<BsonDocument>.Filter.Lte("date", new BsonDateTime(new DateTime(2002, 8, 18)));
deleteResult = bsonCollection.DeleteMany(deleteFilter);

Console.WriteLine(
    $"Is Acknowladged: {deleteResult.IsAcknowledged}, " +
    $"How many document deleted: {deleteResult.DeletedCount}");

#endregion Deleting

#region Multi_Transactions

/*
 mongoDB provide ACID (Atomicity, Consistency, Isolation, and Durability)
 */

#endregion Multi_Transactions