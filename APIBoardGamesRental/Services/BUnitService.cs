using APIBoardGamesRental.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoardGamesRental.Services
{
    public class BUnitService
    {
        private readonly IMongoCollection<BUnit> _bunit;

        public BUnitService(IBGamesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _bunit = database.GetCollection<BUnit>(settings.BUnitCollectionName);
        }

        public List<BUnit> Get() =>
            _bunit.Find(unit => true).ToList();

        public List<BUnit> GetUnits(string gameid) =>
            _bunit.Find(unit => unit.gameid == gameid).ToList();

        public BUnit Get(string id) =>
            _bunit.Find<BUnit>(unit => unit.oid == id).FirstOrDefault();

        public BUnit Create(BUnit bunit)
        {
            _bunit.InsertOne(bunit);
            return bunit;
        }

        public void Update(string id, BUnit unitIn) =>
            _bunit.ReplaceOne(unit => unit.oid == id, unitIn);

        public void Remove(BUnit bunitIn) =>
            _bunit.DeleteOne(unit => unit.oid == bunitIn.oid);

        public void Remove(string id) =>
            _bunit.DeleteOne(unit => unit.oid == id);
    }
}
