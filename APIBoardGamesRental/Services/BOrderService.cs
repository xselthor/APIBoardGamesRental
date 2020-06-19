using APIBoardGamesRental.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoardGamesRental.Services
{
    public class BOrderService
    {
        private readonly IMongoCollection<BOrder> _border;

        public BOrderService(IBGamesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _border = database.GetCollection<BOrder>(settings.BOrderCollectionName);
        }

        public List<BOrder> Get() =>
            _border.Find(order => true).ToList();

        public BOrder Get(string id) =>
            _border.Find<BOrder>(order => order.oid == id).FirstOrDefault();

        public BOrder Create(BOrder border)
        {
            _border.InsertOne(border);
            return border;
        }

        public void Update(string id, BOrder orderIn) =>
            _border.ReplaceOne(order => order.oid == id, orderIn);

        public void Remove(BOrder borderIn) =>
            _border.DeleteOne(order => order.oid == borderIn.oid);

        public void Remove(string id) =>
            _border.DeleteOne(order => order.oid == id);
    }
}
