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
    public class BGamesService
    {
        private readonly IMongoCollection<BGames> _bgames;

        public BGamesService(IBGamesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bgames = database.GetCollection<BGames>(settings.BGamesCollectionName);
        }

        public List<BGames> Get() =>
            _bgames.Find(book => true).ToList();

        public BGames Get(string id) =>
            _bgames.Find<BGames>(games => games.oid == id).FirstOrDefault();

        public BGames Create(BGames bgame)
        {
            _bgames.InsertOne(bgame);
            return bgame;
        }
        //        public void Update(string id, BGames bookIn) =>
        public void Update(string id, BGames bookIn) =>
            _bgames.ReplaceOne(games => games.oid == id, bookIn);

        public void Remove(BGames bgameIn) =>
            _bgames.DeleteOne(games => games.oid == bgameIn.oid);

        public void Remove(string id) =>
            _bgames.DeleteOne(games => games.oid == id);
    }
}
