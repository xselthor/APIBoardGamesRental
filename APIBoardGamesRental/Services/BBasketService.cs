using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBoardGamesRental.Models;
using MongoDB.Driver;

namespace APIBoardGamesRental.Services
{
    public class BBasketService
    {
        private readonly IMongoCollection<BBasket> _bbasket;

        public BBasketService(IBGamesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bbasket = database.GetCollection<BBasket>(settings.BBasketCollectionName);
        }

        public List<BBasket> Get() =>
            _bbasket.Find(basket => true).ToList();

        public List<BBasket> GetBasket(string username) =>
            _bbasket.Find(basket => basket.username == username).ToList();

        public BBasket Get(string id) =>
            _bbasket.Find<BBasket>(basket => basket.oid == id).FirstOrDefault();

        public BBasket Create(BBasket bbasket)
        {
            _bbasket.InsertOne(bbasket);
            return bbasket;
        }
        //        public void Update(string id, BGames bookIn) =>
        public void Update(string id, BBasket basketIn) =>
            _bbasket.ReplaceOne(basket => basket.oid == id, basketIn);

        public void Remove(BBasket bbasketIn) =>
            _bbasket.DeleteOne(basket => basket.oid == bbasketIn.oid);

        public void Remove(string id) =>
            _bbasket.DeleteOne(basket => basket.oid == id);
    }
}
