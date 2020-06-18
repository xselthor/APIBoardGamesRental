using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIBoardGamesRental.Models
{
    public class BBasket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string oid { get; set; }
        public string username { get; set; }
        public string gameid { get; set; }
        public string unitid { get; set; }
        public string DateCreated { get; set; }
    }
}
