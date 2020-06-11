using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoardGamesRental.Models
{
    public class BUsers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string oid { get; set; }
        public string login { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string ulica { get; set; }
        public string nrdomu { get; set; }
        public string miasto { get; set; }
        public string kodpocztowy { get; set; }
        public string role { get; set; }
    }
}
