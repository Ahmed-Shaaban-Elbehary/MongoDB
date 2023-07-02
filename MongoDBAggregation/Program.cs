using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBAggregation;

//const string connectionUri = "mongodb+srv://aselbehary:sRqAEfS87WdpTIzM@cluster0.7h3aetd.mongodb.net/?retryWrites=true&w=majority";
const string connectionLocalHost = "mongodb://localhost:27017/";
var mongoURL = new MongoUrl(connectionLocalHost);
var client = new MongoClient(mongoURL);
var database = client.GetDatabase("Bank");
var accountcollection = database.GetCollection<Account>("Account");
var bsoncollection = database.GetCollection<BsonDocument>("Account");

/*
 * InsertMany fail with 20 documents! either timeout excepiton or connection database exception!.
 * InsertManyAsync Success to add all once!.
 */
//await Account.InsertManyAsync();
//var result = Account.CountDocument();
//Console.WriteLine(result.ToString());

//Aggregation $match & #group Stages.
/*
var matchStage = Builders<Account>.Filter.Lte(a => a.Balance, 750000);

var options = new AggregateOptions { MaxTime = TimeSpan.FromSeconds(30) };

var aggregate = accountcollection.Aggregate(options)
    .Match(matchStage)
    .Group(
    a => a.AccountType,
    r => new
    {
        accountType = r.Key,
        total = r.Sum(r => 1)
    });

//var pipeline = new BsonDocument[]
//{
//    new BsonDocument("$match", new BsonDocument("balance", new BsonDocument("$lte", 1000)))
//};
//var aggregate = bsoncollection.Aggregate<BsonDocument>(pipeline, options).ToList();


var aggregatedList = aggregate.ToList();

foreach (var item in aggregatedList)
{
    Console.WriteLine(item);
}
*/

// Aggregation $sort & #project Stages.