using ConsoleApp2.Documents;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Helper
    {
        IMongoCollection<Account> accountsCollection;
        public Helper(IMongoCollection<Account> collection)
        {
            accountsCollection = collection;
        }
        public async Task AddAccount()
        {

            var newAccount = new Account
            {
                AccountId = "MDB829001337",
                AccountHolder = "Linus Torvalds",
                AccountType = "checking",
                Balance = 50352434
            };

            await accountsCollection.InsertOneAsync(newAccount);
        }
    }
}
