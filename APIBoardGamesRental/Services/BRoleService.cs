using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoardGamesRental.Models;
using MongoDB.Driver;

namespace APIBoardGamesRental.Services
{
    public class BRoleService{
        private readonly IMongoCollection<BRole> _broles;

        public BRoleService(IBGamesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _broles = database.GetCollection<BRole>(settings.BRoleCollectionName);
        }

        public List<BRole> Get() =>
            _broles.Find(role => true).ToList();

        public BRole Get(string id) =>
            _broles.Find<BRole>(role => role.oid == id).FirstOrDefault();

        public BRole Create(BRole role)
        {
            _broles.InsertOne(role);
            return role;
        }

        public void Update(string id, BRole roleIn) =>
            _broles.ReplaceOne(role => role.oid == id, roleIn);

        public void Remove(BRole roleIn) =>
            _broles.DeleteOne(role => role.oid == roleIn.oid);

        public void Remove(string id) =>
            _broles.DeleteOne(role => role.oid == id);
    }
}
