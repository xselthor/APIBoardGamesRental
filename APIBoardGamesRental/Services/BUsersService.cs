using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoardGamesRental.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace APIBoardGamesRental.Services
{
    public class BUsersService
    {
        private readonly IMongoCollection<BUsers> _busers;

        public BUsersService(IBGamesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _busers = database.GetCollection<BUsers>(settings.BUsersCollectionName);
        }

        public List<BUsers> Get() =>
            _busers.Find(users => true).ToList();

        public BUsers Get(string id) =>
            _busers.Find<BUsers>(users => users.oid == id).FirstOrDefault();

        public BUsers Create(BUsers user)
        {
            _busers.InsertOne(user);
            return user;
        }

        public void Update(string id, BUsers userIn) =>
            _busers.ReplaceOne(users => users.oid == id, userIn);

        public void Remove(BUsers userIn) =>
            _busers.DeleteOne(users => users.oid == userIn.oid);

        public void Remove(string id) =>
            _busers.DeleteOne(users => users.oid == id);
    }
}
