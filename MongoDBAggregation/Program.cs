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

// Aggregation $sort & #projection Stages.

#region Sort Stage
//var matchStage = Builders<Account>.Filter.Lte(a => a.Balance, 1000);
//var aggregate = accountcollection.Aggregate()
//    .Match(matchStage)
//    .SortByDescending(a => a.Balance);


//var matchStage = Builders<BsonDocument>.Filter.Lte("balance", 1000);
//var sort = Builders<BsonDocument>.Sort.Ascending("balance");
//var aggregate = bsoncollection.Aggregate()
//    .Match(matchStage)
//    .Sort(sort);
#endregion Sort Stage

#region Projection Stage
var matchStage = Builders<Account>.Filter.Gte(a => a.Balance, 10000);
var projectionStage = Builders<Account>.Projection.Expression(a =>
    new
    {
        AccountType = a.AccountType,
        AccountHolder = a.AccountHolder,
        Balance = a.Balance,
        GBP = (a.Balance / 1.30M).ToString()
    });

var aggregate = accountcollection.Aggregate()
    .Match(matchStage)
    .SortByDescending(a => a.Balance)
    .Project(projectionStage);
#endregion Projection Stage

var result = aggregate.ToList();

foreach (var item in result)
{
    Console.WriteLine(item.ToString());
}
