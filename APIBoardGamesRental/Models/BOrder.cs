using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoardGamesRental.Models
{
    public class BOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string oid { get; set; }
        public string[] orderid { get; set; }
        public string username { get; set; }
        public string DateCreated { get; set; }
        public string DateRelease { get; set; }
        public bool completed { get; set; }
        public string comments { get; set; }
    }
}
